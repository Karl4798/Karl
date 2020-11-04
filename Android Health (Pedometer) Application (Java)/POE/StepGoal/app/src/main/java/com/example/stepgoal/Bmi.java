package com.example.stepgoal;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

public class Bmi extends AppCompatActivity {

    // Variables
    TextView tv7;
    TextView tv6;
    Switch sw;
    EditText weight;
    EditText height;
    Button calculate;
    TextView tv;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bmi);

        // Variables
        sw = findViewById(R.id.switch6);
        tv7 = findViewById(R.id.textView70);
        tv6 = findViewById(R.id.textView71);
        weight = findViewById(R.id.edWeight);
        height = findViewById(R.id.edHeight);
        calculate = findViewById(R.id.calculateBtn);
        tv = findViewById(R.id.resultTv);

        // Sets activity name
        ActionBar actionBar = getSupportActionBar();
        actionBar.setTitle("Calculate BMI");

        // Method to calculate the BMI value for the user
        calculate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                try {
                    // if the metric / imperial switch is checked, then calculate BMI using correct values
                    if (sw.isChecked() == true) {

                        // Gets the BMI for the user
                        Double bmi;
                        Double w = Double.valueOf(weight.getText().toString());
                        Double h = Double.valueOf(height.getText().toString());

                        // Calculates BMI
                        bmi = (703 * w) / (h * h);
                        bmi = Math.round(bmi * 100.0) / 100.0;

                        // Sets the label
                        tv.setText(String.valueOf((bmi)));

                    }
                    else {

                        // Gets the BMI for the user
                        Double bmi;
                        Double w = Double.valueOf(weight.getText().toString());
                        Double h = Double.valueOf(height.getText().toString());

                        // Calculates BMI
                        bmi = w / (Double.valueOf(h/100) * Double.valueOf(h/100));
                        bmi = Math.round(bmi * 100.0) / 100.0;
                        tv.setText(bmi.toString());

                    }
                } catch (Exception e) {
                    // Show error message
                    Toast.makeText(Bmi.this, "Invalid Input!", Toast.LENGTH_SHORT).show();
                }

            }
        });

        // Metric / Imperial switch changes values
        sw.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                if (sw.isChecked() == true) {

                    // Sets labels
                    tv7.setText("Weight (lb)");
                    tv6.setText("Height (in)");

                    try {
                        // Sets values
                        Double w = Double.valueOf(weight.getText().toString());
                        w = Math.round((2.2046 * w) * 100.0) / 100.0;
                        weight.setText(w.toString());
                    } catch(Exception e) {
                        // If values are invalid, then do not display them
                    }

                    try {
                        // Sets values
                        Double h = Double.valueOf(height.getText().toString());
                        h = Math.round((h / 2.54) * 100.0) / 100.0;
                        height.setText(h.toString());
                    } catch(Exception e) {
                        // If values are invalid, then do not display them
                    }

                }
                else {

                    // Sets labels
                    tv7.setText("Weight (kg)");
                    tv6.setText("Height (cm)");

                    try {
                        // Sets labels
                        Double w = Double.valueOf(weight.getText().toString());
                        w = Math.round((w / 2.20462) * 100.0) / 100.0;
                        weight.setText(w.toString());
                    } catch(Exception e) {
                        // If values are invalid, then do not display them
                    }

                    try {
                        // Sets labels
                        Double h = Double.valueOf(height.getText().toString());
                        h = Math.round((h * 2.54) * 100.0) / 100.0;
                        int heightCM = (int) Math.round(h);
                        height.setText(String.valueOf(heightCM));
                    } catch(Exception e) {
                        // If values are invalid, then do not display them
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
