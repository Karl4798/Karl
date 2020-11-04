package com.example.stepgoal;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Button;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

public class PersonalInformation extends AppCompatActivity {

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

    static String user = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_personal_information);

        // Gets logged in username
        user = Login.loggedInUser;

        // Assigns variables
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

        // Sets personal information
        setPersonalInfo();

        // Save button method
        save.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                // Gets user input
                String firstName = fname.getText().toString();
                String lastName = lname.getText().toString();
                String userWeight = weight.getText().toString();
                String userHeight = height.getText().toString();
                String userAge = age.getText().toString();

                Boolean saved;

                // Validation
                if (!firstName.equals("") && !lastName.equals("") && !userWeight.equals("")
                        && !userHeight.equals("") && !userAge.equals("")) {

                    // Saves metric values to the database
                    if (sw.isChecked() == true) {

                        Double w = Double.valueOf(weight.getText().toString());
                        Double h = Double.valueOf(height.getText().toString());

                        w = Math.round((w / 2.20462) * 100.0) / 100.0;
                        h = Math.round((h * 2.54) * 100.0) / 100.0;

                        int heightCM = (int) Math.round(h);
                        int weightKG = (int) Math.round(w);

                        saved = db.insertUserInfo(user, firstName, lastName, String.valueOf(weightKG), String.valueOf(heightCM), userAge);
                    }
                    // Saves imperial values to the database
                    else {
                        saved = db.insertUserInfo(user, firstName, lastName, userWeight, userHeight, userAge);
                    }
                    // Determines if data was saved successfully
                    if (saved == true) {
                        Toast.makeText(PersonalInformation.this, "Changes saved successfully!", Toast.LENGTH_SHORT).show();
                        Intent i = new Intent(PersonalInformation.this, MainActivity.class);
                        startActivity(i);
                    }

                }
                else {
                    // Validation
                    Toast.makeText(PersonalInformation.this, "Invalid input! Please enter all required fields.", Toast.LENGTH_SHORT).show();
                }
            }
        });

        // Metric / Imperial conversion
        sw.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                // Converts values to imperial units
                if (sw.isChecked() == true) {

                    tv7.setText("Weight (lb)");
                    tv6.setText("Height (in)");

                    try {
                        Double w = Double.valueOf(weight.getText().toString());
                        w = Math.round((2.2046 * w) * 100.0) / 100.0;
                        weight.setText(w.toString());
                    } catch(Exception e) {
                        // If values are invalid, then do not save them
                    }

                    try {
                        Double h = Double.valueOf(height.getText().toString());
                        h = Math.round((h / 2.54) * 100.0) / 100.0;
                        height.setText(h.toString());
                    } catch(Exception e) {
                        // If values are invalid, then do not save them
                    }

                }
                // Converts values to metric units
                else {

                    tv7.setText("Weight (kg)");
                    tv6.setText("Height (cm)");

                    try {
                        Double w = Double.valueOf(weight.getText().toString());
                        w = Math.round((w / 2.20462) * 100.0) / 100.0;
                        int weightKG = (int) Math.round(w);
                        weight.setText(String.valueOf(weightKG));
                    } catch(Exception e) {
                        // If values are invalid, then do not save them
                    }

                    try {
                        Double h = Double.valueOf(height.getText().toString());
                        h = Math.round((h * 2.54) * 100.0) / 100.0;
                        int heightCM = (int) Math.round(h);
                        height.setText(String.valueOf(heightCM));
                    } catch(Exception e) {
                        // If values are invalid, then do not save them
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

    @Override
    protected void onResume() {
        super.onResume();

        // Refreshes the logged in username
        user = Login.loggedInUser;

        // Sets personal information
        setPersonalInfo();
    }

    public void setPersonalInfo() {

        // Sets activity name
        ActionBar actionBar = getSupportActionBar();
        actionBar.setTitle("Personal Information");

        fname.requestFocus();

        // Gets data
        Cursor cursor = db.allData(user);
        if (cursor.getCount()==0) {
            Toast.makeText(this, "No Data Found!", Toast.LENGTH_SHORT).show();
        }
        else {
            while(cursor.moveToNext()) {
                fname.setText(cursor.getString(2));
                lname.setText(cursor.getString(3));
                weight.setText(cursor.getString(4));
                height.setText(cursor.getString(5));
                age.setText(cursor.getString(6));
            }
        }
    }

}
