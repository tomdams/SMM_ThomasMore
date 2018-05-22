package com.example.android_smm.Domain;

import android.support.annotation.Nullable;

import java.time.LocalDate;
import java.time.LocalDateTime;

public class Grafiek {
    public int id ;
    public String titel ;
    public boolean kruising ;

    public String x_as ;
    public String y_as ;
    public String y_as1 ;
    public String y_as2 ;
    public String y_as3 ;
    public String y_as4 ;
    public String x_as_beschrijving ;
    public String y_as_beschrijving;

    public LocalDateTime beginDate ;
    public LocalDateTime eindDate ;
    public String leeftijd ;
    @Nullable
    public Geslacht geslacht;
    @Nullable
    public Polariteit polariteit ;
    public String opleiding ;

    public GrafiekOnderwerp grafiekOnderwerp ;
    public GrafiekType grafiekType ;




}

