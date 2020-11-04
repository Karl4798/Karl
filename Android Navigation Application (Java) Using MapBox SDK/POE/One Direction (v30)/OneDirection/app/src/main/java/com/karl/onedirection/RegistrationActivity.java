package com.karl.onedirection;

// Required imports
import android.annotation.SuppressLint;
import android.content.Intent;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.Switch;
import android.widget.Toast;
import android.widget.VideoView;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.FirebaseFirestore;
import com.mapbox.api.directions.v5.DirectionsCriteria;
import com.mapbox.mapboxsdk.maps.Style;
import java.util.HashMap;
import java.util.Map;

public class RegistrationActivity extends AppCompatActivity {

    // Variables used to store visual elements
    Button BackToLoginBtn, RegisterBtn;
    EditText FullName, Email, Password, ConfirmPassword;
    VideoView backgroundVideo;

    // Firebase Authentication and Firestore variables
    FirebaseAuth FAuth;
    FirebaseFirestore FStore;

    // ProgressBar used when showing asynchronous events
    ProgressBar ProgressBar;

    // Variables used to store preferences, and background details
    Switch Units;
    String units = "metric";
    String method = DirectionsCriteria.PROFILE_DRIVING;
    String mapStyle = Style.MAPBOX_STREETS;
    String userID;
    String TAG = "TAG";

    @SuppressLint("ClickableViewAccessibility")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registration);

        // Assigning variables from visual elements, from the xml
        BackToLoginBtn = findViewById(R.id.btnBackToLogin);
        RegisterBtn = findViewById(R.id.regButton);
        FullName = findViewById(R.id.edFullName);
        Email = findViewById(R.id.edEmail);
        Password = findViewById(R.id.edPassword);
        ConfirmPassword = findViewById(R.id.edConfirmPassword);
        ProgressBar = findViewById(R.id.progressBar);
        Units = findViewById(R.id.swUnits);

        // Gets the current Firebase authentication and Firestore instances
        FAuth = FirebaseAuth.getInstance();
        FStore = FirebaseFirestore.getInstance();

        // Back To Login button press event
        BackToLoginBtn.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                // Navigates the user back to the background activity
                Intent i = new Intent(RegistrationActivity.this, LoginActivity.class);
                startActivity(i);

            }

        });

        // Registration button press event
        RegisterBtn.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                // Variables used to store registration details
                String email = Email.getText().toString().trim();
                String password = Password.getText().toString().trim();
                String confirmPassword = ConfirmPassword.getText().toString().trim();
                String fullName = FullName.getText().toString().trim();

                // Input validation
                if (TextUtils.isEmpty(fullName)) {
                    FullName.setError("Please enter your full name!");
                    return;
                }
                if (TextUtils.isEmpty(email)) {
                    Email.setError("Email is Required!");
                    return;
                }
                if (TextUtils.isEmpty(password)) {
                    Password.setError("Password is Required!");
                    return;
                }
                if (TextUtils.isEmpty(confirmPassword)) {
                    ConfirmPassword.setError("Password Confirmation Required!");
                    return;
                }
                if (!password.equals(confirmPassword)) {
                    ConfirmPassword.setError("Passwords Must Match!");
                    return;
                }
                if (password.length() < 6) {
                    Password.setText("");
                    ConfirmPassword.setText("");
                    Password.setError("Password Must Have 6 or More Characters");
                    return;
                }

                // Set the visibility of the progress bar to visible, at the start of the asynchronous event
                ProgressBar.setVisibility(View.VISIBLE);

                // Register the user in Firebase Authentication, and their preferences in Firestore
                FAuth.createUserWithEmailAndPassword(email, password)
                        .addOnCompleteListener(new OnCompleteListener<AuthResult>() {

                            @Override
                            public void onComplete(@NonNull Task<AuthResult> task) {

                                // If / else surrounds the task creation - catches issues if they do occur
                                if (task.isSuccessful()) {

                                    // Send verification email
                                    FirebaseUser fuser = FAuth.getCurrentUser();
                                    fuser.sendEmailVerification().addOnSuccessListener(new OnSuccessListener<Void>() {
                                        @Override
                                        public void onSuccess(Void aVoid) {

                                            // Display a message indicating that the user must verify their email account, before they can log in
                                            Toast.makeText(RegistrationActivity.this, "The verification email has been sent.", Toast.LENGTH_LONG).show();

                                            // Destroy the Registration instance
                                            finish();

                                        }
                                    }).addOnFailureListener(new OnFailureListener() {
                                        @Override
                                        public void onFailure(@NonNull Exception e) {

                                            Log.d(TAG, "onFailure: Email has not been sent: " + e.getMessage());

                                        }
                                    });

                                    // Store user preferences in the Firebase Firestore
                                    userID = FAuth.getCurrentUser().getUid();
                                    DocumentReference documentReference = FStore.collection("users").document(userID);
                                    Map<String, Object> user = new HashMap<>();
                                    user.put("fName", fullName);
                                    user.put("email", email);
                                    user.put("units", units);
                                    user.put("method", method);
                                    user.put("mapStyle", mapStyle);
                                    documentReference.set(user).addOnSuccessListener(new OnSuccessListener<Void>() {

                                        @Override
                                        public void onSuccess(Void aVoid) {
                                            Log.d(TAG, "onSuccess: user profile is created for " + userID);
                                        }
                                    }).addOnFailureListener(new OnFailureListener() {

                                        @Override
                                        public void onFailure(@NonNull Exception e) {

                                            Log.d(TAG, "onFailure: " + e.toString());
                                        }

                                    });

                                // If the user cannot be created, a suitable message will be displayed - the log message from Firebase
                                } else {

                                    // Show the message to the user
                                    Toast.makeText(RegistrationActivity.this, "Error! " + task.getException().getMessage(), Toast.LENGTH_LONG).show();

                                    // Set the ProgressBar to invisible, as the asynchronous event has ended
                                    ProgressBar.setVisibility(View.INVISIBLE);

                                }

                            }

                        });

            }

        });

        // Units switch is used to determine if the user would like to use Imperial or Metric units
        Units.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                // If the Units switch is checked, then the units variable will be set to imperial
                if (Units.isChecked()) {

                    units = "imperial";

                // If the Units switch is not checked, then the units variable will be set to metric
                } else {

                    units = "metric";

                }

            }

        });

        // Does not allow the user to drag the switch, as it does not activate the setOnClickListener
        Units.setOnTouchListener(new View.OnTouchListener() {

            @Override
            public boolean onTouch(View v, MotionEvent event) {

                return event.getActionMasked() == MotionEvent.ACTION_MOVE;

            }

        });

    }

    @Override
    protected void onResume() {
        super.onResume();

        backgroundVideo = findViewById(R.id.backgroundVideoReg);
        String path = "android.resource://com.karl.onedirection/" + R.raw.background;

        Uri uri = Uri.parse(path);
        backgroundVideo.setVideoURI(uri);

        backgroundVideo.start();

        backgroundVideo.setOnPreparedListener(new MediaPlayer.OnPreparedListener() {
            @Override
            public void onPrepared(MediaPlayer mp) {
                mp.setLooping(true);
            }
        });

    }
}
