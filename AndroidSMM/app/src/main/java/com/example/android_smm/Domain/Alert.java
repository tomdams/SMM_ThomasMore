package com.example.android_smm.Domain;

import java.io.Serializable;

public class Alert implements Serializable {
    private int Id ;
    private String message;
    // public DateTime date
    private boolean gelezen;

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public boolean isGelezen() {
        return gelezen;
    }

    public void setGelezen(boolean gelezen) {
        this.gelezen = gelezen;
    }
}
