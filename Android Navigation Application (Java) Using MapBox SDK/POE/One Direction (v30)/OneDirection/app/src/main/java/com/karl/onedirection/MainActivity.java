package com.karl.onedirection;

// Required imports
import android.animation.Animator;
import android.animation.AnimatorListenerAdapter;
import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.net.Uri;
import android.os.Bundle;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.coordinatorlayout.widget.CoordinatorLayout;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ProgressBar;
import android.widget.Spinner;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;
import com.androidadvance.topsnackbar.TSnackbar;
import com.getbase.floatingactionbutton.FloatingActionButton;
import com.getbase.floatingactionbutton.FloatingActionsMenu;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthCredential;
import com.google.firebase.auth.EmailAuthProvider;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.EventListener;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.FirebaseFirestoreException;
import com.mapbox.android.core.permissions.PermissionsListener;
import com.mapbox.android.core.permissions.PermissionsManager;
import com.mapbox.api.directions.v5.DirectionsCriteria;
import com.mapbox.api.directions.v5.models.DirectionsResponse;
import com.mapbox.api.directions.v5.models.DirectionsRoute;
import com.mapbox.api.geocoding.v5.GeocodingCriteria;
import com.mapbox.api.geocoding.v5.models.CarmenFeature;
import com.mapbox.geojson.Feature;
import com.mapbox.geojson.FeatureCollection;
import com.mapbox.geojson.Point;
import com.mapbox.mapboxsdk.Mapbox;
import com.mapbox.mapboxsdk.camera.CameraPosition;
import com.mapbox.mapboxsdk.camera.CameraUpdateFactory;
import com.mapbox.mapboxsdk.geometry.LatLng;
import com.mapbox.mapboxsdk.location.LocationComponent;
import com.mapbox.mapboxsdk.location.LocationComponentActivationOptions;
import com.mapbox.mapboxsdk.location.modes.CameraMode;
import com.mapbox.mapboxsdk.location.modes.RenderMode;
import com.mapbox.mapboxsdk.maps.MapView;
import com.mapbox.mapboxsdk.maps.MapboxMap;
import com.mapbox.mapboxsdk.maps.OnMapReadyCallback;
import com.mapbox.mapboxsdk.maps.Style;
import com.mapbox.mapboxsdk.plugins.places.autocomplete.PlaceAutocomplete;
import com.mapbox.mapboxsdk.plugins.places.autocomplete.model.PlaceOptions;
import com.mapbox.mapboxsdk.style.layers.SymbolLayer;
import com.mapbox.mapboxsdk.style.sources.GeoJsonSource;
import com.mapbox.services.android.navigation.ui.v5.NavigationLauncher;
import com.mapbox.services.android.navigation.ui.v5.NavigationLauncherOptions;
import com.mapbox.services.android.navigation.ui.v5.route.NavigationMapRoute;
import com.mapbox.services.android.navigation.v5.navigation.NavigationRoute;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Locale;
import java.util.concurrent.TimeUnit;
import javax.annotation.Nullable;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import static com.mapbox.mapboxsdk.style.layers.PropertyFactory.iconAllowOverlap;
import static com.mapbox.mapboxsdk.style.layers.PropertyFactory.iconIgnorePlacement;
import static com.mapbox.mapboxsdk.style.layers.PropertyFactory.iconImage;
import static com.mapbox.mapboxsdk.style.layers.PropertyFactory.iconOffset;

