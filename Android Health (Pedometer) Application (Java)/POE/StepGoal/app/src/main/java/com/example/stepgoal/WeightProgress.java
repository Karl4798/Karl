package com.example.stepgoal;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.database.Cursor;
import android.graphics.Color;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

import com.github.mikephil.charting.charts.PieChart;
import com.github.mikephil.charting.data.Entry;
import com.github.mikephil.charting.data.PieData;
import com.github.mikephil.charting.data.PieDataSet;

import java.util.ArrayList;
import java.util.List;

public class WeightProgress extends AppCompatActivity {

    // Control variables
    PieChart mChart;
    DatabaseHelper db;
    TextView goalWeight, currentWeight, weightLoss;
    Switch sw;

    // Variables
    ArrayList<Entry> entries = new ArrayList<>();
    static String user = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_weight_progress);

        // Sets activity name
        ActionBar actionBar = getSupportActionBar();
        actionBar.setTitle("Weight Progress");

        // Typecasting
        db = new DatabaseHelper(this);
        mChart = findViewById(R.id.piechart);
        goalWeight = findViewById(R.id.textview19);
        currentWeight = findViewById(R.id.textView15);
        weightLoss = findViewById(R.id.textView16);
        sw = findViewById(R.id.switch7);

        // Sets logged in username
        user = Login.loggedInUser;

        // Sets labels to database values
        setInfo();

        // Adds Current Weight and Weight Left to the pie chart
        List<String> values = new ArrayList<>();
        values.add("Current Weight");
        values.add("Weight Left");

        // Adds records to the pie chart
        PieDataSet dataSet = new PieDataSet(entries, "");
        PieData data = new PieData(values, dataSet);

        // Sets pie chart properties
        dataSet.setColors(new int[]{Color.parseColor("#43b552"),
                Color.parseColor("#fc5a03")});
        dataSet.setSliceSpace(0f);
        dataSet.setValueTextSize(0f);
        mChart.setHoleColor(Color.parseColor("#d3d6db"));
        mChart.setUsePercentValues(true);
        mChart.setDrawHoleEnabled(true);
        mChart.setData(data);
        mChart.setDescription("");
        mChart.setTouchEnabled(false);
        mChart.invalidate();

        // Switch on click listener
        sw.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                // Convert units to imperial / metric
                try {

                    // Temporary variables
                    int weight = 0;
                    int targetWeight = 0;

                    // Gets data from the database
                    Cursor cursor = db.allData(user);
                    if (cursor.getCount() != 0) {
                        while(cursor.moveToNext()) {
                            weight = Integer.parseInt(cursor.getString(4));
                            targetWeight = Integer.parseInt(cursor.getString(8));
                        }
                    }

                    // Gets values in imperial units
                    if (sw.isChecked() == true) {

                        try {
                            Double tw = Double.valueOf(targetWeight);
                            tw = Math.round((2.2046 * tw) * 100.0) / 100.0;
                            goalWeight.setText(tw.toString() + " lb");

                            Double w = Double.valueOf(weight);
                            w = Math.round((2.2046 * w) * 100.0) / 100.0;
                            currentWeight.setText("Current Weight: " + w.toString() + " lb");

                            if (weight - targetWeight <= 0) {
                                weightLoss.setText("Weight Left: 0 lb");
                            }
                            else {
                                weightLoss.setText("Weight Left: " + String.valueOf((Math.round((w - tw) * 100.0) / 100.0) + " lb"));
                            }

                        } catch(Exception e) {
                            // if values are invalid, then do not convert units
                        }

                    }
                    // Gets values in metric units
                    else {

                        goalWeight.setText(String.valueOf(targetWeight) + " kg");
                        currentWeight.setText("Current Weight: " + String.valueOf(weight) + " kg");
                        if (weight - targetWeight <= 0) {
                            weightLoss.setText("Weight Left: 0 kg");
                        }
                        else {
                            weightLoss.setText("Weight Left: " + String.valueOf(weight - targetWeight) + " kg");
                        }

                    }

                } catch (Exception e) {
                    // Do not convert units if values are invalid
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

    // Sets label text
    public void setInfo() {

        try {

            // Temporary variables
            int weight = 0;
            int targetWeight = 0;

            // Gets data
            Cursor cursor = db.allData(user);
            if (cursor.getCount()==0) {
                Toast.makeText(this, "No Data Found!", Toast.LENGTH_SHORT).show();
            }
            else {
                while(cursor.moveToNext()) {
                    weight = Integer.parseInt(cursor.getString(4));
                    targetWeight = Integer.parseInt(cursor.getString(8));
                }
            }

            // Sets labels to values from the database
            goalWeight.setText(String.valueOf(targetWeight) + " kg");
            currentWeight.setText("Current Weight: " + String.valueOf(weight) + " kg");

            // If weight left is less than 0, then display 0 kg
            if (weight - targetWeight <= 0) {
                weightLoss.setText("Weight Left: 0 kg");
            }
            // If weight left is greater than 0, then display the value
            else {
                weightLoss.setText("Weight Left: " + String.valueOf(weight - targetWeight) + " kg");
            }

            // Add the entries to the pie chart
            entries.add(new Entry(targetWeight, 0));

            // Add weight left value to the pie chart
            if (weight - targetWeight > 0){
                entries.add(new Entry(weight - targetWeight, 0));
            }

        // If target weight and weight is not set, then display an error message
        } catch (Exception e) {

            Toast.makeText(this, "Please set target and current weight on the profile page.", Toast.LENGTH_SHORT).show();

        }

    }

    @Override
    protected void onResume() {
        super.onResume();

        // Refreshes the logged in username
        user = Login.loggedInUser;
    }
}
