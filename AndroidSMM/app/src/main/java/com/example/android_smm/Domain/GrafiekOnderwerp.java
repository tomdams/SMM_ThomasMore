package com.example.android_smm.Domain;

import com.google.gson.annotations.SerializedName;

public enum GrafiekOnderwerp {
    @SerializedName("0")
    DATUM,
    @SerializedName("1")
    SENTIMENT,
    @SerializedName("2")
    GESLACHT,
    @SerializedName("3")
    LEEFTIJD,
    @SerializedName("4")
    OPLEIDING
}
