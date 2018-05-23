package com.example.android_smm.Domain;

import java.io.Serializable;
import java.util.List;

/**
 * Created by Maart on 20/05/2018.
 */

public class Deelplatform implements Serializable {

    private String naam;
    private  int id;
    private List<Grafiek> grafieken;


    public Deelplatform() {
    }

    public Deelplatform(int id, String naam) {
        this.naam = naam;
        this.id = id;
    }

    public String getNaam() {
        return naam;
    }

    public void setNaam(String naam) {
        this.naam = naam;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public List<Grafiek> getGrafieken() {
        return grafieken;
    }

    public void setGrafieken(List<Grafiek> grafieken) {
        this.grafieken = grafieken;
    }
}
