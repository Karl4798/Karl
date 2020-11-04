package com.karl.onedirection;

// Required imports
import android.annotation.SuppressLint;
import android.content.DialogInterface;
import android.content.Intent;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import android.content.SharedPreferences;
import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.VideoView;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.FirebaseFirestore;

public class LoginActivity extends AppCompatActivity {

    // Variables used to hold visual objects from the XML
    Button RegisterButton, LoginButton, ResetPassword;
    EditText Email, Password;
    CheckBox Remember;
    ProgressBar ProgressBarLogin, ProgressBarLoggingIn;
    TextView LoggingIn;
    VideoView backgroundVideo;

    // Firebase Authentication variables - used to retrieve and save user information
    FirebaseAuth FAuth;
    FirebaseFirestore FStore;
    FirebaseUser user = FirebaseAuth.getInstance().getCurrentUser();

    // SQL Lite Database Helper variable
    // I have not used Firestore for saving trips, as trip log JSON records are larger than 1 mb - which is a limitation in Firestore.
    DatabaseHelper db;

    // Variable used for logging
    private static final String TAG = "LoginActivity";

    @SuppressLint("LogNotTimber")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        // Method to run if the used has opted to delete their account, which navigates the user back to the background activity, and deletes their account
        if (getIntent().getStringExtra("UIDCallback") != null) {

            // Reset "remember me" shared preference to false, and erase shared preference values for email, and hashed password
            removeSharedPrefs();

            // Deletes the user account from Firebase Auth
            user.delete()
                    .addOnCompleteListener(new OnCompleteListener<Void>() {
                        @SuppressLint("LogNotTimber")
                        @Override
                        public void onComplete(@NonNull Task<Void> task) {

                            // Error handling
                            if (task.isSuccessful()) {

                                // Once the user has been deleted, the below logic will delete the user preferences and trip history
                                FStore.collection("users").document(user.getUid())
                                        .delete().addOnCompleteListener(new OnCompleteListener<Void>() {

                                    @Override
                                    public void onComplete(@NonNull Task<Void> task) {

                                        if (task.isSuccessful()) {

                                            // Delete trip history for the user
                                            if (db.deleteTrips(user.getUid())) {

                                                // Display a message, indicating that the user account has been deleted
                                                Log.d(TAG, "User account preferences have been deleted for user " + user.getUid());
                                                Toast.makeText(LoginActivity.this, "Your account has been deleted.", Toast.LENGTH_LONG).show();

                                            }

                                            // Else if the trip history cannot be deleted, then show an error message
                                            else {

                                                // Display error message
                                                Log.d(TAG, "User trip history cannot be deleted for user " + user.getUid());
                                                Toast.makeText(LoginActivity.this, "Cannot delete saved trip history!", Toast.LENGTH_LONG).show();
                                            }

                                        }

                                        else {

                                            // Show error message
                                            Log.d(TAG, "User account preferences cannot be deleted for user " + user.getUid());
                                            Toast.makeText(LoginActivity.this, "Cannot delete the user account preferences!: " + task.getException(), Toast.LENGTH_LONG).show();

                                        }

                                    }

                                });

                            }

                            // If the user account cannot be deleted, then display an error
                            else {

                                // Display the error message
                                Log.d(TAG, "Cannot delete user account " + user.getUid());
                                Toast.makeText(LoginActivity.this, "Cannot delete the user account!", Toast.LENGTH_LONG).show();

                            }

                        }

                    });

        }

        // Setting object variables
        RegisterButton = findViewById(R.id.registerBtn);
        LoginButton = findViewById(R.id.loginBtn);
        Email = findViewById(R.id.edEmailLogin);
        Password = findViewById(R.id.edPasswordLogin);
        ProgressBarLogin = findViewById(R.id.progressBar2);
        ResetPassword = findViewById(R.id.resetPasswordBtn);
        Remember = findViewById(R.id.chkRememberMe);
        ProgressBarLoggingIn = findViewById(R.id.progressBar5);
        LoggingIn = findViewById(R.id.tvLoggingYouIn);

        // Creates an instance of the DatabaseHelper class - for use of the SQL Lite database
        db = new DatabaseHelper(this);

        // Gets the current Firebase authentication and Firestore instances
        FAuth = FirebaseAuth.getInstance();
        FStore = FirebaseFirestore.getInstance();

        // Get shared preferences, if any currently exist
        SharedPreferences preferences = getSharedPreferences("signin", MODE_PRIVATE);
        String remember = preferences.getString("remember", "false");
        String email = preferences.getString("email", "");
        String password = preferences.getString("password", "");

