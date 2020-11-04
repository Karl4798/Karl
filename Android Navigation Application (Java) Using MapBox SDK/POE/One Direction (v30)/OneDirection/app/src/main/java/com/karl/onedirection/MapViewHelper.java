package com.karl.onedirection;

// Required imports
import android.app.Dialog;
import android.graphics.Color;
import android.graphics.drawable.Drawable;
import android.view.View;
import com.mapbox.api.directions.v5.DirectionsCriteria;
import com.mapbox.mapboxsdk.maps.Style;
import java.util.ArrayList;

public class MapViewHelper {

    // Modal popup variable
    public static int cvBackgroundColor;

    // Gets the selected index of the map style spinner
    public int getSelectedIndex(String mapStyle) {

        Integer selectionIndex = null;

        if (mapStyle.equals(Style.MAPBOX_STREETS)) {
            selectionIndex = 0;
        }
        if (mapStyle.equals(Style.TRAFFIC_DAY)) {
            selectionIndex = 1;
        }
        if (mapStyle.equals(Style.DARK)) {
            selectionIndex = 2;
        }
        if (mapStyle.equals(Style.TRAFFIC_NIGHT)) {
            selectionIndex = 3;
        }
        if (mapStyle.equals(Style.LIGHT)) {
            selectionIndex = 4;
        }
        if (mapStyle.equals(Style.OUTDOORS)) {
            selectionIndex = 5;
        }
        if (mapStyle.equals(Style.SATELLITE)) {
            selectionIndex = 6;
        }
        if (mapStyle.equals(Style.SATELLITE_STREETS)) {
            selectionIndex = 7;
        }

        return selectionIndex;

    }

    // Gets the appropriate map style for the passed string value
    public String setMapStyle(String theme) {

        String mapStyle = null;

        if (theme.equals("Streets")) {
            mapStyle = Style.MAPBOX_STREETS;
        }
        if (theme.equals("Traffic Day")) {
            mapStyle = Style.TRAFFIC_DAY;
        }
        if (theme.equals("Dark")) {
            mapStyle = Style.DARK;
        }
        if (theme.equals("Traffic Night")) {
            mapStyle = Style.TRAFFIC_NIGHT;
        }
        if (theme.equals("Light")) {
            mapStyle = Style.LIGHT;
        }
        if (theme.equals("Outdoors")) {
            mapStyle = Style.OUTDOORS;
        }
        if (theme.equals("Satellite")) {
            mapStyle = Style.SATELLITE;
        }
        if (theme.equals("Satellite Streets")) {
            mapStyle = Style.SATELLITE_STREETS;
        }

        return mapStyle;

    }

    // Sets the MapBox variables for use when navigating the user,
    // using the user preferences retrieved for the user
    public String getPreferredMethodOfTransport(String methodOfTransport) {

        String method = null;

        if (methodOfTransport.equals("driving")) {
            method = DirectionsCriteria.PROFILE_DRIVING_TRAFFIC;
        }
        if (methodOfTransport.equals("walking")) {
            method = DirectionsCriteria.PROFILE_WALKING;
        }
        if (methodOfTransport.equals("cycling")) {
            method = DirectionsCriteria.PROFILE_CYCLING;
        }

        return method;

    }

    // Gets the preferred units of measure when the user passes a string value
    public String getPreferredUnitsOfMeasure(String units) {

        String preferredUnits = null;

        if (units.equals("metric")) {
            preferredUnits = DirectionsCriteria.METRIC;
        }
        if (units.equals("imperial")) {
            preferredUnits = DirectionsCriteria.IMPERIAL;
        }

        return preferredUnits;

    }

    // Sets the background color of the modal popups, when the style, color, and dialog objects are passed into the method
    public void setBackgroundColor(View view, String style, int changedViewBackground, Dialog myDialog) {

        // Sets a variable to true if the style is dark mode
        boolean isDarkMode = style.equals(Style.DARK) || style.equals(Style.TRAFFIC_NIGHT);

        // If the dialog is modal popup preferences, then change the color of that specific popup background
        if (changedViewBackground == R.id.modal_preferences) {

            if (isDarkMode) {

                Drawable background = view.getContext().getResources().getDrawable(R.drawable.modal_layout_dark);
                View v1 = myDialog.findViewById(R.id.modal_preferences);
                v1.setBackground(background);

            } else {

                Drawable background = view.getContext().getResources().getDrawable(R.drawable.modal_layout_light);
                View v1 = myDialog.findViewById(R.id.modal_preferences);
                v1.setBackground(background);

            }

        }

        // If the dialog is modal popup about, then change the color of that specific popup background
        if (changedViewBackground == R.id.modal_about) {

            if (isDarkMode) {

                Drawable background = view.getContext().getResources().getDrawable(R.drawable.modal_layout_dark);
                View v2 = myDialog.findViewById(R.id.modal_about);
                v2.setBackground(background);

            } else {

                Drawable background = view.getContext().getResources().getDrawable(R.drawable.modal_layout_light);
                View v2 = myDialog.findViewById(R.id.modal_about);
                v2.setBackground(background);

            }

        }

        // If the dialog is modal popup history, then change the color of that specific popup background
        if (changedViewBackground == R.id.modal_saved_routes) {

            if (isDarkMode) {

                Drawable background = view.getContext().getResources().getDrawable(R.drawable.modal_layout_dark);
                View v3 = myDialog.findViewById(R.id.modal_saved_routes);
                v3.setBackground(background);
                cvBackgroundColor = (Color.parseColor("#9E9E9E"));

            } else {

                Drawable background = view.getContext().getResources().getDrawable(R.drawable.modal_layout_light);
                View v3 = myDialog.findViewById(R.id.modal_saved_routes);
                v3.setBackground(background);
                cvBackgroundColor = (Color.parseColor("#FFFFFF"));

            }

        }

    }

    // Method returns an array, which is used to store all available map themes
    public ArrayList<CustomItem> getSpMapStyleItems() {

        ArrayList<CustomItem> mapThemes = new ArrayList<>();
        mapThemes.add(new CustomItem("Streets", null));
        mapThemes.add(new CustomItem("Traffic Day", null));
        mapThemes.add(new CustomItem("Dark", null));
        mapThemes.add(new CustomItem("Traffic Night", null));
        mapThemes.add(new CustomItem("Light", null));
        mapThemes.add(new CustomItem("Outdoors", null));
        mapThemes.add(new CustomItem("Satellite", null));
        mapThemes.add(new CustomItem("Satellite Streets", null));
        return mapThemes;

    }

    // Method returns an array, which is used to store all available modes of transport
    public ArrayList<CustomItem> getSpModeOfTransportItems() {

        ArrayList<CustomItem> transportMethods = new ArrayList<>();
        transportMethods.add(new CustomItem("Driving", R.drawable.ic_car));
        transportMethods.add(new CustomItem("Walking", R.drawable.ic_walk));
        transportMethods.add(new CustomItem("Cycling", R.drawable.ic_bike));
        return transportMethods;

    }

}
