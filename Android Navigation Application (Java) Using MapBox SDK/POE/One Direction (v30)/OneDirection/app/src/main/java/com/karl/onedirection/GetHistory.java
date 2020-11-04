package com.karl.onedirection;

// Required imports
import android.annotation.SuppressLint;
import android.app.Dialog;
import android.content.Context;
import android.database.Cursor;
import android.location.Geocoder;
import android.os.AsyncTask;
import android.os.Handler;
import android.os.Looper;
import android.view.Gravity;
import android.view.View;
import android.widget.ProgressBar;
import android.widget.Toast;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.firestore.GeoPoint;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Locale;

class GetHistory extends AsyncTask<Void, Void, Void> {

    // Variables used to store UI elements
    private Dialog myDialog;
    @SuppressLint("StaticFieldLeak")
    private ProgressBar progressBarH;

    // Variable used to store MainActivity Context
    @SuppressLint("StaticFieldLeak")
    private Context context;

    public GetHistory(Context context, Dialog myDialog, ProgressBar progressBarH) {
        super();

        // Sets variables
        this.myDialog = myDialog;
        this.progressBarH = progressBarH;
        this.context = context;
    }

    // Firebase Authentication variables - used to retrieve and save user information
    FirebaseAuth FAuth;
    private Geocoder geocoder;
    public static String userID;

    // SQL Lite database helper variable
    DatabaseHelper db;

    // Retrieve trip logs in the background
    @Override
    protected Void doInBackground(Void... voids) {

        // Gets the current Firebase authentication and Firestore instances
        FAuth = FirebaseAuth.getInstance();

        // Gets the database helper instance
        db = new DatabaseHelper(context);

        // Sets the userID variable equal to the currently logged in UID from Firebase Authentication
        userID = FAuth.getCurrentUser().getUid();

        // Sets the userID variable equal to the currently logged in UID from Firebase Authentication
        userID = FAuth.getCurrentUser().getUid();

        // Gets trip logs from the SQL Lite database - using the DatabaseHelper class
        Cursor cursor = db.getTrips(userID);

        // Use the cursor retrieved from the database to populate the history modal popup
        if (cursor.getCount() != 0) {

            // Lists used to store information retrieved from the database, and use it within the application
            ArrayList<String> datetime = new ArrayList<>();
            ArrayList<String> methods = new ArrayList<>();
            ArrayList<String> originAddresses = new ArrayList<>();
            ArrayList<String> destinationAddresses = new ArrayList<>();

            // While the cursor has new rows, enter the information into the List arrays
            while(cursor.moveToNext()) {

                // Add transit methods to the methods List array
                methods.add(cursor.getString(1));

                // Add the date and time of the trip log to the datetime List array
                datetime.add(cursor.getString(2));

                // Gets the origin addresses from the database
                String[] separated1 = cursor.getString(3).split(",");
                double latitudeE61 = Double.parseDouble(separated1[0]);
                double longitudeE61 = Double.parseDouble(separated1[1]);
                GeoPoint gp1 = new GeoPoint(latitudeE61, longitudeE61);

                // Gets the destination addresses from the database
                String[] separated2 = cursor.getString(4).split(",");
                double latitudeE62 = Double.parseDouble(separated2[0]);
                double longitudeE62 = Double.parseDouble(separated2[1]);
                GeoPoint gp2 = new GeoPoint(latitudeE62, longitudeE62);

                // Default fail-over values
                String originAddress = "Address cannot be found!";
                String destinationAddress = "Address cannot be found!";

                geocoder = new Geocoder(context, Locale.getDefault());
                try {
                    originAddress = geocoder.getFromLocation(
                            gp1.getLatitude(), gp1.getLongitude(), 1)
                            .get(0).getAddressLine(0);
                    destinationAddress = geocoder.getFromLocation(
                            gp2.getLatitude(), gp2.getLongitude(), 1)
                            .get(0).getAddressLine(0);

                    originAddresses.add(originAddress);
                    destinationAddresses.add(destinationAddress);

                } catch (IOException e) {
                    e.printStackTrace();
                }

            }

            // Add identifying information to the recycleView, which is presented on the Route History modal popup
            recycleView(datetime, methods, originAddresses, destinationAddresses);

        }
        else {

            // Update the UI
            new Handler(Looper.getMainLooper()).post(new Runnable(){
                @Override
                public void run() {

                    // Show message showing that there are no previous trips saved
                    Toast toast = Toast.makeText(context,"No trip history found!", Toast.LENGTH_SHORT);
                    toast.setGravity(Gravity.CENTER, 0, 0);
                    toast.show();

                }
            });

        }

        return null;

    }

    // Method used to display all trip logs for the currently logged in user
    public void recycleView(ArrayList<String> keys, ArrayList<String> methods, ArrayList<String> originAddresses, ArrayList<String> destinationAddresses) {

        // Update the UI
        new Handler(Looper.getMainLooper()).post(new Runnable(){
            @Override
            public void run() {

                // Declare and assign a recycler view to display trip logs
                RecyclerView recyclerView;
                recyclerView = myDialog.findViewById(R.id.recyclerView);

                // Pass identifying trip log information into the MyAdapter class
                MyAdapter myAdapter = new MyAdapter(context, keys, methods, originAddresses, destinationAddresses);

                // Sets the recyclerView contents to myAdapter information
                recyclerView.setAdapter(myAdapter);

                // Sets layout of the recyclerView
                recyclerView.setLayoutManager(new LinearLayoutManager(context));
            }
        });

    }

    // can use UI thread here
    protected void onPreExecute() {

        // Set visibility of progress bar to GONE
        progressBarH.setVisibility(View.VISIBLE);

    }

    @Override
    protected void onPostExecute(Void result) {

        // Set visibility of progress bar to GONE
        progressBarH.setVisibility(View.GONE);

    }
}