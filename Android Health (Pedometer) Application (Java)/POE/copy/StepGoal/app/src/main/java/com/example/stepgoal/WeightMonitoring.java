package com.example.stepgoal;

import android.content.Intent;
import android.database.Cursor;
import android.graphics.Color;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Button;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import com.github.mikephil.charting.charts.BarChart;
import com.github.mikephil.charting.data.BarData;
import com.github.mikephil.charting.data.BarDataSet;
import com.github.mikephil.charting.data.BarEntry;

import java.util.ArrayList;

public class WeightMonitoring extends AppCompatActivity {

    // Control Variables
    BarChart barChart;
    Button addWeight;
    DatabaseHelper db;
    Switch sw;
    TextView target;
    Button progress;

    // Variables
    static String user = null;
    ArrayList<String> dates = new ArrayList<>();
    ArrayList<BarEntry> barEntries = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_weight_monitoring);

        // Gets logged in username
        user = Login.loggedInUser;;

        // Sets page name
        ActionBar actionBar = getSupportActionBar();
        actionBar.setTitle("Weight Monitoring");

        // Typecasting
        addWeight = findViewById(R.id.btnAddWeight);
        progress = findViewById(R.id.btnViewProgress);
        db = new DatabaseHelper(this);
        sw = findViewById(R.id.switch3);
        barChart = findViewById(R.id.bargraph);
        target = findViewById(R.id.textView2);

        // Sets bar chart properties
        barChart.setTouchEnabled(true);
        barChart.setDragEnabled(true);
        barChart.setScaleEnabled(true);
        barChart.setDescription("");
        barChart.getAxisRight().setDrawLabels(false);

        // Sets target weight label
        setTargetWeightLabel();

        // Opens an activity where you can add weight records
        addWeight.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                Intent i = new Intent(WeightMonitoring.this, AddWeightRecord.class);
                startActivity(i);
            }
        });

        // Sets units
        sw.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                barEntries.clear();
                dates.clear();
                barChart.clear();
                int indexes = 0;

                // Sets units to imperial
                if (sw.isChecked() == true) {

                    // Sets target weight label
                    setTargetWeightLabel();

                    // Gets values from the database
                    Cursor cursor = db.weightRecords(user);
                    if (cursor.getCount()==0) {
                        Toast.makeText(WeightMonitoring.this, "No Data Found!", Toast.LENGTH_SHORT).show();
                    }
                    else {
                        while(cursor.moveToNext()) {
                            dates.add(cursor.getString(1));
                            float val = Float.valueOf(cursor.getString(2));
                            val = Math.round(val * 2.20462);
                            barEntries.add(new BarEntry(val, indexes));
                            indexes++;
                        }

                    }

                    // Sets bar chart values
                    BarDataSet barDataSet = new BarDataSet(barEntries, "Weight (lb)");
                    barDataSet.setColor(Color.parseColor("#43b552"));
                    BarData theData = new BarData(dates, barDataSet);
                    barChart.setData(theData);
                    barChart.setVisibleXRangeMaximum(4);

                }
                // Sets units to metric
                else {

                    // Sets target weight label
                    setTargetWeightLabel();
                    onResume();

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

        // Progress button press event
        progress.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                // Temporary variables
                String weight = "";
                String targetWeight = "";

                // Gets data
                Cursor cursor = db.allData(user);
                if (cursor.getCount() != 0) {
                    while(cursor.moveToNext()) {
                        weight = cursor.getString(4);
                        targetWeight = cursor.getString(8);
                    }
                }

                // If variables are not set, then display a message
                if (weight.equals("") || targetWeight.equals("")) {
                    Toast.makeText(WeightMonitoring.this, "Please set target weight on goals page.", Toast.LENGTH_SHORT).show();
                }
                else {
                    // Navigate the user to the Weight Progress page
                    Intent i = new Intent(WeightMonitoring.this, WeightProgress.class);
                    startActivity(i);
                }

            }
        });

    }

    // Method used to set target weight label
    public void setTargetWeightLabel() {

        // Gets logged in username
        user = Login.loggedInUser;

        // Gets values from the database
        Cursor cursor = db.allData(user);
        if (cursor.getCount() > 0) {
            while(cursor.moveToNext()) {

                // Gets values in imperial units
                if (sw.isChecked() == true) {
                    // If no values are found, then display Not Set values
                    if (cursor.getString(8).equals("")) {
                        target.setText("Target: Not Set!");
                    }
                    else {
                        Double val = Double.valueOf(cursor.getString(8));
                        val = Math.round((2.2046 * val) * 100.0) / 100.0;
                        target.setText("Target: " + val + " lb");
                    }

                }
                // Gets values in metric units
                else {
                    // If no values are found, then display Not Set values
                    if (cursor.getString(8).equals("")) {
                        target.setText("Target: Not Set!");
                    }
                    // Else display the target value
                    else {
                        target.setText("Target: " + cursor.getString(8) + " kg");
                    }
                }
            }
        }

    }

    // Method to reset fields if a user logs out and in to another account
    @Override
    protected void onResume() {
        super.onResume();

        // Gets logged in username
        user = Login.loggedInUser;

        // Clears existing values
        dates.clear();
        barEntries.clear();
        barChart.clear();

        int indexes = 0;

        // Gets records from the database
        Cursor cursor = db.weightRecords(user);
        if (cursor.getCount()==0) {
            Toast.makeText(this, "No Data Found!", Toast.LENGTH_SHORT).show();
        }
        else {
            while(cursor.moveToNext()) {
                dates.add(cursor.getString(1));
                barEntries.add(new BarEntry(Float.valueOf(cursor.getString(2)), indexes));
                indexes++;
            }
        }

        // Sets bar chart
        BarDataSet barDataSet = new BarDataSet(barEntries, "Weight (kg)");
        barDataSet.setColor(Color.parseColor("#43b552"));
        BarData theData = new BarData(dates, barDataSet);
        barChart.setData(theData);

        barChart.setVisibleXRangeMaximum(4);

    }
}
