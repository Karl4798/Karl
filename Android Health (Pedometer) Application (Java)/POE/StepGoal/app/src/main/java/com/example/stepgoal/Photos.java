package com.example.stepgoal;

import androidx.annotation.Nullable;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.provider.MediaStore;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

public class Photos extends AppCompatActivity {

    // Variables
    ImageView imagePic;
    TextView textViewMessage;
    Button btnTakePic;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_photos);

        // Typecasting
        imagePic = findViewById(R.id.imageView3);
        textViewMessage = findViewById(R.id.textView2);
        btnTakePic = findViewById(R.id.takePictureBtn);

        ActionBar actionBar = getSupportActionBar();
        actionBar.setTitle("Pictures");

    }

    // new method for the button click event
    // intent service
    // bimap imaging
    // exception handling
    public void captureImage (View view)
    {

        Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        startActivityForResult(intent, 0);

    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {

        // Gets image
        try {

            super.onActivityResult(requestCode, resultCode, data);
            Bitmap bm = (Bitmap) data.getExtras().get("data");
            imagePic.setImageBitmap(bm);

        } catch (Exception e) {

            // Exception handling
            Toast.makeText(this, "Could not capture image!", Toast.LENGTH_SHORT).show();

        }
    }
}