        // If the user has opted to "remember me", then run the sign in method with stored username and password shared preferences
        try {

            // If the user has shared preferences, then log them in
            if (remember.equals("true")) {

                setSignInGONE();
                signInWithEmailAndPassword(email, password, false);

            }

            // If the user does mot have shared preferences, then show the background screen
            else if (remember.equals("false")) {

                setSignInVisible();

            }

        } catch (Exception ex) {

            // If there is some exception, show the background page, and display the background screen - e.g. if there is no internet connection
            setSignInVisible();
            Log.d(TAG, "Error: " + ex.getMessage());

        }

        // Register button click event
        RegisterButton.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                // Navigates the user to the registration activity (page)
                Intent i = new Intent(LoginActivity.this, RegistrationActivity.class);
                startActivity(i);

            }

        });

        // Login button click event
        LoginButton.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                // Variables to store entered email and password
                String email = Email.getText().toString().trim();
                String password = Password.getText().toString().trim();

                // Validation
                if (TextUtils.isEmpty(email)) {
                    Email.setError("Email is Required!");
                    return;
                }
                if (TextUtils.isEmpty(password)) {
                    Password.setError("Password is Required!");
                    return;
                }
                if (password.length() < 6) {
                    Password.setError("Password Must Have 6 or More Characters");
                    return;
                }

                // Set the progress bar to visible, at the beginning of the authentication asynchronous event
                ProgressBarLogin.setVisibility(View.VISIBLE);

                // Authenticate the user using Firebase FAuth
                FAuth.signInWithEmailAndPassword(email, password).addOnCompleteListener(new OnCompleteListener<AuthResult>() {

                    @Override
                    public void onComplete(@NonNull Task<AuthResult> task) {

                        // If the sign in was successful, log the user in
                        if (task.isSuccessful()) {

                            // Save user details to shared preferences to re-authenticate the user later
                            SharedPreferences preferences = getSharedPreferences("signin", MODE_PRIVATE);
                            SharedPreferences.Editor editor = preferences.edit();
                            editor.putString("email", email);
                            editor.putString("password", password);
                            editor.apply();

                            if (Remember.isChecked()) {

                                signInWithEmailAndPassword(email, password, true);

                            }
                            else {

                                signInWithEmailAndPassword(email, password, false);

                            }

                        }
                        else {

                            // Show an appropriate error message - for example, the account does not exist
                            Toast.makeText(LoginActivity.this, "Error! " + task.getException().getMessage(), Toast.LENGTH_LONG).show();

                            // Set the progress bar to GONE - after the asynchronous authentication process has completed
                            ProgressBarLogin.setVisibility(View.GONE);

                        }

                    }

                });

            }

        });

        // Reset button click event
        ResetPassword.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {

                // Variables used in the new dialog box for reset password functionality
                EditText resetMail = new EditText(v.getContext());
                AlertDialog.Builder passwordResetDialog = new AlertDialog.Builder(v.getContext(), R.style.AlertDialogTheme);
                passwordResetDialog.setTitle("Reset Password");
                passwordResetDialog.setMessage("Enter your email address to receive a reset link.");
                passwordResetDialog.setView(resetMail);
                passwordResetDialog.setPositiveButton("Confirm", new DialogInterface.OnClickListener() {

                    @Override
                    public void onClick(DialogInterface dialog, int which) {

                        // Extract the email and send a reset link
                        String email = resetMail.getText().toString();
                        FAuth.sendPasswordResetEmail(email).addOnSuccessListener(new OnSuccessListener<Void>() {
                            @Override
                            public void onSuccess(Void aVoid) {
                                Toast.makeText(LoginActivity.this, "A reset link has been sent to your email.", Toast.LENGTH_LONG).show();
                            }
                        }).addOnFailureListener(new OnFailureListener() {
                            @Override
                            public void onFailure(@NonNull Exception e) {
                                Toast.makeText(LoginActivity.this, "Error! A reset link has not been sent to your email " + e.getMessage(), Toast.LENGTH_LONG).show();
                            }
                        });

                    }

                });

                passwordResetDialog.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {

                        // Close the dialog

                    }
                });

                passwordResetDialog.create().show();

            }

        });

        // Determine if the user has selected the "remember me" checkbox
        Remember.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {

                // If the user has selected the "remember me" checkbox, then set the shared preferences accordingly
                if (buttonView.isChecked()) {
                    SharedPreferences preferences = getSharedPreferences("signin", MODE_PRIVATE);
                    SharedPreferences.Editor editor = preferences.edit();
                    editor.putString("remember", "true");
                    editor.apply();
                }

                // If the user has not selected the "remember me" checkbox, then set the shared preferences accordingly
                else if (!buttonView.isChecked()) {
                    SharedPreferences preferences = getSharedPreferences("signin", MODE_PRIVATE);
                    SharedPreferences.Editor editor = preferences.edit();
                    editor.putString("remember", "false");
                    editor.apply();
                }

            }
        });

    }

    // Method used to delete shared preferences for auto-background functionality
    public void removeSharedPrefs() {

        // Deletes the shared preferences values
        SharedPreferences preferences = getSharedPreferences("signin", MODE_PRIVATE);
        SharedPreferences.Editor editor = preferences.edit();
        editor.remove("remember");
        editor.remove("email");
        editor.remove("password");
        editor.apply();

    }

    // Method used to sign the user into their account
    private void signInWithEmailAndPassword(String email, String password, Boolean saveToSharedPrefs) {

        SharedPreferences preferences = getSharedPreferences("signin", MODE_PRIVATE);
        SharedPreferences.Editor editor = preferences.edit();

        FAuth.signInWithEmailAndPassword(email, password).addOnCompleteListener(new OnCompleteListener<AuthResult>() {

            @Override
            public void onComplete(@NonNull Task<AuthResult> task) {

                // If the sign in was successful, log the user in
                if (task.isSuccessful()) {

                    FirebaseUser user = FAuth.getCurrentUser();

                    if (user.isEmailVerified()) {

                        if (saveToSharedPrefs) {

                            // Sets remember me shared preference
                            editor.putString("remember", "true");
                            editor.apply();

                        }

                        // Navigate the user to the main activity
                        Intent i = new Intent(LoginActivity.this, MainActivity.class);
                        startActivity(i);

                        // Set the progress bar to GONE - after the asynchronous authentication process has completed
                        ProgressBarLogin.setVisibility(View.GONE);

                        // Reset the email and password input fields
                        Email.setText("");
                        Password.setText("");

                        finish();

                    }

                    // Else if the user is not able to log in, show an error message
                    else {

                        // Show the error message
                        Toast.makeText(LoginActivity.this, "The email account has not yet been verified!" +
                                "\nPlease check your email inbox for a verification link.", Toast.LENGTH_LONG).show();

                        // Set the visibility of the Progress Bar to GONE, as the asynchronous event has finished
                        ProgressBarLogin.setVisibility(View.GONE);

                        setSignInVisible();

                        SharedPreferences preferences1 = getSharedPreferences("signin", MODE_PRIVATE);
                        SharedPreferences.Editor editor = preferences1.edit();
                        editor.remove("remember");
                        editor.apply();

                    }

                }
                else {

                    // Show an appropriate error message - for example, the account does not exist
                    Toast.makeText(LoginActivity.this, "Error! " + task.getException().getMessage(), Toast.LENGTH_LONG).show();

                    // Set the progress bar to GONE - after the asynchronous authentication process has completed
                    ProgressBarLogin.setVisibility(View.GONE);

                    setSignInVisible();

                    if (!Remember.isChecked()) {

                        SharedPreferences preferences1 = getSharedPreferences("signin", MODE_PRIVATE);
                        SharedPreferences.Editor editor = preferences1.edit();
                        editor.remove("remember");
                        editor.apply();

                    }

                }

            }

        });

    }

    // Set visibility of background activity elements appropriately
    private void setSignInGONE() {

        Email.setVisibility(View.GONE);
        Password.setVisibility(View.GONE);
        Remember.setVisibility(View.GONE);
        LoginButton.setVisibility(View.GONE);
        RegisterButton.setVisibility(View.GONE);
        ResetPassword.setVisibility(View.GONE);

        ProgressBarLoggingIn.setVisibility(View.VISIBLE);
        LoggingIn.setVisibility(View.VISIBLE);

    }

    // Set visibility of background activity elements appropriately
    private void setSignInVisible() {

        Email.setVisibility(View.VISIBLE);
        Password.setVisibility(View.VISIBLE);
        Remember.setVisibility(View.VISIBLE);
        LoginButton.setVisibility(View.VISIBLE);
        RegisterButton.setVisibility(View.VISIBLE);
        ResetPassword.setVisibility(View.VISIBLE);

        ProgressBarLoggingIn.setVisibility(View.GONE);
        LoggingIn.setVisibility(View.GONE);

    }

    @Override
    protected void onResume() {
        super.onResume();

        backgroundVideo = findViewById(R.id.backgroundVideo);
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
