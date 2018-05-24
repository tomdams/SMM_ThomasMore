package com.example.android_smm.Domain;

import android.support.annotation.Nullable;

import java.io.Serializable;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.List;

public class Grafiek implements Serializable{
    private int id ;
    private String titel ;
    private boolean kruising ;

    private String x_as ;
    private String y_as ;
    private String y_as1 ;
    private String y_as2 ;
    private String y_as3 ;
    private String y_as4 ;
    private String x_as_beschrijving ;
    private String y_as_beschrijving;
    public List<Element> elements;

    private String leeftijd ;
    @Nullable
    private Geslacht geslacht;
    @Nullable
    private Polariteit polariteit ;
    private String opleiding ;

    private GrafiekOnderwerp grafiekOnderwerp ;
    private GrafiekType grafiekType ;

    public int getId() {
        return id;
    }

    public String getTitel() {
        return titel;
    }

    public boolean isKruising() {
        return kruising;
    }

    public ArrayList<String> getX_as() {
        ArrayList returnList = new ArrayList();
        returnList.addAll(Arrays.asList(x_as.split(", ")));
        return returnList;
    }

    public ArrayList<Integer> getY_as() {
        String[] cijfers = y_as.split(", ");
        ArrayList<Integer> returnList = new ArrayList();

        for (String cijfer : cijfers) {
            returnList.add(Integer.parseInt(cijfer));
        }

        return returnList;
    }

    public String getY_as1() {
        return y_as1;
    }

    public String getY_as2() {
        return y_as2;
    }

    public String getY_as3() {
        return y_as3;
    }

    public String getY_as4() {
        return y_as4;
    }

    public String getX_as_beschrijving() {
        return x_as_beschrijving;
    }

    public String getY_as_beschrijving() {
        return y_as_beschrijving;
    }

    public String getLeeftijd() {
        return leeftijd;
    }

    @Nullable
    public Geslacht getGeslacht() {
        return geslacht;
    }

    @Nullable
    public Polariteit getPolariteit() {
        return polariteit;
    }

    public String getOpleiding() {
        return opleiding;
    }

    public GrafiekOnderwerp getGrafiekOnderwerp() {
        return grafiekOnderwerp;
    }

    public GrafiekType getGrafiekType() {
        return grafiekType;
    }
}

