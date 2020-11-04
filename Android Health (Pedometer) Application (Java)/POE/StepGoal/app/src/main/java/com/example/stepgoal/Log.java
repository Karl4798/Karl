package com.example.stepgoal;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.database.Cursor;
import android.graphics.Color;
import android.os.Bundle;
import android.widget.TextView;
import android.widget.Toast;

import com.github.mikephil.charting.charts.BarChart;
import com.github.mikephil.charting.data.BarData;
import com.github.mikephil.charting.data.BarDataSet;
import com.github.mikephil.charting.data.BarEntry;
import java.util.ArrayList;

public class Log extends AppCompatActivity {

    // Variables
    BarChart barChart;
    DatabaseHelper db;
    TextView stepGoal;

    // Stores logged in username
    static String user = null;

    ArrayList<String> dates = new ArrayList<>();
    ArrayList<BarEntry> barEntries = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_log);

        // Gets logged in username
        user = Login.loggedInUser;

        // Sets activity name
        ActionBar actionBar = getSupportActionBar();
        actionBar.setTitle("Fitness Log");

        // Variables
        db = new DatabaseHelper(this);
        barChart = findViewById(R.id.bargraph1);
        stepGoal = findViewById(R.id.stepGoal5);

        barChart.setTouchEnabled(true);
        barChart.setDragEnabled(true);
        barChart.setScaleEnabled(true);
        barChart.setDescription("");
        barChart.getAxisRight().setDrawLabels(false);

        setStepGoalLabel();

    }

    public void setStepGoalLabel() {

        // Sets label to logged in user goal
        Cursor cursor = db.allData(user);
        if (cursor.getCount()==0) {
            Toast.makeText(this, "No Step Goal Set!", Toast.LENGTH_SHORT).show();
        }
        else {
            while(cursor.moveToNext()) {
                stepGoal.setText("Goal: " + cursor.getString(7));
            }
        }

    }

    @Override
    protected void onResume() {
        super.onResume();

        // Sets variables
        user = Login.loggedInUser;
        dates.clear();
        barEntries.clear();
        barChart.clear();
        setStepGoalLabel();

        int indexes = 0;

        // Gets step count bar graph
        Cursor cursor = db.stepCountRecords(user);
        if (cursor.getCount()==0) {
            Toast.makeText(this, "No Data Found! Save a step count to view progress.", Toast.LENGTH_SHORT).show();
        }
        else {
            while(cursor.moveToNext()) {
                dates.add(cursor.getString(1));
                barEntries.add(new BarEntry(Float.valueOf(cursor.getString(2)), indexes));
                indexes++;
            }
        }

        // Adds all values to the bar graph
        BarDataSet barDataSet = new BarDataSet(barEntries, "Steps");
        barDataSet.setColor(Color.parseColor("#43b552"));
        BarData theData = new BarData(dates, barDataSet);
        barChart.setData(theData);

        barChart.setVisibleXRangeMaximum(4);

    }
}
