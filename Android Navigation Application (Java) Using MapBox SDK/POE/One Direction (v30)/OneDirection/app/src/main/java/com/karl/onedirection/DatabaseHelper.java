package com.karl.onedirection;

// Required imports
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import androidx.annotation.Nullable;

import com.mapbox.api.directions.v5.models.DirectionsRoute;
import com.mapbox.mapboxsdk.geometry.LatLng;

// Class used to manage interactions with the SQL Lite database - for the storing of trip JSON objects.
public class DatabaseHelper extends SQLiteOpenHelper {

    private static final String TAG = "DatabaseHelper";

    // Constructor
    public DatabaseHelper(@Nullable Context context) {
        super(context, "database.db", null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {

        // Creates the trips table
        db.execSQL("Create table trips(uid text, method text, date text, tripjson text, originPoint text, destinationPoint text)");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int i, int i1) {
        db.execSQL("Drop table if exists trips");
    }

    // Method used to insert a trip log into the trips table
    public boolean insertTrip(String uid, String method, String datetime, DirectionsRoute tripjson, LatLng originPoint, LatLng destinationPoint) {

        // Gets the database reference
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put("uid", uid);
        contentValues.put("method", method);
        contentValues.put("date", datetime);
        contentValues.put("tripjson", tripjson.toJson());
        contentValues.put("originPoint", originPoint.getLatitude() + "," + originPoint.getLongitude());
        contentValues.put("destinationPoint", destinationPoint.getLatitude() + "," + destinationPoint.getLongitude());
        long ins = db.insert("trips", null, contentValues);
        if (ins==-1) return false;
        else return true;

    }

    // Method used for retrieving trips for the logged in user
    public Cursor getTrips(String uid) {

        // Gets the database reference
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery("Select uid, method, date, originPoint, destinationPoint from trips where uid=? order by date desc", new String[] {uid});
        return cursor;

    }

    // Method used for retrieving a single trip from the database
    public Cursor getTrip(String uid, String date) {

        // Gets the database reference
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery("Select tripjson from trips where uid=? and date=?", new String[] {uid, date});
        return cursor;

    }

    // Method used to delete all trip logs for the passed in UID (User ID)
    public boolean deleteTrips(String uid) {

        try {

            // Gets the database reference
            SQLiteDatabase db = this.getWritableDatabase();
            db.delete("trips", "uid=?", new String[]{uid});
            return true;
        }
        catch (Exception ex) {
            Log.d(TAG, "");
        }
        return false;

    }

}