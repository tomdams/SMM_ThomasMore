package com.example.android_smm.Domain;

import com.google.gson.annotations.SerializedName;

import java.io.Serializable;
import java.util.List;

/**
 * Created by mario on 18-5-2018.
 */

public class User implements Serializable{
    @SerializedName("user_id")
    private int User_id;
    @SerializedName("email")
    private String Email;

    @SerializedName("confirmEmail")
    private boolean ConfirmEmail;
    @SerializedName("wachtwoord")
    private String Wachtwoord;
    @SerializedName("username")
    private String Username;

    private List<Deelplatform> deelplatformen;

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

    public boolean isConfirmEmail() {
        return ConfirmEmail;
    }

    public List<Deelplatform> getDeelplatformen() {
        return deelplatformen;
    }

    public void setDeelplatformen(List<Deelplatform> deelplatformen) {
        this.deelplatformen = deelplatformen;
    }

    public Deelplatform getDeelplatform(String naam){
        for (Deelplatform deelplatform : deelplatformen) {
            if (deelplatform.getNaam().equals(naam)){
                return deelplatform;
            }
        }

        return null;
    }

    /*
    public  ICollection<AlertInstellingen> alertInstellingen;
    public  ICollection<Alert> alerts ;
    public  ICollection<Dashboard> dasboards ;
    public  Deelplatform adminDeelplatform;
    */
}