public class MainActivity extends AppCompatActivity implements
        OnMapReadyCallback, MapboxMap.OnMapClickListener,
        PermissionsListener, AdapterView.OnItemSelectedListener {

    // Variables used for adding location layer
    public MapView mapView;
    public MapboxMap mapboxMap;

    // Variables used for determining GPS location permissions
    private PermissionsManager permissionsManager;

    // Variables used for calculating and drawing a route
    public DirectionsRoute currentRoute;
    private static final String TAG = "MainActivity";
    public NavigationMapRoute navigationMapRoute;

    // Variables required to initialize navigation
    public Button startButton;
    private static Point originPoint, destinationPoint;
    private GeoJsonSource source;
    private LocationComponent locationComponent;
    private Double tripDistance;
    private long tripDuration;

    // Variables used for styling
    private String geojsonSourceLayerId = "geojsonSourceLayerId";
    private String symbolIconId = "symbolIconId";

    // Variables used to store user preferences
    public static String preferredUnits, fullName, userID, method, mapStyle;

    // Variable used to store current position of the user
    private static LatLng currentPosition;

    // Floating Action Button (FAB) used for showing the menu
    FloatingActionsMenu floatingActionsMenu;

    // Floating Action Button (FAB) used for search button and exit buttons
    com.google.android.material.floatingactionbutton.FloatingActionButton floatingActionSearch, floatingActionExit;

    // Firebase Authentication variables - used to retrieve and save user information
    FirebaseAuth FAuth;
    FirebaseFirestore FStore;

    // Preferences dialog variable - modal popup
    Dialog myDialog;

    // Modal popup variables
    TextView txtClose, linkButton;
    Button save, deleteAccountBtn, deleteHistoryBtn;
    EditText fullNameEd, phoneNumber;
    Spinner spModeOfTransport;
    Spinner spMapStyle;
    Switch unitsSw;
    Boolean isEnabled = true, sendLocation = false;
    String latitude, longitude;
    ArrayList<CustomItem> transportMethods;
    ArrayList<CustomItem> mapThemes;
    ProgressBar progressBarH;

    int width = 700;
    static String tempMethodVariable;
    static String tempMapTheme;

    // Video link for "We Still Love Your Music" - About page button
    Uri oneDirectionUri = Uri.parse("https://www.youtube.com/watch?v=t7CHfqg0wd8");

    // Progress bar variable - displayed during asynchronous events
    ProgressBar progressBar;

    // Snackbar used to display navigational information
    TSnackbar snackbar = null;

    // SQL Lite Database Helper variable
    // I have not used Firestore for saving trips, as trip log JSON records are larger than 1 mb - which is a limitation in Firestore.
    DatabaseHelper db;

    // Create a variable to hold an instance of MapViewHelper class - used to set map and user variables
    MapViewHelper mvh;

    // If the user selects "Confirm" button, then delete the user account will be deleted, along with preferences and trip history
    // Exception handling
    FirebaseUser user = FirebaseAuth.getInstance().getCurrentUser();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        // Gets the MapBox Access Token from the strings.xml file
        Mapbox.getInstance(this, getString(R.string.map_box_access_token));
        setContentView(R.layout.activity_main);

        // Creates an instance of the DatabaseHelper class - for use of the SQL Lite database
        db = new DatabaseHelper(this);

        // Create a new instance of the MapViewHelper class
        mvh = new MapViewHelper();

        // Setting variables to visual elements (FABs, progress bars, buttons, etc)
        floatingActionsMenu = findViewById(R.id.floatingActionsMenu);
        progressBar = findViewById(R.id.progressBar4);
        mapView = findViewById(R.id.mapView);
        startButton = findViewById(R.id.startButton);
        phoneNumber = findViewById(R.id.edPhoneNumber);

        // onCreate methods
        mapView.onCreate(savedInstanceState);
        mapView.getMapAsync(this);

        // Assign the floatingActionSearch button to its visual element
        floatingActionSearch = findViewById(R.id.floatingActionSearch);

        // Assign the floatingActionExit button to its visual element
        floatingActionExit = findViewById(R.id.floatingActionExit);

        // Creating a new instance of a dialog
        myDialog = new Dialog(this);

        // Gets the current Firebase authentication and Firestore instances
        FAuth = FirebaseAuth.getInstance();
        FStore = FirebaseFirestore.getInstance();

        // Sets the userID variable equal to the currently logged in UID from Firebase Authentication
        userID = FAuth.getCurrentUser().getUid();

        // Gets user preferences from Firestore for the currently logged in user, using their UID
        DocumentReference documentReference = FStore.collection("users").document(userID);
        documentReference.addSnapshotListener(this, new EventListener<DocumentSnapshot>() {

            @SuppressLint("LogNotTimber")
            @Override
            public void onEvent(@Nullable DocumentSnapshot documentSnapshot, @Nullable FirebaseFirestoreException e) {

                if (e !=null) {
                    Log.d(TAG,"Error: " + e.getMessage());
                }
                else {

                    // Exception handling for parsing
                    try {

                        // Gets the units (Imperial or Metric) from the database,
                        // and also the preferred method of transport from the database
                        String units = documentSnapshot.getString("units");
                        String methodOfTransport = documentSnapshot.getString("method");

                        // Sets the MapBox variables for use when navigating the user,
                        // using the user preferences retrieved for the user
                        preferredUnits = mvh.getPreferredUnitsOfMeasure(units);
                        method = mvh.getPreferredMethodOfTransport(methodOfTransport);

                        // Gets the full name of the logged in user, and stores it in the fullName variable
                        fullName = documentSnapshot.getString("fName");

                        // Gets preferred map style
                        mapStyle = documentSnapshot.getString("mapStyle");

                    }

                    // If values cannot be retrieved from the database and parsed, then log the error
                    catch (Exception ex) {

                        Log.d(TAG, "Error: " + ex.getMessage());

                    }

                }

            }

        });

        // Search floating action button press event handler
        floatingActionSearch.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {

                // Navigates the user to a search activity
                Intent intent = searchLocation();
                startActivityForResult(intent, 1);

            }

        });

        // Start Navigation button press event handler
        startButton.setOnClickListener(new View.OnClickListener() {
            @SuppressLint({"RestrictedApi", "SetTextI18n"})
            @Override
            public void onClick(View v) {

                // Collapse the FAB menu
                floatingActionsMenu.collapse();

                // Runs a method which dismisses the Snackbar, if it was previously visible
                dismissSnackbar();

                // If the button was set to send the user's current location, then run the relevant code
                if (sendLocation) {

                    // Set the phoneNumber edit text to visible
                    phoneNumber.setVisibility(View.VISIBLE);

                    // Phone number validation (edit text)
                    if (phoneNumber.getText().length() < 10) {

                        Toast.makeText(MainActivity.this, "Please enter a valid phone number.", Toast.LENGTH_SHORT).show();

                    }

                    // If the phone number is correct, then formulate the message content, and allow the user to send the message from within the application
                    else {

                        // Add the phone number in the data
                        Uri uri = Uri.parse("smsto:" + phoneNumber.getText().toString());

                        // Create an sms intent, which navigates the user to the messages app within One Direction
                        Intent smsSIntent = new Intent(Intent.ACTION_SENDTO, uri);

                        // Add the message at the sms_body extra field
                        smsSIntent.putExtra("sms_body", fullName + " shared their location with you:\n" + "https://maps.google.com/?q=" + latitude + "," + longitude);

                        // Try / Catch used to catch errors that may occur
                        try{

                            // Start the intent
                            startActivity(smsSIntent);

                        // If the message has failed to send, then display an appropriate message, and print the StackTrace of the error
                        } catch (Exception ex) {

                            // Display an error message
                            Toast.makeText(MainActivity.this, "Your sms has failed to send...", Toast.LENGTH_LONG).show();

                            // Print the StackTrace
                            ex.printStackTrace();
                        }

                        // Reset the START NAVIGATION button
                        startButton.setText("START NAVIGATION");

                        // If the startButton was previously enabled, then enable it now
                        if (isEnabled == false) {

                            // Set the background of the button to 'disabled' color - indicating that the user may not select the button
                            startButton.setBackgroundResource(R.drawable.roundbutton_disabled);
                            startButton.setEnabled(false);

                        }
                        else {

                            // Set the background of the button to 'enabled' color - indicating that the user may select the button
                            startButton.setBackgroundResource(R.drawable.roundbutton);
                            startButton.setEnabled(true);

                        }

                        // Set the phoneNumber edit text to GONE
                        phoneNumber.setVisibility(View.GONE);

                        // Reset the text in the edit text
                        phoneNumber.setText("");

                        // Reset the floating action buttons / menu / search button
                        floatingActionsMenu.setVisibility(View.VISIBLE);
                        floatingActionSearch.setVisibility(View.VISIBLE);
                        floatingActionExit.setVisibility(View.GONE);

                        // Reset the startButton action method, so that it can be used to start navigation
                        sendLocation = false;

                    }

                // If the user's intentions were to start navigation, then run the relevant code
                } else {

                    // Try / Catch used to catch scenarios where a route cannot be found
                    try
                    {

                        // Calls a method to retrieve the current location of the user
                        getCurrentLocation();

                        // Calls a method to get the navigation route,
                        // by passing in the origin and destination locations
                        getRoute(originPoint, destinationPoint, false);

                        // Builds the navigation options, by passing the currentRoute in (the complete route from origin to destination)
                        // Certain variables are set, such as shouldSimulateRoute (this simulates the route that one would take, if they decide to use the calculated route)
                        NavigationLauncherOptions options = NavigationLauncherOptions.builder()
                                .directionsRoute(currentRoute)
                                .shouldSimulateRoute(false)
                                .build();

                        // Calls the NavigationLauncher method, to start the navigation process - from the integrated MapBox SDK
                        NavigationLauncher.startNavigation(MainActivity.this, options);

                    }

                    // Catch used to display a warning message if a route could not be found between the current and destination address,
                    // taking into consideration the type of transport
                    catch (Exception e)
                    {
                        // Error message
                        Toast.makeText(MainActivity.this, "Could not find route!", Toast.LENGTH_SHORT).show();
                    }

                    // Try / Catch surrounding saveRoute method - this method saves the route JSON to the SQL Lite database
                    try {

                        // Calls a method which saves the currentRoute to the database - the currentRoute is the complete route from the origin to destination
                        saveRoute(currentRoute);

                    } catch (Exception e) {

                        Toast.makeText(MainActivity.this, "Cannot save route to history!", Toast.LENGTH_SHORT).show();
                        Log.d(TAG, "Could not save route");

                    }

                }

            }

        });

        // Declares and assigns Floating Action Buttons (FABs) - the menu
        FloatingActionButton fabLogout = findViewById(R.id.fab_action1);
        FloatingActionButton fabUserPreferences = findViewById(R.id.fab_action2);
        FloatingActionButton fabRefreshMap = findViewById(R.id.fab_action3);
        FloatingActionButton fabRouteHistory = findViewById(R.id.fab_action4);
        FloatingActionButton fabSendLocation = findViewById(R.id.fab_action5);
        FloatingActionButton fabAbout = findViewById(R.id.fab_action6);

        // Logout floating action button press event handler
        fabLogout.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                // Collapse the FAB menu
                floatingActionsMenu.collapse();

                // Reset "remember me" shared preference to false, and erase shared preference values for email, and hashed password
                removeSharedPrefs();

                // Sign out the user from the Firebase Authentication session
                FirebaseAuth.getInstance().signOut();

                // Navigate the user to the background activity
                Intent i = new Intent(MainActivity.this, LoginActivity.class);
                startActivity(i);

                // Finish method destroys the current activity, so the application is ready for the next user
                finish();

            }

        });

        // Preferences floating action button press event handler
        fabUserPreferences.setOnClickListener(new View.OnClickListener() {
            @SuppressLint("ClickableViewAccessibility")
            @Override
            public void onClick(View view) {

                // Runs a method which dismisses the Snackbar, if it was previously visible
                dismissSnackbar();

                // Collapse the FAB menu
                floatingActionsMenu.collapse();

                // Declare and assign variables for use on the user preferences modal popup
                myDialog.setContentView(R.layout.modal_popup_preferences);
                save = myDialog.findViewById(R.id.saveBtn);
                unitsSw = myDialog.findViewById(R.id.swUnitsPrefs);
                txtClose = myDialog.findViewById(R.id.closeTxt);
                fullNameEd = myDialog.findViewById(R.id.fullNameEd);
                deleteAccountBtn = myDialog.findViewById(R.id.deleteAccountBtn);
                deleteHistoryBtn = myDialog.findViewById(R.id.deleteHistoryBtn);

                mvh.setBackgroundColor(view, mapStyle, R.id.modal_preferences, myDialog);

                // Does not allow the user to drag the switch, as that does not activate the setOnClickListener
                unitsSw.setOnTouchListener(new View.OnTouchListener() {

                    @Override
                    public boolean onTouch(View v, MotionEvent event) {

                        return event.getActionMasked() == MotionEvent.ACTION_MOVE;

                    }

                });

                // Set content on the user preferences popup, using values retrieved from the Firebase Firestore database
                fullNameEd.setText(fullName);

                // Calls methods which set available units, transport methods, and map styles
                addUnits();
                setSpModeOfTransportItems();
                setSpMapStyleItems();

                // Set an onClickListener for the exit button (x)
                txtClose.setOnClickListener(new View.OnClickListener() {

                    @Override
                    public void onClick(View v) {

                        // Dismisses (closes) the modal popup, returning the user to the main activity
                        myDialog.dismiss();

                    }

                });

                // Set an onClickListener for the save button
                save.setOnClickListener(new View.OnClickListener() {

                    @Override
                    public void onClick(View v) {

                        // Set the transport method variable to the selected option on spinner 1
                        if (tempMethodVariable != null) {

                            method = tempMethodVariable;

                        }

                        // Calls a method which sets the selected MapBox style
                        mapStyle = mvh.setMapStyle(tempMapTheme);

                        // Determines the selected units (Imperial or Metric) from the switch
                        if (unitsSw.isChecked()) {

                            // Sets the Units variable to imperial, if the units switch is checked
                            preferredUnits = "imperial";
                        }
                        else {

                            // Sets the Units variable to metric, if the units switch is not checked
                            preferredUnits = "metric";
                        }

                        // Update the database (Firebase Firestore) with the new values input by the user
                        FStore.collection("users").document(userID)
                                .update("fName", fullNameEd.getText().toString(),
                                        "method", method.toLowerCase(),
                                        "units", preferredUnits, "mapStyle", mapStyle);

                        // Navigate the user back to the main activity
                        Intent i = new Intent(MainActivity.this, MainActivity.class);

                        // Destroy the current MainActivity instance, as it is using the old preferences
                        finish();

                        // Remove the transition effects, and start a new MainActivity instance
                        overridePendingTransition( 0, 0);
                        startActivity(i);
                        overridePendingTransition( 0, 0);

                        // Display a message that shows that the user preferences were updated
                        Toast.makeText(MainActivity.this, "Preferences Updated", Toast.LENGTH_SHORT).show();

                        // Dismiss (close) the modal popup
                        myDialog.dismiss();

                    }

                });

                // Set an onClickListener for the delete history button
                deleteHistoryBtn.setOnClickListener(new View.OnClickListener() {

                    @Override
                    public void onClick(View v) {

                        // Build an alert popup message (confirmation)
                        AlertDialog.Builder alert = new AlertDialog.Builder(MainActivity.this, R.style.AlertDialogTheme);
                        alert.setTitle("Delete all saved trips?");
                        alert.setPositiveButton("Confirm", ((dialog, which) -> {

                            // If the user selects "Confirm" button, then delete all the trip history for only that user
                            // Exception handling
                            if (db.deleteTrips(userID)) {

                                // Display confirmation message
                                Toast.makeText(MainActivity.this, "Deleted trip history successfully!", Toast.LENGTH_SHORT).show();
                            }
                            else {

                                // Display error message
                                Toast.makeText(MainActivity.this, "Cannot delete saved trip history!", Toast.LENGTH_SHORT).show();
                            }
                        }));
                        alert.setNegativeButton("Cancel", (dialog, which) -> dialog.cancel());

                        // Shows the confirmation dialog box
                        alert.show();

                    }
                });

                // Set an onClickListener for the delete account button
                deleteAccountBtn.setOnClickListener(new View.OnClickListener() {

                    @Override
                    public void onClick(View v) {

                        // Build an alert popup message (confirmation)
                        AlertDialog.Builder alert = new AlertDialog.Builder(MainActivity.this, R.style.AlertDialogTheme);
                        alert.setTitle("Delete your account and trip history?");
                        alert.setPositiveButton("Confirm", ((dialog, which) -> {

                            // Get shared preferences for the user
                            SharedPreferences preferences = getSharedPreferences("signin", MODE_PRIVATE);
                            String email = preferences.getString("email", "");
                            String password = preferences.getString("password", "");

                            // Re-authenticate the user before deleting the account - Firebase requirement
                            AuthCredential credential = EmailAuthProvider.getCredential(email, password);
                            user.reauthenticate(credential).addOnSuccessListener(new OnSuccessListener<Void>() {
                                @Override
                                public void onSuccess(Void aVoid) {

                                    // Navigate the user to the background activity
                                    Intent intent = new Intent(MainActivity.this, LoginActivity.class);
                                    intent.putExtra("UIDCallback", user.getUid());
                                    intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                    startActivity(intent);

                                }
                            }).addOnFailureListener(new OnFailureListener() {
                                @Override
                                public void onFailure(@NonNull Exception e) {

                                    // Display an error message
                                    Toast.makeText(MainActivity.this, "Failed to re-authenticate the user, and therefore cannot delete the account!" +
                                            "\nPlease log in and delete the account again.", Toast.LENGTH_SHORT).show();

                                }
                            });

                        }));
                        alert.setNegativeButton("Cancel", (dialog, which) -> dialog.cancel());

                        // Shows the confirmation dialog box
                        alert.show();

                    }

                });

                // Sets the background of the FAB area to transparent - a fix that allows the FAB icons to appear in front of the map
                myDialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
                myDialog.show();

            }

        });

        // Refresh Map floating action button press event handler
        fabRefreshMap.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {

                // Runs a method which dismisses the Snackbar, if it was previously visible
                dismissSnackbar();

                // Collapse the FAB menu
                floatingActionsMenu.collapse();

                // Remove progress bar
                progressBar.setVisibility(View.GONE);

                // Calls a method that refreshes the map and MainActivity
                // This method call also disables the Start Navigation button and resets its color to disabled
                refreshMap();

            }
        });

        // Route History floating action button press event handler
        fabRouteHistory.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                // Runs a method which dismisses the Snackbar, if it was previously visible
                dismissSnackbar();

                // Calls a method that refreshes the map and MainActivity
                // This method call also disables the Start Navigation button and resets its color to disabled
                refreshMap();

                // Collapse the FAB menu
                floatingActionsMenu.collapse();

                // Set the content of the modal popup to include all saved routes in the SQL Lite database
                myDialog.setContentView(R.layout.modal_popup_saved_routes);

                // Variable used to store progress bar
                progressBarH = myDialog.findViewById(R.id.progressBarHistory);

                // Set background color
                mvh.setBackgroundColor(view, mapStyle, R.id.modal_saved_routes, myDialog);

                // Variable used to store exit button (x)
                txtClose = myDialog.findViewById(R.id.closeTxt_1);

                // Set an onClickListener for the exit button (x)
                txtClose.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {

                        // Dismisses (closes) the modal popup, returning the user to the main activity
                        myDialog.dismiss();

                    }
                });

                // Runs Async method to retrieve the trips and display them on the recycle view
                new GetHistory(MainActivity.this, myDialog, progressBarH).execute();

                // Sets the background of the FAB area to transparent - a fix that allows the FAB icons to appear in front of the map
                myDialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
                myDialog.show();

            }

        });

        // Share Current Location floating action button press event handler
        fabSendLocation.setOnClickListener(new View.OnClickListener() {

            @SuppressLint("RestrictedApi")
            @Override
            public void onClick(View v) {

                // Runs a method which dismisses the Snackbar, if it was previously visible
                dismissSnackbar();

                // Collapse the FAB menu
                floatingActionsMenu.collapse();

                // Gets the last known location of the user
                refreshUserLoc();

                // Set the phoneNumber edit text to visible, so that users can enter the recipient's cell number
                phoneNumber.animate()
                        .alpha(1f)
                        .setDuration(500)
                        .setListener(new AnimatorListenerAdapter() {
                            @Override
                            public void onAnimationEnd(Animator animation) {
                                phoneNumber.setVisibility(View.VISIBLE);
                            }
                        });

                // Set the action method of the startNavigation button to sendLocation, instead of navigating the user to a specified location
                sendLocation = true;

                // If the startButton was previously enabled, then save it's state so that it can be preserved,
                // and re-enabled after the current user location is sent
                if (startButton.isEnabled() == false) {
                    isEnabled = false;
                }
                else {
                    isEnabled = true;
                }

                // Change the text of the startButton
                startButton.setText("SEND MY LOCATION");

                // Enable the startButton
                startButton.setEnabled(true);

                // Set the background of the button to 'enabled' color - indicating that the user may select the button
                startButton.setBackgroundResource(R.drawable.roundbutton);

                // Set the visibility of the menu FAB and exit / search button
                floatingActionsMenu.setVisibility(View.GONE);
                floatingActionSearch.setVisibility(View.GONE);
                floatingActionExit.animate()
                        .alpha(1f)
                        .setDuration(500)
                        .setListener(new AnimatorListenerAdapter() {
                            @Override
                            public void onAnimationEnd(Animator animation) {
                                floatingActionExit.setVisibility(View.VISIBLE);
                            }
                        });

                // Reset the phoneNumber text
                phoneNumber.setText("");

            }

        });

        // About floating action button press event handler
        fabAbout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                // Collapse the FAB menu
                floatingActionsMenu.collapse();

                // Declare and assign variables for use on the About modal popup
                myDialog.setContentView(R.layout.modal_popup_about);

                mvh.setBackgroundColor(view, mapStyle, R.id.modal_about, myDialog);

                txtClose = myDialog.findViewById(R.id.closeTxt2);
                linkButton = myDialog.findViewById(R.id.tvOneDirectionVideo);

                // Set an onClickListener for the exit button (x)
                txtClose.setOnClickListener(new View.OnClickListener() {

                    @Override
                    public void onClick(View v) {

                        // Dismisses (closes) the modal popup, returning the user to the main activity
                        myDialog.dismiss();

                    }

                });

                // Set an onClickListener for the "Do not click here." editText
                linkButton.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {

                        // Navigates the user to the best song of all time
                        Intent intent = new Intent(Intent.ACTION_VIEW, oneDirectionUri);
                        startActivity(intent);

                    }
                });

                // Sets the background of the FAB area to transparent - a fix that allows the FAB icons to appear in front of the map
                myDialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
                myDialog.show();

            }
        });

        // Exit action button press event handler
        floatingActionExit.setOnClickListener(new View.OnClickListener() {

            @SuppressLint("RestrictedApi")
            @Override
            public void onClick(View v) {

                // Runs a method which dismisses the Snackbar, if it was previously visible
                dismissSnackbar();

                // Check to see if the exit action is valid
                if (sendLocation) {

                    // If the startButton was previously disabled, then retain it's state, and disable the button
                    if (isEnabled == false) {

                        // Disable the startButton
                        startButton.setEnabled(false);

                        // Set the background of the disabled button to indicate that the user cannot activate it's event handler
                        startButton.setBackgroundResource(R.drawable.roundbutton_disabled);
                    }

                    // Reset the startButton text
                    startButton.setText("START NAVIGATION");

                    // Set the phoneNumber edit text to GONE
                    phoneNumber.setVisibility(View.GONE);

                    // Set the action method of the startButton onClickListener to run the navigation code,
                    // and not to send the current location of the user's phone
                    sendLocation = false;

                }

                // Reset the visibility of the menu and exit buttons
                floatingActionExit.setVisibility(View.GONE);
                floatingActionsMenu.setVisibility(View.VISIBLE);
                floatingActionSearch.setVisibility(View.VISIBLE);

            }

        });

    }

    // Method used to dismiss the Snackbar if it's currently visible
    public void dismissSnackbar() {

        // Exception handling
        if (snackbar != null) {

            // Dismiss the snackbar
            snackbar.dismiss();

        }

    }

    // Method used to delete shared preferences for auto-background functionality
    public void removeSharedPrefs() {

        // Deletes the shared preferences values
        SharedPreferences preferences = getSharedPreferences("signin", MODE_PRIVATE);
        SharedPreferences.Editor editor = preferences.edit();
        editor.remove("remember");
        editor.remove("email");
        editor.remove("password");
        editor.apply();

    }

    // Method to refresh the map
    private void refreshMap() {

        refreshUserLoc();

        // Sets the Start Navigation button to disabled (the user must first select a location to start navigation)
        startButton.setEnabled(false);
        startButton.setBackgroundResource(R.drawable.roundbutton_disabled);

    }

    // Refreshes the current user location on the map
    private void refreshUserLoc() {

        // Re-run the onMapReady method - which refreshes the map
        onMapReady(mapboxMap);

        // Resets the currentRoute to null (erases it)
        currentRoute = null;

    }

    // Method used to determine which units to save, from the units switch
    private void addUnits() {

        // Sets the Units variable and switch to the correct value / position
        if (preferredUnits.equals("metric")) {
            unitsSw.setChecked(false);
        }
        if (preferredUnits.equals("imperial")) {
            unitsSw.setChecked(true);
        }

    }

    // Method used to set spinner items for the types of transport
    private void setSpModeOfTransportItems() {

        // Assigns the spModeOfTransport variable to the visual element (XML)
        spModeOfTransport = myDialog.findViewById(R.id.spModeOfTransport);

        // Adds a list of all transport methods to the spinner
        transportMethods = mvh.getSpModeOfTransportItems();

        CustomAdapter adapter = new CustomAdapter(this, transportMethods);
        if (spModeOfTransport != null) {
            spModeOfTransport.setAdapter(adapter);
            spModeOfTransport.setOnItemSelectedListener(this);
        }

        // Sets transport method based on user profile values - sets the selected transport method
        if (method.equals(DirectionsCriteria.PROFILE_DRIVING)) {
            spModeOfTransport.setSelection(0);
        }
        else if (method.equals(DirectionsCriteria.PROFILE_WALKING)) {
            spModeOfTransport.setSelection(1);
        }
        else if (method.equals(DirectionsCriteria.PROFILE_CYCLING)) {
            spModeOfTransport.setSelection(2);
        }

    }

    // Method to handle spinner selection
    @Override
    public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {

        // Switch case used to determine which spinner was selected (preferred units or transport method).
        switch(adapterView.getId()) {

            // In the case that the mode of transport spinner was selected, handle the selection below
            case R.id.spModeOfTransport:

                try {
                    LinearLayout linearLayout = findViewById(R.id.customSpinnerItemLayout);
                    width = linearLayout.getWidth();
                } catch (Exception e) {
                    Log.d(TAG, e.getMessage());
                }
                spModeOfTransport.setDropDownWidth(width);
                CustomItem method = (CustomItem) adapterView.getSelectedItem();
                tempMethodVariable = method.getSpinnerItemName();
                break;

            // In the case that the map style spinner was selected, handle the selection below
            case R.id.spMapStyle:

                try {
                    LinearLayout linearLayout = findViewById(R.id.customSpinnerItemLayout);
                    width = linearLayout.getWidth();
                } catch (Exception e) {
                    Log.d(TAG, e.getMessage());
                }
                spMapStyle.setDropDownWidth(width);
                CustomItem mapTheme = (CustomItem) adapterView.getSelectedItem();
                tempMapTheme = mapTheme.getSpinnerItemName();
                break;

        }

    }

    // Method used to set spinner items for map styles
    private void setSpMapStyleItems() {

        // Assigns the spModeOfTransport variable to the visual element (XML)
        spMapStyle = myDialog.findViewById(R.id.spMapStyle);

        // Runs a method which gets the selected map style
        mapThemes = mvh.getSpMapStyleItems();

        CustomAdapter adapter = new CustomAdapter(this, mapThemes);
        if (spMapStyle != null) {
            spMapStyle.setAdapter(adapter);
            spMapStyle.setOnItemSelectedListener(this);
        }

        spMapStyle.setSelection(mvh.getSelectedIndex(mapStyle));

    }

    // Method called to instantiate the MapBox map, and prepare styling and other preferences
    @Override
    public void onMapReady(@NonNull final MapboxMap mapboxMap) {

        // Technique used to wait for the Firebase Firestore data retrieval process to complete, and then only render the map
        // Gets user preferences from Firestore for the currently logged in user, using their UID
        FStore.collection("users").document(FAuth.getUid()).get().addOnCompleteListener(new OnCompleteListener<DocumentSnapshot>() {
            @Override
            public void onComplete(@NonNull Task<DocumentSnapshot> task) {

                // Document reference used to retrieve information for the logged in user from Firebase Firestore
                DocumentSnapshot documentSnapshot = task.getResult();

                // Gets preferred map style
                mapStyle = documentSnapshot.getString("mapStyle");

                // Sets the style of the map
                mapboxMap.setStyle(new Style.Builder().fromUri(mapStyle), new Style.OnStyleLoaded() {
                    @Override
                    public void onStyleLoaded(@NonNull Style style) {

                        enableLocationComponent(style);
                        addDestinationIconSymbolLayer(style);
                        setUpSource(style);
                        setupLayer(style);

                        if (locationComponent != null) {

                            // Sets the current latitude and longitude of the user
                            latitude = String.valueOf(locationComponent.getLastKnownLocation().getLatitude());
                            longitude = String.valueOf(locationComponent.getLastKnownLocation().getLongitude());

                        }

                        // Enables the onMapClick event listener
                        mapboxMap.addOnMapClickListener(MainActivity.this);

                    }
                });

                // Sets the user's current position on the map
                currentPosition = new LatLng(mapboxMap.getCameraPosition().target.getLatitude(),
                        mapboxMap.getCameraPosition().target.getLongitude());

                // Moves the camera to the new location
                mapboxMap.animateCamera(CameraUpdateFactory.newCameraPosition(
                        new CameraPosition.Builder()
                                .target(currentPosition)
                                .zoom(15)
                                .build()));

                // If there is already a route, remove it
                try
                {
                    navigationMapRoute.removeRoute();
                }
                // If there is no calculated route, then do nothing
                catch (Exception ex) {}

                // Set the MainActivity MapBox map
                MainActivity.this.mapboxMap = mapboxMap;

            }
        });
    }

    // Method used to save routes to the SQL Lite database
    private void saveRoute(DirectionsRoute directionsRoute) {

        // Variable used when determining if the route was saved successfully to the database
        boolean saved;

        // Variable used to store the current date / time of the trip start
        Date cdt = Calendar.getInstance().getTime();
        SimpleDateFormat ft= new SimpleDateFormat("EEE MMM dd HH:mm:ss yyyy");
        String currentDateTime = ft.format(cdt);

        // Variable used to store UID of the current user
        userID = FAuth.getCurrentUser().getUid();

        // Retrieve the origin and destination LatLng
        LatLng originLatLng = new LatLng(originPoint.latitude(), originPoint.longitude());
        LatLng destinationLatLng = new LatLng(destinationPoint.latitude(), destinationPoint.longitude());

        // If the method of transport is driving-traffic then set method equal to "Driving"
        String viewMethod = method;
        if (viewMethod.equals("driving-traffic")) {
            viewMethod = "driving";
        }

        // Save the trip into the database trips table,
        // and return the true / false value to determine if saving the trip was successful
        saved = db.insertTrip(userID, viewMethod, currentDateTime, directionsRoute, originLatLng, destinationLatLng);

        // If the trip was saved successfully, show a suitable message ("The Route Has Been Saved").
        if (saved) {
            Log.d(TAG, "The route has been saved.");
        }
        // If the trip was not saved successfully, show a suitable message ("The Route Cannot Be Saved").
        else {
            Log.d(TAG, "The route cannot be created");
            Toast.makeText(this, "The route cannot be saved!", Toast.LENGTH_SHORT).show();
        }

    }

    // Adds the destination symbol (the red drop arrow)
    private void addDestinationIconSymbolLayer(@NonNull Style loadedMapStyle) {

        // Sets the destination symbol
        loadedMapStyle.addImage("destination-icon-id", BitmapFactory.decodeResource(this.getResources(), R.drawable.mapbox_marker_icon_default));
        GeoJsonSource geoJsonSource = new GeoJsonSource("destination-source-id");
        loadedMapStyle.addSource(geoJsonSource);
        SymbolLayer destinationSymbolLayer = new SymbolLayer("destination-symbol-layer-id", "destination-source-id");
        destinationSymbolLayer.withProperties(
                iconImage("destination-icon-id"),
                iconAllowOverlap(true),
                iconIgnorePlacement(true)
        );

        // Adds the icon layer when ever a destination is selected
        loadedMapStyle.addLayer(destinationSymbolLayer);

    }

    // Method used to handle map clicks
    @SuppressWarnings( {"MissingPermission"})
    @Override
    public boolean onMapClick(@NonNull LatLng point) {

        // Sets the destination point, by obtaining the longitude and latitude of the selected location
        destinationPoint = Point.fromLngLat(point.getLongitude(), point.getLatitude());

        // Sets the style of the destination dropper
        source = mapboxMap.getStyle().getSourceAs("destination-source-id");
        if (source != null) {
            source.setGeoJson(Feature.fromGeometry(destinationPoint));
        }

        // Runs a method which obtains the current user location
        getCurrentLocation();

        // Runs a method that gets the fastest route from the origin to destination address
        getRoute(originPoint, destinationPoint, true);
        return true;

    }

    // Method that retrieves the fastest route between two addresses
    private void getRoute(Point origin, Point destination, boolean showSnackbar) {

        // Asynchronous method call, and therefore a progress bar is presented at the start, until it is completed
        progressBar.setVisibility(View.VISIBLE);

        // Builds the navigation route - the fastest route between two addresses, factoring in method of transport
        NavigationRoute.builder(this)
                .accessToken(Mapbox.getAccessToken())
                .origin(origin)
                .profile(method)
                .destination(destination)
                .voiceUnits(preferredUnits)
                .build()
                .getRoute(new Callback<DirectionsResponse>() {
                    @Override
                    public void onResponse(Call<DirectionsResponse> call, Response<DirectionsResponse> response) {

                        // Gets the generic HTTP info about the response
                        // If the response is null or there are no available routes available, then return and display an appropriate message
                        if (response.body() == null) {
                            Toast.makeText(MainActivity.this, "Cannot calculate route!", Toast.LENGTH_SHORT).show();
                            Log.d(TAG, "No routes found, make sure you set the right user and access token.");
                            progressBar.setVisibility(View.GONE);
                            return;
                        } else if (response.body().routes().size() < 1) {
                            Toast.makeText(MainActivity.this, "No routes can be found to your destination!", Toast.LENGTH_SHORT).show();
                            Log.d(TAG, "No routes found");
                            progressBar.setVisibility(View.GONE);
                            return;
                        }

                        // Sets the currentRoute to the route that has been calculated
                        currentRoute = response.body().routes().get(0);

                        // Remove current routes on the MapBox map
                        if (navigationMapRoute != null) {

                            navigationMapRoute.removeRoute();

                        // If there are no routes on the map, then show the current route that has been calculated
                        } else {

                            navigationMapRoute = new NavigationMapRoute(null, mapView, mapboxMap, R.style.NavigationMapRoute);

                        }

                        // Duration formatting
                        tripDuration = Math.round(response.body().routes().get(0).duration()/60);
                        int timeInMilliseconds = (int)(tripDuration * 60000);
                                @SuppressLint("DefaultLocale")
                                String duration = String.format("%d H %02d Min",
                                TimeUnit.MILLISECONDS.toHours(timeInMilliseconds),
                                TimeUnit.MILLISECONDS.toMinutes(timeInMilliseconds) -
                                        TimeUnit.HOURS.toMinutes(TimeUnit.MILLISECONDS.toHours(timeInMilliseconds)));

                        // Variable used to store either Km or Miles
                        String units;

                        // Calculation for metric units
                        if(preferredUnits.equals("metric"))
                        {
                            tripDistance = Math.round(response.body().routes().get(0).distance()/1000.0*100.0)/100.0;
                            units = " KM";
                        }

                        // Calculation for imperial units
                        else
                        {
                            tripDistance = Math.round(response.body().routes().get(0).distance()/1609.344*100.0)/100.0;
                            units = " Miles";
                        }

                        if (showSnackbar) {

                            String snackBar;

                            if (method.equals("driving-traffic")) {

                                // Generating the output for the Snackbar
                                snackBar = tripDistance + units + "\t\t" + duration + "\t" + "Driving";

                            }
                            else {

                                // Generating the output for the Snackbar
                                snackBar = tripDistance + units + "\t\t" + duration + "\t" + method.substring(0, 1).toUpperCase() + method.substring(1);

                            }

                            // Gets the coordinator layout from the XML - where the Snackbar will be displayed
                            CoordinatorLayout coordinatorLayout;
                            coordinatorLayout = findViewById(R.id.coordinatorLayout);

                            // Generates and shows the Snackbar for 10 seconds
                            snackbar = TSnackbar.make(coordinatorLayout, snackBar, TSnackbar.LENGTH_INDEFINITE).setActionTextColor(getResources().getColor(R.color.pink));
                            snackbar.setAction("Close", view -> {
                                // The Snackbar will close when the Close button is clicked
                            });

                            View snackBarView = snackbar.getView();
                            CoordinatorLayout.LayoutParams params = new CoordinatorLayout.LayoutParams(
                                    CoordinatorLayout.LayoutParams.MATCH_PARENT,
                                    CoordinatorLayout.LayoutParams.WRAP_CONTENT);
                            snackBarView.setLayoutParams(params);
                            snackBarView.setBackgroundColor(getResources().getColor(R.color.colorPrimaryVeryVeryDark));
                            TextView textView = snackBarView.findViewById(com.androidadvance.topsnackbar.R.id.snackbar_text);
                            textView.setTextColor(Color.WHITE);
                            snackbar.show();

                        }

                        // Add the route to the MapBox map
                        navigationMapRoute.addRoute(currentRoute);

                        // Set the start button to enabled, and background to a different color - indicating that the user may start the navigation
                        startButton.setEnabled(true);
                        startButton.setBackgroundResource(R.drawable.roundbutton);

                        // Set the visibility of the progress bar to GONE, as the asynchronous event has completed
                        progressBar.setVisibility(View.GONE);

                    }

                    @Override
                    public void onFailure(Call<DirectionsResponse> call, Throwable throwable) {

                        // Log the failure message, if an error message is thrown
                        Log.e(TAG, "Error: " + throwable.getMessage());
                        progressBar.setVisibility(View.GONE);

                    }
                });
    }

    // Method used to enable the location component - to allow the application to triangulate the current address of the user
    @SuppressLint("WrongConstant")
    @SuppressWarnings( {"MissingPermission"})
    private void enableLocationComponent(@NonNull Style loadedMapStyle) {

        // If the user has allowed the application to access the phone GPS, then allow MapBox to get the location of the user
        if (PermissionsManager.areLocationPermissionsGranted(this)) {

            try {

                // Retrieve the current location from the user's device
                locationComponent = mapboxMap.getLocationComponent();

                locationComponent.activateLocationComponent(
                        LocationComponentActivationOptions.builder(this, loadedMapStyle).build());
                locationComponent.setLocationComponentEnabled(true);

                // Set the map to track the user when they move from their original location
                locationComponent.setCameraMode(CameraMode.TRACKING);

                // Show the compass direction
                locationComponent.setRenderMode(RenderMode.COMPASS);

                // Calls a method to retrieve the current location of the user
                getCurrentLocation();

            } catch(Exception ex) {

                locationComponent = null;
                Toast.makeText(this, "Please enable the location service on your device!", Toast.LENGTH_LONG).show();
                finish();

            }

        }

        // Else if the permission to access the phone's GPS is not granted, then request this access
        else {

            // Requests the current device location from the user
            permissionsManager = new PermissionsManager(this);
            permissionsManager.requestLocationPermissions(this);

        }

    }

    // Gets the current location
    private void getCurrentLocation() {

        // Set the current (last known) position of the user, and store it in currentPosition LatLng variable
        currentPosition = new LatLng(mapboxMap.getLocationComponent().getLastKnownLocation().getLatitude(),
                mapboxMap.getLocationComponent().getLastKnownLocation().getLongitude());

        // Gets the origin point and sets the value of originPoint variable equal to it
        originPoint = Point.fromLngLat(currentPosition.getLongitude(), currentPosition.getLatitude());

    }

    // Method to set style of the map
    private void setUpSource(@NonNull Style loadedMapStyle)
    {

        // Adds the style layer to the map
        loadedMapStyle.addSource(new GeoJsonSource(geojsonSourceLayerId));

    }

    // Method to handle search functionality of the application
    private Intent searchLocation()
    {
        // Gets the current location of the user, in order to narrow down search to local areas
        Point pointOfProximity = Point.fromLngLat(currentPosition.getLongitude(), currentPosition.getLatitude());

        // Creates an intent which displays search functionality
        Intent sendThrough = new PlaceAutocomplete.IntentBuilder()
                .accessToken(Mapbox.getAccessToken())
                .placeOptions(PlaceOptions.builder()
                        .backgroundColor(Color.parseColor("#ffffff"))
                        .hint("Enter Address/Place")
                        .country(Locale.getDefault())
                        .proximity(pointOfProximity)
                        .geocodingTypes(GeocodingCriteria.TYPE_ADDRESS,
                                GeocodingCriteria.TYPE_POI,
                                GeocodingCriteria.TYPE_PLACE)
                        .limit(5)
                        .build(PlaceOptions.MODE_CARDS))
                .build(MainActivity.this);

        // Returns the intent and displays the search page
        return sendThrough;

    }

    // Sets up the symbol layer - the destination drop
    private void setupLayer(@NonNull Style loadedMapStyle)
    {

        // Adds a layer with the drop icon over the destination address
        loadedMapStyle.addLayer(new SymbolLayer("SYMBOL_LAYER_ID", geojsonSourceLayerId).withProperties(
                iconImage(symbolIconId),
                iconOffset(new Float[] {0f, -8f})
        ));

    }

    // Method used to handle searched for destination addresses, which were not selected on the map
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data)
    {

        super.onActivityResult(requestCode, resultCode, data);

        // If the intent was valid, then continue
        if (resultCode == MainActivity.RESULT_OK && requestCode == 1)
        {
            // Gets the location of the chosen search item
            CarmenFeature selectedCarmenFeature = PlaceAutocomplete.getPlace(data);

            // Locates the new destination from the selected search address, and moves the camera to the new destination
            if (mapboxMap != null)
            {
                Style style = mapboxMap.getStyle();
                if (style != null)
                {

                    GeoJsonSource geoJsonSource = style.getSourceAs(geojsonSourceLayerId);
                    if (geoJsonSource != null)
                    {
                        geoJsonSource.setGeoJson(FeatureCollection.fromFeatures(
                                new Feature[] {Feature.fromJson(selectedCarmenFeature.toJson())}));
                    }

                    // Gets the current user location
                    getCurrentLocation();

                    // Gets the destination address
                    destinationPoint = (Point) selectedCarmenFeature.geometry();
                    LatLng destination = new LatLng(destinationPoint.latitude(), destinationPoint.longitude());

                    // Moves the camera to the new location
                    mapboxMap.animateCamera(CameraUpdateFactory.newCameraPosition(
                            new CameraPosition.Builder()
                                    .target(destination)
                                    .zoom(15)
                                    .build()), 2000);

                    source = mapboxMap.getStyle().getSourceAs("destination-source-id");

                    if (source != null)
                    {
                        source.setGeoJson(Feature.fromGeometry(destinationPoint));
                    }

                    // Gets the route to the searched destination
                    getRoute(originPoint, destinationPoint, true);
                }
            }
        }

    }

    // Request device location from the user
    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {

        permissionsManager.onRequestPermissionsResult(requestCode, permissions, grantResults);

    }

    // Determines if the request for GPS use was granted or denied by the user
    @Override
    public void onPermissionResult(boolean granted) {

        // If permission was granted, then enable the location component
        if (granted) {

            enableLocationComponent(mapboxMap.getStyle());

        // Else toast a suitable message and finish the activity
        } else {

            Toast.makeText(this, "Please grant location permission to use this application.", Toast.LENGTH_LONG).show();
            finish();

        }

    }

    @Override
    public void onExplanationNeeded(List<String> permissionsToExplain) {

        Toast.makeText(this, "Please grant location permission to use this application.", Toast.LENGTH_LONG).show();

    }

    // Below are default implementations required to run the application

    @Override
    public void onNothingSelected(AdapterView<?> parent) {
        // Do nothing
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        mapView.onSaveInstanceState(outState);
    }

    @Override
    protected void onStart() {
        super.onStart();
        mapView.onStart();
    }

    @Override
    protected void onResume() {
        super.onResume();
        mapView.onResume();
    }

    @Override
    protected void onPause() {
        super.onPause();
        mapView.onPause();
    }

    @Override
    protected void onStop() {
        super.onStop();
        mapView.onStop();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        mapView.onDestroy();
    }

    @Override
    public void onLowMemory() {
        super.onLowMemory();
        mapView.onLowMemory();
    }

}