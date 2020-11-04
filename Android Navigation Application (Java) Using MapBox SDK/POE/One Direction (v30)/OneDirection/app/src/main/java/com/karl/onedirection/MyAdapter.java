package com.karl.onedirection;

// Required imports
import android.annotation.SuppressLint;
import android.content.Context;
import android.database.Cursor;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;
import com.mapbox.api.directions.v5.models.DirectionsRoute;
import com.mapbox.services.android.navigation.ui.v5.route.NavigationMapRoute;
import java.util.ArrayList;

public class MyAdapter extends RecyclerView.Adapter<MyAdapter.MyViewHolder> {

    // ArrayLists to store routeIds, and transit methods - from the MainActivity
    private ArrayList<String> routeIds;
    private ArrayList<String> transitMethods;
    private ArrayList<String> originAddresses;
    private ArrayList<String> destinationAddresses;
    private DirectionsRoute directionsRoute = null;

    // Variable to hold the context of the MainActivity
    Context context;

    // Variable used for the CardViews in the RecyclerView
    CardView cv;

    // SQL Lite Database Helper variable
    DatabaseHelper db;

    // Constructor
    public MyAdapter(Context con, ArrayList<String> routes, ArrayList<String> methods, ArrayList<String> oAddresses, ArrayList<String> dAddresses) {

        // Creates an instance of the DatabaseHelper class - for use of the SQL Lite database
        db = new DatabaseHelper(con);

        // Sets variables
        context = con;
        routeIds = routes;
        transitMethods = methods;
        originAddresses = oAddresses;
        destinationAddresses = dAddresses;

    }

    @NonNull
    @Override
    public MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        // Inflates the fragment within the RecyclerView
        LayoutInflater inflater = LayoutInflater.from(context);
        View view = inflater.inflate(R.layout.route_history_rows, parent, false);
        cv = view.findViewById(R.id.cardView);
        cv.setBackgroundColor(MapViewHelper.cvBackgroundColor);

        return new MyViewHolder(view);

    }

    @SuppressLint("SetTextI18n")
    @Override
    public void onBindViewHolder(@NonNull MyAdapter.MyViewHolder holder, final int position) {

        // Setting the text views by pulling details from the parallel arrays
        holder.tv1.setText("Transit Method: " + transitMethods.get(position).substring(0, 1).toUpperCase()
                + transitMethods.get(position).substring(1));
        holder.tv2.setText("From: " + originAddresses.get(position));
        holder.tv3.setText("To: " + destinationAddresses.get(position));
        holder.tv4.setText("Date / Time: " + routeIds.get(position));

        // CardView onClick listener - for each of the populated list elements
        cv.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                // Disable the Start Button and change the color to disabled, to indicate that the button cannot be clicked
                ((MainActivity)context).startButton.setEnabled(false);
                ((MainActivity)context).startButton.setBackgroundResource(R.drawable.roundbutton_disabled);

                // If the navigation route is not null, then remove the route
                if (((MainActivity)context).navigationMapRoute != null) {

                    ((MainActivity)context).navigationMapRoute.removeRoute();

                // Draw the route on the map if the navigation route is null
                } else {

                    ((MainActivity)context).navigationMapRoute = new NavigationMapRoute(null,
                            ((MainActivity)context).mapView,
                            ((MainActivity)context).mapboxMap,
                            R.style.NavigationMapRoute);

                }

                // Dismiss (close) the dialog, and display the MainActivity
                ((MainActivity)context).myDialog.dismiss();
                ((MainActivity)context).floatingActionsMenu.collapse();

                // Get the trip UID for the user
                String date = routeIds.get(position);

                // Gets trip logs from the SQL Lite database - using the DatabaseHelper class
                Cursor cursor = db.getTrip(((MainActivity)context).userID, date);

                // Use the cursor retrieved from the database to populate the history modal popup
                if (cursor.getCount() != 0) {

                    // While the cursor has new rows, enter the information into the List arrays
                    while(cursor.moveToNext()) {

                        // Assign the DirectionsRoute variable to the selected route - trip JSON (the DirectionRoute)
                        directionsRoute = (DirectionsRoute.fromJson(cursor.getString(0)));

                    }

                }

                // Check if the directionsRoute is null, if not then display it
                if (directionsRoute != null) {
                    ((MainActivity)context).navigationMapRoute.addRoute(directionsRoute);
                }

            }

        });

    }

    @Override
    public int getItemCount() {

        // Returns the number of items in the array
        return routeIds.size();
    }

    // Class used by RecyclerView to set individual elements in the view
    public class MyViewHolder extends RecyclerView.ViewHolder {

        // Variables to hold elements in the xml file
        TextView tv1;
        TextView tv2;
        TextView tv3;
        TextView tv4;

        // Constructor
        public MyViewHolder(@NonNull View itemView) {

            super(itemView);

            // Sets the text views for each element
            tv1 = itemView.findViewById(R.id.textView1);
            tv2 = itemView.findViewById(R.id.textView2);
            tv3 = itemView.findViewById(R.id.textView3);
            tv4 = itemView.findViewById(R.id.textView4);

        }

    }

}