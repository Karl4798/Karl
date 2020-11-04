package com.example.stepgoal;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

public class Goals extends AppCompatActivity {

    // Variables
    Spinner stepGoal;
    EditText targetWeight;
    Switch sw;
    DatabaseHelper db;
    Button save;
    TextView lblWeight;

    // Stores logged in username
    static String user = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_goals);

        // Sets username
        user = Login.loggedInUser;;

        // Sets the goal label
        setGoals();

        // Sets values to Metric / Imperial
        sw.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                // Sets values to imperial units
                if (sw.isChecked() == true) {

                    lblWeight.setText("Target Weight (lb)");

                    try {
                        // Converts values
                        Double w = Double.valueOf(targetWeight.getText().toString());
                        w = Math.round((2.2046 * w) * 100.0) / 100.0;
                        targetWeight.setText(w.toString());
                    } catch(Exception e) {
                        // Do not set values, if invalid
                    }

                }
                // Sets values to metric units
                else {

                    lblWeight.setText("Target Weight (kg)");

                    try {
                        // Converts values
                        Double w = Double.valueOf(targetWeight.getText().toString());
                        w = Math.round((w / 2.20462) * 100.0) / 100.0;
                        int weightKG = (int) Math.round(w);
                        targetWeight.setText(String.valueOf(weightKG));
                    } catch(Exception e) {
                        // Do not set values, if invalid
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

        // Save button button method for saving goals to the database
        save.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                // Validation
                try {

                    String stepCount = stepGoal.getSelectedItem().toString();

                    // Converts all values to metric units
                    if (sw.isChecked() == true) {
                        // Converts values
                        Double w = Double.valueOf(targetWeight.getText().toString());
                        w = Math.round((w / 2.20462) * 100.0) / 100.0;
                        int weightKG = (int) Math.round(w);
                        db.insertGoals(user, stepCount, String.valueOf(weightKG));
                    }
                    else {
                        // Converts values
                        Double w = Double.valueOf(targetWeight.getText().toString());
                        int weightKG = (int) Math.round(w);
                        db.insertGoals(user, stepCount, String.valueOf(weightKG));
                    }

                    // Once saved, navigate the user to MainActivity
                    Intent i = new Intent(Goals.this, MainActivity.class);
                    startActivity(i);

                } catch (Exception e) {

                    // Shows error message if input is invalid
                    Toast.makeText(Goals.this, "Please Enter Target Weight!", Toast.LENGTH_SHORT).show();

                }
            }
        });
    }

    @Override
    protected void onResume() {
        super.onResume();

        // Gets logged in username (refreshes it)
        user = Login.loggedInUser;

        // Sets goal label
        setGoals();
    }

    // Method to set spinner value
    private int getIndex(Spinner spinner, String myString){
        for (int i=0;i<spinner.getCount();i++){
            if (spinner.getItemAtPosition(i).toString().equalsIgnoreCase(myString)){
                return i;
            }
        }

        return 0;
    }

    // Method to set goal values
    public void setGoals() {

        // Control variables
        db = new DatabaseHelper(this);
        stepGoal = findViewById(R.id.stepCountSpinner);
        targetWeight = findViewById(R.id.targetWeightEd);
        sw = findViewById(R.id.switch2);
        save = findViewById(R.id.saveBtn);
        lblWeight = findViewById(R.id.textView9);


        // Sets activity name
        ActionBar actionBar = getSupportActionBar();
        actionBar.setTitle("Goals");

        // Step count goal spinner
        ArrayList<Integer> steps = new ArrayList<>();

        int i = 100;
        do {

            steps.add(i);
            i = i + 100;

        } while(i < 90000);

        ArrayAdapter<Integer> arrayAdapter = new ArrayAdapter<Integer>(this, android.R.layout.simple_spinner_item, steps);
        stepGoal.setAdapter(arrayAdapter);

        // Get database values
        Cursor cursor = db.allData(user);
        if (cursor.getCount()==0) {
            Toast.makeText(this, "No Data Found!", Toast.LENGTH_SHORT).show();
        }
        else {
            while(cursor.moveToNext()) {
                targetWeight.setText(cursor.getString(8));
                stepGoal.setSelection(getIndex(stepGoal, cursor.getString(7)));
            }
        }
    }

}
