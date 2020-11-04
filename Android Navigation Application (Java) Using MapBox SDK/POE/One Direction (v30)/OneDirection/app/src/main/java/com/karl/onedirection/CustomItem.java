package com.karl.onedirection;

public class CustomItem {

    // CustomItem variables used for spinner items
    private String spinnerItemName;
    private Integer spinnerItemImage;

    // Constructor that accepts spinner items, which is used to populate the two spinners
    public CustomItem(String spinnerItemName, Integer spinnerItemImage) {
        this.spinnerItemName = spinnerItemName;
        this.spinnerItemImage = spinnerItemImage;
    }

    // Getters used to retrieve spinner items
    public String getSpinnerItemName() {
        return spinnerItemName;
    }
    public Integer getSpinnerItemImage() {
        return spinnerItemImage;
    }

}
