package com.example.stepgoal;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.text.InputType;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Switch;
import android.widget.Toast;

import java.util.Calendar;

public class AddWeightRecord extends AppCompatActivity {

    // Control variables
    DatePickerDialog picker;
    EditText eText;
    Button add;
    DatabaseHelper db;
    EditText weightEd;
    Switch sw;

    // Stores the logged in username
    static String user = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_weight_record);

        // Sets activity name
        ActionBar actionBar = getSupportActionBar();
        actionBar.setTitle("Add Weight Record");

        // Sets the logged in username
        user = Login.loggedInUser;

        // Variables
        db = new DatabaseHelper(this);
        sw = findViewById(R.id.switch5);
        weightEd = findViewById(R.id.editText);
        add = findViewById(R.id.btnAdd);
        eText= findViewById(R.id.editText1);
        eText.setInputType(InputType.TYPE_NULL);

        // Calendar button / edit text
        eText.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                final Calendar cldr = Calendar.getInstance();
                int day = cldr.get(Calendar.DAY_OF_MONTH);
                int month = cldr.get(Calendar.MONTH);
                int year = cldr.get(Calendar.YEAR);
                // date picker dialog
                picker = new DatePickerDialog(AddWeightRecord.this,
                        new DatePickerDialog.OnDateSetListener() {
                            @Override
                            public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {

                                String month = null;
                                String day = null;

                                if (String.valueOf(monthOfYear + 1).length() < 2) {
                                    month = "0" + (monthOfYear + 1);
                                }
                                else {
                                    month = String.valueOf(monthOfYear + 1);
                                }
                                if (String.valueOf(dayOfMonth).length() < 2) {
                                    day = "0" + dayOfMonth;
                                }
                                else {
                                    day = String.valueOf(dayOfMonth);
                                }
                                eText.setText(year + "-" + month + "-" + day);

                            }
                        }, year, month, day);
                picker.show();
            }
        });

        // Adds the record to the database
        add.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                // Sets text boxes
                String date = eText.getText().toString();
                String weight = weightEd.getText().toString();
                boolean saved = false;

                // Adds the record
                if (!date.equals("") && !weight.equals("")) {

                    // Adds record in metric units
                    if (sw.isChecked() == true) {

                        try {
                            // Calculates metric value from imperial input
                            Double w = Double.valueOf(weightEd.getText().toString());
                            w = Math.round((w / 2.20462) * 100.0) / 100.0;
                            int weightKG = (int) Math.round(w);
                            saved = db.insertWeight(user, date, String.valueOf(weightKG));
                            Intent i = new Intent(AddWeightRecord.this, WeightMonitoring.class);
                            startActivity(i);
                        } catch(Exception e) {
                            // If the record cannot be added, then it will not add it.
                        }

                    }
                    else {
                        // Adds the metric value from metric input
                        saved = db.insertWeight(user, date, weight);
                        Intent i = new Intent(AddWeightRecord.this, WeightMonitoring.class);
                        startActivity(i);
                    }

                    // Checks to see if record was saved
                    if (saved == false) {
                        // Displays toast if record added successfully
                        Toast.makeText(AddWeightRecord.this, "Record Already Exists!", Toast.LENGTH_SHORT).show();
                    }

                }
                // Validation ensures that fields are not blank
                else {
                    // Shows error message
                    Toast.makeText(AddWeightRecord.this, "Invalid Weight Record!", Toast.LENGTH_SHORT).show();
                }

            }
        });

        // Sets metric / imperial conversion
        sw.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                if (sw.isChecked() == true) {

                    // Sets text
                    weightEd.setHint("Weight (lb)");

                    try {
                        // Converts units
                        Double w = Double.valueOf(weightEd.getText().toString());
                        w = Math.round((2.2046 * w) * 100.0) / 100.0;
                        weightEd.setText(w.toString());
                    } catch(Exception e) {
                        // If no values are found, then do not convert the values
                    }

                }
                else {

                    // Sets text
                    weightEd.setHint("Weight (kg)");

                    try {
                        // Converts units
                        Double w = Double.valueOf(weightEd.getText().toString());
                        w = Math.round((w / 2.20462) * 100.0) / 100.0;
                        int weightKG = (int) Math.round(w);
                        weightEd.setText(String.valueOf(weightKG));
                    } catch(Exception e) {
                        // If no values are found, then do not convert the values
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

}
