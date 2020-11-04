package com.example.stepgoal;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class DatabaseHelper extends SQLiteOpenHelper {
    public DatabaseHelper(@Nullable Context context) {
        super(context, "Data.db", null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        // Creates all required tables
        db.execSQL("Create table user(username text primary key, password text, fname text, lname text," +
                "weight text, height text, age text, stepgoal text, targetweight text)");

        db.execSQL("Create table weight(username text, date text, weight text, primary key (username, date))");

        db.execSQL("Create table stepcount(username text, date text, steps text)");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int i, int i1) {
        db.execSQL("Drop table if exists user");
        db.execSQL("Drop table if exists weight");
        db.execSQL("Drop table if exists stepcount");
    }

    // Inserting into the weight table
    public boolean insertWeight(String username, String date, String weight) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put("username", username);
        contentValues.put("date", date);
        contentValues.put("weight", weight);
        long ins = db.insert("weight", null, contentValues);
        if (ins==-1) return false;
        else return true;
    }

    // Inserting into the step count table
    public boolean insertStepCount(String username, String date, String steps) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put("username", username);
        contentValues.put("date", date);
        contentValues.put("steps", steps);
        long ins = db.insert("stepcount", null, contentValues);
        if (ins==-1) return false;
        else return true;
    }

    // Retrieving step count records
    public Cursor stepCountRecords(String user) {
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery("Select * from stepcount where username=? order by date desc", new String[] {user});
        return cursor;
    }

    // Retrieving weight records
    public Cursor weightRecords(String user) {
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery("Select * from weight where username=? order by date desc", new String[] {user});
        return cursor;
    }

    // inserting into the login table
    public boolean insert(String username, String password) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put("username", username);
        contentValues.put("password", password);
        long ins = db.insert("user", null, contentValues);
        if (ins==-1) return false;
        else return true;
    }

    // updating the user profile information
    public boolean insertUserInfo(String user, String fname, String lname, String weight, String height, String age) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put("fname", fname);
        contentValues.put("lname", lname);
        contentValues.put("weight", weight);
        contentValues.put("height", height);
        contentValues.put("age", age);
        long ins = db.update("user", contentValues, "username=?", new String[] {user});
        if (ins==-1) return false;
        else return true;
    }

    // updating the user goal information
    public boolean insertGoals(String user, String stepgoal, String targetweight) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put("stepgoal", stepgoal);
        contentValues.put("targetweight", targetweight);
        long ins = db.update("user", contentValues, "username=?", new String[] {user});
        if (ins==-1) return false;
        else return true;
    }

    // Retrieving user profile information
    public Cursor allData(String user) {
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery("Select * from user where username=?", new String[] {user});
        return cursor;
    }

    // Checking if username is already in use (login table)
    public boolean checkUsername(String username) {
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.rawQuery("Select * from user where username=?", new String[] {username});
        if (cursor.getCount()>0) return false;
        else return true;
    }

    // Checking the username and password (login table)
    public boolean usernamePassword(String username, String password) {
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.rawQuery("Select * from user where username=? and password=?", new String[]{username, password});
        if (cursor.getCount()>0) return true;
        else return false;
    }

}