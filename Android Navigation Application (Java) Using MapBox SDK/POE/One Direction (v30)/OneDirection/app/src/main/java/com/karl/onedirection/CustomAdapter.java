package com.karl.onedirection;

// Required imports
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import org.jetbrains.annotations.Nullable;

import java.util.ArrayList;

// Class used for the custom spinner items and design
public class CustomAdapter extends ArrayAdapter<CustomItem> {

    // Constructor
    public CustomAdapter(@NonNull Context context, ArrayList<CustomItem> customList) {
        super(context, 0, customList);
    }

    // Sets the spinner view items
    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        if (convertView == null) {
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.custom_spinner_layout, parent, false);
        }

        // Gets the spinner items
        CustomItem item = getItem(position);

        // Sets spinner image views and text views
        ImageView spinnerIV = convertView.findViewById(R.id.ivSpinnerLayout);
        TextView spinnerTV = convertView.findViewById(R.id.tvSpinnerLayout);

        // If the item is not null, set layout parameters for the spinner and populate it
        if (item != null) {
            if (item.getSpinnerItemImage() != null) {
                spinnerIV.setImageResource(item.getSpinnerItemImage());
            }
            else {
                LinearLayout.LayoutParams params = (LinearLayout.LayoutParams)spinnerIV.getLayoutParams();
                params.width = 0;
                params.height = 0;
                spinnerIV.setLayoutParams(params);
            }
            spinnerTV.setText(item.getSpinnerItemName());
        }
        return convertView;
    }

    // Sets the spinner view items (drop down list)
    @Override
    public View getDropDownView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        if (convertView == null) {
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.custom_dropdown_layout, parent, false);
        }

        // Gets the spinner items
        CustomItem item = getItem(position);

        // Sets spinner image views and text views
        ImageView dropDownIV = convertView.findViewById(R.id.ivDropDownLayout);
        TextView dropDownTV = convertView.findViewById(R.id.tvDropDownLayout);

        // If the item is not null, set layout parameters for the spinner drop down and populate it
        if (item != null) {
            if (item.getSpinnerItemImage() != null) {
                dropDownIV.setImageResource(item.getSpinnerItemImage());
            }
            else {
                LinearLayout.LayoutParams params = (LinearLayout.LayoutParams)dropDownIV.getLayoutParams();
                params.width = 0;
                params.height = 0;
                dropDownIV.setLayoutParams(params);
            }
            dropDownTV.setText(item.getSpinnerItemName());
        }
        return convertView;
    }

}
