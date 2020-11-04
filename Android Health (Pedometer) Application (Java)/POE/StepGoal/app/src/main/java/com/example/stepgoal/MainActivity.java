package com.example.stepgoal;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.graphics.Color;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;

import androidx.appcompat.app.ActionBar;
import androidx.core.view.GravityCompat;
import androidx.appcompat.app.ActionBarDrawerToggle;
import android.view.MenuItem;
import com.google.android.material.navigation.NavigationView;
import androidx.drawerlayout.widget.DrawerLayout;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import android.view.Menu;
import android.widget.Button;
import android.widget.ProgressBar;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.util.Date;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener, SensorEventListener {

    // Control variables
    SensorManager sensorManager;
    TextView tv_steps;
    boolean running = false;
    ProgressBar progressBar;
    int progress;
    DatabaseHelper db;
    TextView stepCountGoal;
    TextView distance;
    Button saveStepCount;
    Switch switch4;

    // Variables
    static String stepGoal;
    static String user = Login.loggedInUser;
    static String stepDistance;
    static String height;
    static String distanceTravelled;

    public static final String SHARED_PREFS = "sharedPrefs";
    public static final String STEPCOUNT = "steps";

    private String steps;

    private int firstRun = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        DrawerLayout drawer = findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
            this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.addDrawerListener(toggle);
        toggle.syncState();

        // Sets home screen state
        setHomeScreen();

        // Save button method
        saveStepCount.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                // Saves step count if its greater than 0
                if (progress > 0) {

                    // Confirm dialog
                    AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                    builder.setTitle("Save");
                    builder.setMessage("Save Step Count Record?");
                    builder.setCancelable(false);
                    builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            Date cDate = new Date();
                            String fDate = new SimpleDateFormat("yyyy-MM-dd").format(cDate);
                            boolean saved = db.insertStepCount(user, fDate, String.valueOf(progress));
                            if (saved == false) {
                                Toast.makeText(MainActivity.this, "Could Not Save Record!", Toast.LENGTH_SHORT).show();
                            }
                            else {
                                resetSteps();
                            }
                        }
                    });

                    builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            Toast.makeText(getApplicationContext(), "Current Record Has Not Been Saved.", Toast.LENGTH_SHORT).show();
                        }
                    });

                    builder.show();

                }
                // If the step count is less than 0, then display a message
                else {
                    Toast.makeText(MainActivity.this, "Step Count Must Be Greater Than 0!", Toast.LENGTH_SHORT).show();
                }

            }
        });

        switch4.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Toast.makeText(MainActivity.this, "Units will change once step count increments.", Toast.LENGTH_SHORT).show();
            }
        });

        // Always runs the onClick event when the user checks the switch button
        switch4.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View view, MotionEvent motionEvent) {
                return motionEvent.getActionMasked() == motionEvent.ACTION_MOVE;
            }
        });

    }

    public void setHomeScreen() {

        // Variables
        NavigationView navigationView = findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);
        db = new DatabaseHelper(this);
        tv_steps = findViewById(R.id.tv_steps);
        sensorManager = (SensorManager) getSystemService(Context.SENSOR_SERVICE);
        progressBar = findViewById(R.id.progressBar);
        stepCountGoal = findViewById(R.id.stepCountGoal);
        distance = findViewById(R.id.distance);
        saveStepCount = findViewById(R.id.saveStepCount);
        switch4 = findViewById(R.id.switch4);

        View headerView = navigationView.getHeaderView(0);
        TextView navUser = headerView.findViewById(R.id.name);

        // Sets action bar name
        ActionBar actionBar = getSupportActionBar();
        actionBar.setTitle("Step Counter");

        // Gets data records from the database
        Cursor cursor = db.allData(user);
        if (cursor.getCount()==0) {
            Toast.makeText(this, "No Data Found!", Toast.LENGTH_SHORT).show();
        }
        else {
            while(cursor.moveToNext()) {
                navUser.setText("Hello " + cursor.getString(2) + "!");
                if (String.valueOf(cursor.getString(2)).equals("null")) {
                    navUser.setText("Hello New User");
                }
                height = cursor.getString(5);
                stepGoal = cursor.getString(7);
            }
            try {
                stepDistance = String.valueOf(Double.valueOf(height) * 0.414);
            } catch (Exception e) {
                // Do not calculate step distance if height not found
            }

        }

        int steps = Integer.valueOf(stepGoal);
        progressBar.setMax(steps);
        stepCountGoal.setText("Goal: " + stepGoal);
    }

    @Override
    protected void onResume() {
        super.onResume();

        // Gets logged in username
        user = Login.loggedInUser;
        setHomeScreen();

        // Registers the step counter
        running = true;
        Sensor countSensor = sensorManager.getDefaultSensor(Sensor.TYPE_STEP_COUNTER);
        if (countSensor != null) {
            sensorManager.registerListener(this, countSensor, SensorManager.SENSOR_DELAY_UI);
        }
        else {
            Toast.makeText(this, "Sensor not found!", Toast.LENGTH_SHORT).show();
        }

    }

    @Override
    protected void onPause() {
        super.onPause();

        // Continue counting steps even when the display is off or the application shuts down
        running = true;
    }

    @Override
    public void onBackPressed() {

        DrawerLayout drawer = findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }

    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        // Nav drawer activity navigation
        if (id == R.id.nav_home) {
            Intent intent = new Intent(this, MainActivity.class);
            startActivity(intent);
        } else if (id == R.id.nav_goals) {
            Intent intent = new Intent(this, Goals.class);
            startActivity(intent);
        } else if (id == R.id.nav_log) {
            Intent intent = new Intent(this, Log.class);
            startActivity(intent);
        } else if (id == R.id.nav_bmi) {
            Intent intent = new Intent(this, Bmi.class);
            startActivity(intent);
        } else if (id == R.id.nav_personal) {
            Intent intent = new Intent(this, PersonalInformation.class);
            startActivity(intent);
        }
        else if (id == R.id.nav_logout) {
            Intent intent = new Intent(this, Login.class);
            startActivity(intent);
            finishAffinity();
        }
        else if (id == R.id.nav_clearCount) {
            resetSteps();
        }
        else if (id == R.id.nav_weight) {
            Intent intent = new Intent(this, WeightMonitoring.class);
            startActivity(intent);
        }
        else if (id == R.id.nav_picture) {
            Intent intent = new Intent(this, Photos.class);
            startActivity(intent);
        }

        DrawerLayout drawer = findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }

    public void resetSteps() {

        // Resets step count and distance travelled
        this.getSharedPreferences(STEPCOUNT, 0).edit().clear().commit();
        SharedPreferences sharedPreferences = getSharedPreferences(SHARED_PREFS, MODE_PRIVATE);
        SharedPreferences.Editor editor = sharedPreferences.edit();
        editor.remove(STEPCOUNT);
        editor.apply();
        tv_steps.setText("0");
        firstRun = 0;
        progressBar.setProgress(0);
        distance.setText("0.00 km");
        progress = 0;
        distanceTravelled = "0.00";
        finish();
        Intent starterIntent = getIntent();
        startActivity(starterIntent);
    }

    @Override
    public void onSensorChanged(SensorEvent sensorEvent) {

        if (running) {

            // Method to save step count to Shared Preferences
            String s = loadData();
            Integer steps = 0;

            // If it is the first time the application has run, then save the current step count
            if (firstRun == 0 && s.equals("")) {
                saveData(String.valueOf((int)Math.round(sensorEvent.values[0])));
            }
            firstRun++;

            // Calculate the step count
            try {
                steps = (int)Math.round(sensorEvent.values[0]) - Integer.valueOf(s);
            } catch(Exception e) {
                // If shared preferences data is invalid, then do not calculate the step count
            }

            // Calculates the distance travelled
            try {

                // Calculates it in miles
                if (switch4.isChecked() == true) {

                    Double d = (steps * Double.valueOf(stepDistance)) / 160934.4;
                    d = Math.round(d * 100.0) / 100.0;

                    if (d > 0) {
                        String dist = d.toString();
                        distanceTravelled = dist;
                        distance.setText(dist + " mi");
                    }

                }
                // Calculates it in kilometers
                else {

                    Double d = (steps * Double.valueOf(stepDistance)) / 100000;
                    d = Math.round(d * 100.0) / 100.0;

                    if (d > 0) {
                        String dist = d.toString();
                        distanceTravelled = dist;
                        distance.setText(dist + " km");
                    }

                }

            } catch(Exception e) {
                // If it cannot calculate the distance travelled, then output default values
            }

            // Sets label text
            tv_steps.setText(String.valueOf(steps));
            progress = Integer.valueOf(steps);
            progressBar.setProgress(progress);

            // Sets progress bar color based on step count goal
            if (steps >= Integer.valueOf(stepGoal)) {
                progressBar.getProgressDrawable().setColorFilter(
                        Color.parseColor("#43b552"), android.graphics.PorterDuff.Mode.SRC_IN);
            }
            else {
                progressBar.getProgressDrawable().setColorFilter(
                        Color.parseColor("#007DD6"), android.graphics.PorterDuff.Mode.SRC_IN);
            }

        }

    }

    @Override
    public void onAccuracyChanged(Sensor sensor, int i) {

    }

    // Saves data to shared preferences
    public void saveData(String steps) {

        // Saves step count to shared preferences
        SharedPreferences sharedPreferences = getSharedPreferences(SHARED_PREFS, MODE_PRIVATE);
        SharedPreferences.Editor editor = sharedPreferences.edit();
        editor.putString(STEPCOUNT, steps);
        editor.apply();
    }

    // Retrieves data from shared preferences
    public String loadData() {

        // Loads data from shared preferences
        SharedPreferences sharedPreferences = getSharedPreferences(SHARED_PREFS, MODE_PRIVATE);
        steps = sharedPreferences.getString(STEPCOUNT, "");

        return steps;

    }

}
