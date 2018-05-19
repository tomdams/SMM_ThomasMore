package com.example.android_smm.Domain;

import com.google.gson.annotations.SerializedName;

import java.io.Serializable;

/**
 * Created by mario on 18-5-2018.
 */

public class User implements Serializable{
    @SerializedName("userid")
    private int User_id;
    @SerializedName("email")
    private String Email;
    @SerializedName("wachtwoord")
    private String Wachtwoord;
    @SerializedName("username")
    private String Username;

    public int getUser_id() {
        return User_id;
    }

    public String getEmail() {
        return Email;
    }

    public String getWachtwoord() {
        return Wachtwoord;
    }

    public String getUsername() {
        return Username;
    }

    /*
    public  ICollection<AlertInstellingen> alertInstellingen;
    public  ICollection<Alert> alerts ;
    public  ICollection<Dashboard> dasboards ;
    public  Deelplatform adminDeelplatform;
    */
}
