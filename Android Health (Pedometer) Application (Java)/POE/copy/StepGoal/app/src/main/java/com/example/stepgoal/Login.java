package com.example.stepgoal;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class Login extends AppCompatActivity {

    // Variables
    EditText username, password;
    Button login, register;
    DatabaseHelper db;

    public static String loggedInUser;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        // Assigns variables
        db = new DatabaseHelper(this);
        username = findViewById(R.id.edUsername);
        password = findViewById(R.id.edPassword);
        login = findViewById(R.id.btnLogin);
        register = findViewById(R.id.btnRegister);

        // Login button method
        login.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {
                String user = username.getText().toString();
                String pass = password.getText().toString();
                Boolean checkValidUser = db.usernamePassword(user, pass);
                if (checkValidUser == true) {
                    Toast.makeText(Login.this, "Logged in Successfully!", Toast.LENGTH_SHORT).show();
                    loggedInUser = user;
                    Intent intent = new Intent(Login.this, MainActivity.class);
                    startActivity(intent);
                }
                else {
                    Toast.makeText(Login.this, "Invalid Login details.", Toast.LENGTH_SHORT).show();
                }
            }
        });

    }

    public void regOnClick(View view) {

        // Register button pressed
        Intent intent = new Intent(this, Register.class);
        startActivity(intent);
    }

}
