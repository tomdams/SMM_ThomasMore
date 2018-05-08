package com.example.android_smm;

import java.util.Date;

/**
 * Created by Maart on 7/05/2018.
 */

public class Notification {
    private String onderwerp;
    private Date datum;
    private boolean geopend;

    public Notification(String onderwerp) {
        this.onderwerp = onderwerp;
        this.datum = new Date();
        this.datum.setHours(0);
        geopend = false;
    }

    public String getOnderwerp() {
        return onderwerp;
    }

    public Date getDatum() {
        return datum;
    }

    public boolean isGeopend() {
        return geopend;
    }

    public void setOnderwerp(String onderwerp) {
        this.onderwerp = onderwerp;
    }

    public void setDatum(Date datum) {
        this.datum = datum;
    }

    public void setGeopend(boolean geopend) {
        this.geopend = geopend;
    }
}
