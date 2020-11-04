package com.example.stepgoal;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Button;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

public class ProfileSetup extends AppCompatActivity {

    // Variables
    Switch sw;
    TextView fname;
    TextView lname;
    TextView weight;
    TextView height;
    TextView age;
    Button save;
    DatabaseHelper db;
    TextView tv7;
    TextView tv6;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_personal_information);

        // Assign values to variables
        db = new DatabaseHelper(this);
        sw = findViewById(R.id.switch1);
        fname = findViewById(R.id.edFName);
        lname = findViewById(R.id.edLName);
        weight = findViewById(R.id.edWeight);
        height = findViewById(R.id.edHeight);
        age = findViewById(R.id.edAge);
        save = findViewById(R.id.btnSave);
        tv7 = findViewById(R.id.textView7);
        tv6 = findViewById(R.id.textView6);

        // Save button method
        save.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                // Gets personal information from edit texts
                String firstName = fname.getText().toString();
                String lastName = lname.getText().toString();
                String userWeight = weight.getText().toString();
                String userHeight = height.getText().toString();
                String userAge = age.getText().toString();

                // Used when determining if changes were saved successfully
                Boolean saved;

                // Validation
                if (!firstName.equals("") && !lastName.equals("") && !userWeight.equals("")
                        && !userHeight.equals("") && !userAge.equals("")) {

                    // Saves values in metric units
                    if (sw.isChecked() == true) {

                        Double w = Double.valueOf(weight.getText().toString());
                        Double h = Double.valueOf(height.getText().toString());

                        w = Math.round((w / 2.20462) * 100.0) / 100.0;
                        h = Math.round((h * 2.54) * 100.0) / 100.0;

                        int heightCM = (int) Math.round(h);
                        int weightKG = (int) Math.round(w);

                        saveUserProfile();
                        saved = db.insertUserInfo(Register.user, firstName, lastName, String.valueOf(weightKG), String.valueOf(heightCM), userAge);
                    }
                    else {
                        saveUserProfile();
                        saved = db.insertUserInfo(Register.user, firstName, lastName, userWeight, userHeight, userAge);
                    }

                    // Determines if changes were saved successfully
                    if (saved == true) {
                        Toast.makeText(ProfileSetup.this, "Registered Successfully!", Toast.LENGTH_SHORT).show();
                        Intent i = new Intent(ProfileSetup.this, Login.class);
                        startActivity(i);
                    }

                }
                // If fields are not complete, then display a message
                else {
                    Toast.makeText(ProfileSetup.this, "Invalid input! Please enter all required fields.", Toast.LENGTH_SHORT).show();
                }
            }
        });

        // Converts units
        sw.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                // Displays values in imperial units
                if (sw.isChecked() == true) {

                    tv7.setText("Weight (lb)");
                    tv6.setText("Height (in)");

                    try {
                        Double w = Double.valueOf(weight.getText().toString());
                        w = Math.round((2.2046 * w) * 100.0) / 100.0;
                        weight.setText(w.toString());
                    } catch(Exception e) {
                        // if values are invalid, then do not save them
                    }

                    try {
                        Double h = Double.valueOf(height.getText().toString());
                        h = Math.round((h / 2.54) * 100.0) / 100.0;
                        height.setText(h.toString());
                    } catch(Exception e) {
                        // if values are invalid, then do not save them
                    }

                }
                // Displays values in metric units
                else {

                    tv7.setText("Weight (kg)");
                    tv6.setText("Height (cm)");

                    try {
                        Double w = Double.valueOf(weight.getText().toString());
                        w = Math.round((w / 2.20462) * 100.0) / 100.0;
                        int weightKG = (int) Math.round(w);
                        weight.setText(String.valueOf(weightKG));
                    } catch(Exception e) {
                        // if values are invalid, then do not save them
                    }

                    try {
                        Double h = Double.valueOf(height.getText().toString());
                        h = Math.round((h * 2.54) * 100.0) / 100.0;
                        int heightCM = (int) Math.round(h);
                        height.setText(String.valueOf(heightCM));
                    } catch(Exception e) {
                        // if values are invalid, then do not save them
                    }

                }
            }
        });

        // Always runs the onClick event when the user checks the switch button
        sw.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View view, MotionEvent motionEvent) {
                return motionEvent.getActionMasked() == motionEvent.ACTION_MOVE;
            }
        });

    }

    public void saveUserProfile() {

        // Saves values to the database
        db.insert(Register.user, Register.pass);
        db.insertGoals(Register.user, "6000", "");

    }

    @Override
    protected void onResume() {
        super.onResume();
    }
}
