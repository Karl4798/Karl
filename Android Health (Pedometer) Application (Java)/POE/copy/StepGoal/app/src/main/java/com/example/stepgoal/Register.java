package com.example.stepgoal;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class Register extends AppCompatActivity {

    // Control Variables
    DatabaseHelper db;
    EditText username;
    EditText password;
    EditText confirmPassword;
    Button regButton;

    // Variables
    public static String user;
    public static String pass;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);
        db = new DatabaseHelper(this);
        username = findViewById(R.id.edUsername);
        password = findViewById(R.id.edPassword);
        confirmPassword = findViewById(R.id.edConfirmPassword);
        regButton = findViewById(R.id.btnRegister);

        // Register button method
        regButton.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {
                String user = username.getText().toString();
                String pass = password.getText().toString();
                String confirmPass = confirmPassword.getText().toString();

                // Validation
                if (user.equals("") || pass.equals("") || confirmPass.equals("")) {
                    Toast.makeText(Register.this, "Fields are empty!", Toast.LENGTH_SHORT).show();
                }
                else {

                    // Saves username and password to static variables and directs the user to enter personal information
                    if (pass.equals(confirmPass)) {
                        Boolean checkUsername = db.checkUsername(user);
                        if (checkUsername == true) {
                            Register.user = user;
                            Register.pass = pass;
                            Intent i = new Intent(Register.this, ProfileSetup.class);
                            startActivity(i);
                        }
                        // If the username is currently in use, then display a message
                        else {
                            Toast.makeText(Register.this, "Username is currently in use.", Toast.LENGTH_SHORT).show();
                        }
                    }
                    // If the passwords do not match, then display a message
                    else {
                        Toast.makeText(Register.this, "Passwords do not match.", Toast.LENGTH_SHORT).show();
                    }
                }
            }
        });
    }
}
