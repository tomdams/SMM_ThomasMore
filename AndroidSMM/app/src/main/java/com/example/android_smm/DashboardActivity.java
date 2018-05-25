package com.example.android_smm;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.CardView;
import android.widget.LinearLayout;
import android.widget.ScrollView;
import android.widget.TextView;

import com.example.android_smm.Domain.Deelplatform;
import com.example.android_smm.Domain.Element;
import com.example.android_smm.Domain.Grafiek;
import com.github.mikephil.charting.charts.BarChart;
import com.github.mikephil.charting.charts.LineChart;
import com.github.mikephil.charting.charts.PieChart;
import com.github.mikephil.charting.data.BarData;
import com.github.mikephil.charting.data.BarDataSet;
import com.github.mikephil.charting.data.BarEntry;
import com.github.mikephil.charting.data.Entry;
import com.github.mikephil.charting.data.LineData;
import com.github.mikephil.charting.data.LineDataSet;
import com.github.mikephil.charting.data.PieData;
import com.github.mikephil.charting.data.PieDataSet;
import com.github.mikephil.charting.interfaces.datasets.IBarDataSet;
import com.github.mikephil.charting.interfaces.datasets.ILineDataSet;
import com.github.mikephil.charting.utils.ColorTemplate;



import java.util.ArrayList;
import java.util.List;

public class DashboardActivity extends AppCompatActivity {



    //BarData data;
    LinearLayout layout;
    ArrayList<String> labels;

    ScrollView scrollView;
    Deelplatform currentDeelplatform;





    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //(User) getIntent().getExtras().getSerializable("currentUser");
        currentDeelplatform = (Deelplatform) getIntent().getExtras().getSerializable("clickedDeelplatform");

        //Dashboard scrollable maken
        scrollView = new ScrollView(this);
        layout = new LinearLayout(this);
        layout.setOrientation(LinearLayout.VERTICAL);
        LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.FILL_PARENT, LinearLayout.LayoutParams.FILL_PARENT);
        layout.setLayoutParams(layoutParams);

        for (Grafiek grafiek : currentDeelplatform.getGrafieken()) {
            switch (grafiek.getGrafiekType()){
                case TAART:
                    if(grafiek.getElements().size() ==1){
                        addPieChart(grafiek.getX_as(), grafiek.getY_as(), grafiek.getTitel(), grafiek.getX_as_beschrijving(),grafiek.getY_as_beschrijving());
                    }else if(grafiek.getElements().size() >1){

                    }
                    break;
                case LIJN:
                    if(grafiek.getElements().size() ==1){
                        addLineChart(grafiek.getX_as(), grafiek.getY_as(), grafiek.getTitel(), grafiek.getY_as_beschrijving(),grafiek.getElements().get(0).naam);
                    }else if(grafiek.getElements().size() >1){
                        switch (grafiek.getElements().size()){
                            case 2: addLineKruising(grafiek.getX_as(), grafiek.getY_as(), grafiek.getTitel(), grafiek.getY_as_beschrijving(),grafiek.getElements().get(0).naam, 2, grafiek.getY_as1(), grafiek.getElements().get(1).naam);
                                break;
                            case 3: addLineKruising(grafiek.getX_as(), grafiek.getY_as(), grafiek.getTitel(), grafiek.getY_as_beschrijving(),grafiek.getElements().get(0).naam, 3, grafiek.getY_as1(), grafiek.getElements().get(1).naam, grafiek.getY_as2(), grafiek.getElements().get(2).naam);
                                break;
                            case 4: addLineKruising(grafiek.getX_as(), grafiek.getY_as(), grafiek.getTitel(), grafiek.getY_as_beschrijving(),grafiek.getElements().get(0).naam, 4, grafiek.getY_as1(), grafiek.getElements().get(1).naam, grafiek.getY_as2(), grafiek.getElements().get(2).naam, grafiek.getY_as3(), grafiek.getElements().get(3).naam);
                                break;
                            case 5: addLineKruising(grafiek.getX_as(), grafiek.getY_as(), grafiek.getTitel(), grafiek.getY_as_beschrijving(),grafiek.getElements().get(0).naam, 4, grafiek.getY_as1(), grafiek.getElements().get(1).naam, grafiek.getY_as2(), grafiek.getElements().get(2).naam, grafiek.getY_as3(), grafiek.getElements().get(3).naam, grafiek.getY_as4(), grafiek.getElements().get(4).naam);
                                break;
                        }

                    }
                    break;
                case STAAF:
                    if(grafiek.getElements().size() ==1){
                        addBarChart(grafiek.getX_as(), grafiek.getY_as(), grafiek.getTitel(), grafiek.getX_as_beschrijving(),grafiek.getY_as_beschrijving());
                    }else if(grafiek.getElements().size() >1){
                        switch (grafiek.getElements().size()) {
                            case 2:
                                addBarKruising(grafiek.getX_as(), grafiek.getY_as(), grafiek.getTitel(), grafiek.getY_as_beschrijving(), grafiek.getElements().get(0).naam, 2, grafiek.getY_as1(), grafiek.getElements().get(1).naam);
                                break;
                            case 3: addBarKruising(grafiek.getX_as(), grafiek.getY_as(), grafiek.getTitel(), grafiek.getY_as_beschrijving(),grafiek.getElements().get(0).naam, 3, grafiek.getY_as1(), grafiek.getElements().get(1).naam, grafiek.getY_as2(), grafiek.getElements().get(2).naam);
                                break;
                            case 4: addBarKruising(grafiek.getX_as(), grafiek.getY_as(), grafiek.getTitel(), grafiek.getY_as_beschrijving(),grafiek.getElements().get(0).naam, 4, grafiek.getY_as1(), grafiek.getElements().get(1).naam, grafiek.getY_as2(), grafiek.getElements().get(2).naam, grafiek.getY_as3(), grafiek.getElements().get(3).naam);
                                break;
                            case 5: addBarKruising(grafiek.getX_as(), grafiek.getY_as(), grafiek.getTitel(), grafiek.getY_as_beschrijving(),grafiek.getElements().get(0).naam, 4, grafiek.getY_as1(), grafiek.getElements().get(1).naam, grafiek.getY_as2(), grafiek.getElements().get(2).naam, grafiek.getY_as3(), grafiek.getElements().get(3).naam, grafiek.getY_as4(), grafiek.getElements().get(4).naam);
                                break;
                        }
                    }
                    break;
            }

        }

        scrollView.addView(layout);

        //Dashboard scrollable maken
        scrollView.setPadding(0,50,0,50);
        setContentView(scrollView);


    }

    private void initializeComponents(){

    }

    private void addPieChart(ArrayList<String> X, ArrayList<Integer> Y, String titel, String Xas_beschrijving,String Yas_beschrijving){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText(titel);
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);


        PieChart chart = new PieChart(this);
        ArrayList<Entry> entries;


        entries = new ArrayList<>();
        labels = new ArrayList<String>();
        for (int i = 0; i<Y.size();i++){
            entries.add(new Entry(Y.get(i), i));

        }

        PieDataSet pieDataSet = new PieDataSet(entries, Yas_beschrijving);
        pieDataSet.setColors(new int[] { R.color.backgroundcolor, R.color.orangiee, R.color.colorPrimary, R.color.colorPrimaryDark}, getApplicationContext());

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }


        PieData data = new PieData(labels, pieDataSet);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription(Xas_beschrijving);
        chart.setMinimumHeight(1000);
        pieDataSet.setValueTextSize(6);
        chartLayout.addView(textView);
        chartLayout.addView(chart);
        chartLayout.setPadding(20, 20, 20, 20);
        cardView.addView(chartLayout);
        layout.setPadding(50, 0, 50, 0);

        CardView.LayoutParams chartViewParams = new CardView.LayoutParams(CardView.LayoutParams.FILL_PARENT, CardView.LayoutParams.WRAP_CONTENT);
        chartViewParams.setMargins(0,50,0,20);
        cardView.setLayoutParams(chartViewParams);

        layout.addView(cardView);
    }

    private void addLineChart(ArrayList<String> X, ArrayList<Integer> Y, String titel, String Xas_beschrijving,String Yas_beschrijving){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText(titel);
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);

        LineChart chart = new LineChart(this);
        labels = new ArrayList<String>();
        ArrayList<Entry> entries;
        ArrayList<Entry> entries1;


        entries = new ArrayList<>();
        for (int i = 0; i<Y.size();i++){
            entries.add(new Entry(Y.get(i), i));

        }

        LineDataSet lineDataSet = new LineDataSet(entries, Yas_beschrijving);
        lineDataSet.setColors(new int[] { R.color.colorPrimaryDark}, getApplicationContext());

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }
        LineData data = new LineData(labels, lineDataSet);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription(Xas_beschrijving);
        chart.setMinimumHeight(1000);
        lineDataSet.setValueTextSize(6);
        chartLayout.addView(textView);
        chartLayout.addView(chart);
        chartLayout.setPadding(20, 20, 20, 20);
        cardView.addView(chartLayout);
        layout.setPadding(50, 0, 50, 0);

        CardView.LayoutParams chartViewParams = new CardView.LayoutParams(CardView.LayoutParams.FILL_PARENT, CardView.LayoutParams.WRAP_CONTENT);
        chartViewParams.setMargins(0,50,0,20);
        cardView.setLayoutParams(chartViewParams);

        layout.addView(cardView);
    }



    private void addBarChart(ArrayList<String> X, ArrayList<Integer> Y, String titel, String Xas_beschrijving,String Yas_beschrijving){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText(titel);
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);

        BarChart chart = new BarChart(this);

        ArrayList<BarEntry>entries = new ArrayList<>();
        labels = new ArrayList<String>();
        for (int i = 0; i<Y.size();i++){
            entries.add(new BarEntry(Y.get(i), i));
        }

        BarDataSet barDataSet = new BarDataSet(entries, Yas_beschrijving);
        barDataSet.setColors(new int[] { R.color.backgroundcolor, R.color.orangiee, R.color.colorPrimary, R.color.colorPrimaryDark}, getApplicationContext());

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }


        BarData data = new BarData(labels, barDataSet);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription(Xas_beschrijving);
        chart.setMinimumHeight(1000);

        chartLayout.addView(textView);
        chartLayout.addView(chart);
        chartLayout.setPadding(20,20,20,20);
        cardView.addView(chartLayout);
        layout.setPadding(50,0,50,0);

        CardView.LayoutParams chartViewParams = new CardView.LayoutParams(CardView.LayoutParams.FILL_PARENT, CardView.LayoutParams.WRAP_CONTENT);
        chartViewParams.setMargins(0,50,0,20);
        cardView.setLayoutParams(chartViewParams);

        layout.addView(cardView);
    }

    //Kruisingen
    //Bar
    private void addBarKruising(ArrayList<String> X, ArrayList<Integer> Y, String titel, String Xas_beschrijving,String Yas_beschrijving, int aantalY,  ArrayList<Integer> Y2, String Y2as_beschrijving){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText(titel);
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);

        BarChart chart = new BarChart(this);
        labels = new ArrayList<String>();
        ArrayList<BarEntry>entries = new ArrayList<>();
        ArrayList<BarEntry>entries1 = new ArrayList<>();


        for (int i = 0; i<Y.size();i++){
            entries.add(new BarEntry(Y.get(i), i));
        }

        for (int i = 0; i<Y2.size();i++){
            entries1.add(new BarEntry(Y2.get(i), i));
        }

        BarDataSet barDataSet = new BarDataSet(entries, Yas_beschrijving);
        barDataSet.setColors(new int[] {R.color.colorPrimaryDark}, getApplicationContext());

        BarDataSet barDataSet2 = new BarDataSet(entries1, Y2as_beschrijving);
        barDataSet2.setColors(new int[] { R.color.backgroundcolor}, getApplicationContext());

        List<IBarDataSet> barDataSets = new ArrayList<>();
        barDataSets.add(barDataSet);
        barDataSets.add(barDataSet2);

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }

        String[] xAses = new String[labels.size()];
        for (int i = 0; i < labels.size(); i++){
            xAses[i] = labels.get(i);
        }


        BarData data = new BarData(labels, barDataSets);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription(Xas_beschrijving);
        chart.setMinimumHeight(1000);

        chartLayout.addView(textView);
        chartLayout.addView(chart);
        chartLayout.setPadding(20,20,20,20);
        cardView.addView(chartLayout);
        layout.setPadding(50,0,50,0);

        CardView.LayoutParams chartViewParams = new CardView.LayoutParams(CardView.LayoutParams.FILL_PARENT, CardView.LayoutParams.WRAP_CONTENT);
        chartViewParams.setMargins(0,50,0,20);
        cardView.setLayoutParams(chartViewParams);

        layout.addView(cardView);
    }

    private void addBarKruising(ArrayList<String> X, ArrayList<Integer> Y, String titel, String Xas_beschrijving,String Yas_beschrijving, int aantalY,  ArrayList<Integer> Y2, String Y2as_beschrijving, ArrayList<Integer> Y3, String Y3as_beschrijving){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText(titel);
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);

        BarChart chart = new BarChart(this);
        labels = new ArrayList<String>();
        ArrayList<BarEntry>entries = new ArrayList<>();
        ArrayList<BarEntry>entries1 = new ArrayList<>();
        ArrayList<BarEntry>entries2 = new ArrayList<>();


        for (int i = 0; i<Y.size();i++){
            entries.add(new BarEntry(Y.get(i), i));
        }

        for (int i = 0; i<Y2.size();i++){
            entries1.add(new BarEntry(Y2.get(i), i));
        }

        for (int i = 0; i<Y3.size();i++){
            entries2.add(new BarEntry(Y3.get(i), i));
        }

        BarDataSet barDataSet = new BarDataSet(entries, Yas_beschrijving);
        barDataSet.setColors(new int[] {R.color.colorPrimaryDark}, getApplicationContext());

        BarDataSet barDataSet2 = new BarDataSet(entries1, Y2as_beschrijving);
        barDataSet2.setColors(new int[] { R.color.backgroundcolor}, getApplicationContext());

        BarDataSet barDataSet3 = new BarDataSet(entries2, Y3as_beschrijving);
        barDataSet3.setColors(new int[] { R.color.colorPrimary}, getApplicationContext());

        List<IBarDataSet> barDataSets = new ArrayList<>();
        barDataSets.add(barDataSet);
        barDataSets.add(barDataSet2);
        barDataSets.add(barDataSet3);

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }

        String[] xAses = new String[labels.size()];
        for (int i = 0; i < labels.size(); i++){
            xAses[i] = labels.get(i);
        }


        BarData data = new BarData(labels, barDataSets);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription(Xas_beschrijving);
        chart.setMinimumHeight(1000);

        chartLayout.addView(textView);
        chartLayout.addView(chart);
        chartLayout.setPadding(20,20,20,20);
        cardView.addView(chartLayout);
        layout.setPadding(50,0,50,0);

        CardView.LayoutParams chartViewParams = new CardView.LayoutParams(CardView.LayoutParams.FILL_PARENT, CardView.LayoutParams.WRAP_CONTENT);
        chartViewParams.setMargins(0,50,0,20);
        cardView.setLayoutParams(chartViewParams);

        layout.addView(cardView);
    }

    private void addBarKruising(ArrayList<String> X, ArrayList<Integer> Y, String titel, String Xas_beschrijving,String Yas_beschrijving, int aantalY,  ArrayList<Integer> Y2, String Y2as_beschrijving, ArrayList<Integer> Y3, String Y3as_beschrijving, ArrayList<Integer> Y4, String Y4as_beschrijving){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText(titel);
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);

        BarChart chart = new BarChart(this);
        labels = new ArrayList<String>();
        ArrayList<BarEntry>entries = new ArrayList<>();
        ArrayList<BarEntry>entries1 = new ArrayList<>();
        ArrayList<BarEntry>entries2 = new ArrayList<>();
        ArrayList<BarEntry>entries3 = new ArrayList<>();


        for (int i = 0; i<Y.size();i++){
            entries.add(new BarEntry(Y.get(i), i));
        }

        for (int i = 0; i<Y2.size();i++){
            entries1.add(new BarEntry(Y2.get(i), i));
        }

        for (int i = 0; i<Y3.size();i++){
            entries2.add(new BarEntry(Y3.get(i), i));
        }

        for (int i = 0; i<Y4.size();i++){
            entries3.add(new BarEntry(Y4.get(i), i));
        }

        BarDataSet barDataSet = new BarDataSet(entries, Yas_beschrijving);
        barDataSet.setColors(new int[] {R.color.colorPrimaryDark}, getApplicationContext());

        BarDataSet barDataSet2 = new BarDataSet(entries1, Y2as_beschrijving);
        barDataSet2.setColors(new int[] { R.color.backgroundcolor}, getApplicationContext());

        BarDataSet barDataSet3 = new BarDataSet(entries2, Y3as_beschrijving);
        barDataSet3.setColors(new int[] { R.color.colorPrimary}, getApplicationContext());

        BarDataSet barDataSet4 = new BarDataSet(entries3, Y4as_beschrijving);
        barDataSet4.setColors(new int[] { R.color.orangiee}, getApplicationContext());

        List<IBarDataSet> barDataSets = new ArrayList<>();
        barDataSets.add(barDataSet);
        barDataSets.add(barDataSet2);
        barDataSets.add(barDataSet3);
        barDataSets.add(barDataSet4);

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }

        String[] xAses = new String[labels.size()];
        for (int i = 0; i < labels.size(); i++){
            xAses[i] = labels.get(i);
        }


        BarData data = new BarData(labels, barDataSets);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription(Xas_beschrijving);
        chart.setMinimumHeight(1000);

        chartLayout.addView(textView);
        chartLayout.addView(chart);
        chartLayout.setPadding(20,20,20,20);
        cardView.addView(chartLayout);
        layout.setPadding(50,0,50,0);

        CardView.LayoutParams chartViewParams = new CardView.LayoutParams(CardView.LayoutParams.FILL_PARENT, CardView.LayoutParams.WRAP_CONTENT);
        chartViewParams.setMargins(0,50,0,20);
        cardView.setLayoutParams(chartViewParams);

        layout.addView(cardView);
    }

    private void addBarKruising(ArrayList<String> X, ArrayList<Integer> Y, String titel, String Xas_beschrijving,String Yas_beschrijving, int aantalY,  ArrayList<Integer> Y2, String Y2as_beschrijving, ArrayList<Integer> Y3, String Y3as_beschrijving, ArrayList<Integer> Y4, String Y4as_beschrijving, ArrayList<Integer> Y5, String Y5as_beschrijving){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText(titel);
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);

        BarChart chart = new BarChart(this);
        labels = new ArrayList<String>();
        ArrayList<BarEntry>entries = new ArrayList<>();
        ArrayList<BarEntry>entries1 = new ArrayList<>();
        ArrayList<BarEntry>entries2 = new ArrayList<>();
        ArrayList<BarEntry>entries3 = new ArrayList<>();
        ArrayList<BarEntry>entries4 = new ArrayList<>();


        for (int i = 0; i<Y.size();i++){
            entries.add(new BarEntry(Y.get(i), i));
        }

        for (int i = 0; i<Y2.size();i++){
            entries1.add(new BarEntry(Y2.get(i), i));
        }

        for (int i = 0; i<Y3.size();i++){
            entries2.add(new BarEntry(Y3.get(i), i));
        }

        for (int i = 0; i<Y4.size();i++){
            entries3.add(new BarEntry(Y4.get(i), i));
        }

        for (int i = 0; i<Y5.size();i++){
            entries4.add(new BarEntry(Y5.get(i), i));
        }

        BarDataSet barDataSet = new BarDataSet(entries, Yas_beschrijving);
        barDataSet.setColors(new int[] {R.color.colorPrimaryDark}, getApplicationContext());

        BarDataSet barDataSet2 = new BarDataSet(entries1, Y2as_beschrijving);
        barDataSet2.setColors(new int[] { R.color.backgroundcolor}, getApplicationContext());

        BarDataSet barDataSet3 = new BarDataSet(entries2, Y3as_beschrijving);
        barDataSet3.setColors(new int[] { R.color.colorPrimary}, getApplicationContext());

        BarDataSet barDataSet4 = new BarDataSet(entries3, Y4as_beschrijving);
        barDataSet4.setColors(new int[] { R.color.orangiee}, getApplicationContext());

        BarDataSet barDataSet5 = new BarDataSet(entries4, Y5as_beschrijving);
        barDataSet5.setColors(new int[] { R.color.black_overlay}, getApplicationContext());

        List<IBarDataSet> barDataSets = new ArrayList<>();
        barDataSets.add(barDataSet);
        barDataSets.add(barDataSet2);
        barDataSets.add(barDataSet3);
        barDataSets.add(barDataSet4);
        barDataSets.add(barDataSet5);

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }

        String[] xAses = new String[labels.size()];
        for (int i = 0; i < labels.size(); i++){
            xAses[i] = labels.get(i);
        }


        BarData data = new BarData(labels, barDataSets);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription(Xas_beschrijving);
        chart.setMinimumHeight(1000);

        chartLayout.addView(textView);
        chartLayout.addView(chart);
        chartLayout.setPadding(20,20,20,20);
        cardView.addView(chartLayout);
        layout.setPadding(50,0,50,0);

        CardView.LayoutParams chartViewParams = new CardView.LayoutParams(CardView.LayoutParams.FILL_PARENT, CardView.LayoutParams.WRAP_CONTENT);
        chartViewParams.setMargins(0,50,0,20);
        cardView.setLayoutParams(chartViewParams);

        layout.addView(cardView);
    }











    //Line
    private void addLineKruising(ArrayList<String> X, ArrayList<Integer> Y, String titel, String Xas_beschrijving,String Yas_beschrijving, int aantalY,  ArrayList<Integer> Y2, String Y2as_beschrijving){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText(titel);
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);

        LineChart chart = new LineChart(this);
        labels = new ArrayList<String>();
        ArrayList<Entry> entries;
        ArrayList<Entry> entries1;


        entries = new ArrayList<>();
        entries1 = new ArrayList<>();
        for (int i = 0; i<Y.size();i++){
            entries.add(new Entry(Y.get(i), i));

        }

        for (int i = 0; i<Y2.size();i++){
            entries1.add(new Entry(Y2.get(i), i));

        }

        LineDataSet lineDataSet = new LineDataSet(entries, Yas_beschrijving);
        lineDataSet.setColors(new int[] { R.color.backgroundcolor}, getApplicationContext());

        LineDataSet lineDataSet2 = new LineDataSet(entries1, Y2as_beschrijving);
        lineDataSet2.setColors(new int[] {R.color.colorPrimaryDark}, getApplicationContext());

        List<ILineDataSet> lineDataSets = new ArrayList<>();
        lineDataSets.add(lineDataSet);
        lineDataSets.add(lineDataSet2);

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }

        String[] xAses = new String[labels.size()];
        for (int i = 0; i < labels.size(); i++){
            xAses[i] = labels.get(i);
        }





        LineData data = new LineData(labels,lineDataSets);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription(Xas_beschrijving);
        chart.setMinimumHeight(1000);
        lineDataSet.setValueTextSize(6);
        chartLayout.addView(textView);
        chartLayout.addView(chart);
        chartLayout.setPadding(20, 20, 20, 20);
        cardView.addView(chartLayout);
        layout.setPadding(50, 0, 50, 0);

        CardView.LayoutParams chartViewParams = new CardView.LayoutParams(CardView.LayoutParams.FILL_PARENT, CardView.LayoutParams.WRAP_CONTENT);
        chartViewParams.setMargins(0,50,0,20);
        cardView.setLayoutParams(chartViewParams);

        layout.addView(cardView);
    }

    private void addLineKruising(ArrayList<String> X, ArrayList<Integer> Y, String titel, String Xas_beschrijving,String Yas_beschrijving, int aantalY,  ArrayList<Integer> Y2, String Y2as_beschrijving, ArrayList<Integer> Y3, String Y3as_beschrijving){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText(titel);
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);

        LineChart chart = new LineChart(this);
        labels = new ArrayList<String>();
        ArrayList<Entry> entries;
        ArrayList<Entry> entries1;
        ArrayList<Entry> entries2;


        entries = new ArrayList<>();
        entries1 = new ArrayList<>();
        entries2 = new ArrayList<>();
        for (int i = 0; i<Y.size();i++){
            entries.add(new Entry(Y.get(i), i));

        }

        for (int i = 0; i<Y2.size();i++){
            entries1.add(new Entry(Y2.get(i), i));

        }

        for (int i = 0; i<Y3.size();i++){
            entries2.add(new Entry(Y3.get(i), i));

        }

        LineDataSet lineDataSet = new LineDataSet(entries, Yas_beschrijving);
        lineDataSet.setColors(new int[] { R.color.backgroundcolor}, getApplicationContext());

        LineDataSet lineDataSet2 = new LineDataSet(entries1, Y2as_beschrijving);
        lineDataSet2.setColors(new int[] {R.color.colorPrimaryDark}, getApplicationContext());

        LineDataSet lineDataSet3 = new LineDataSet(entries2, Y3as_beschrijving);
        lineDataSet3.setColors(new int[] {R.color.colorPrimary}, getApplicationContext());

        List<ILineDataSet> lineDataSets = new ArrayList<>();
        lineDataSets.add(lineDataSet);
        lineDataSets.add(lineDataSet2);
        lineDataSets.add(lineDataSet3);

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }

        String[] xAses = new String[labels.size()];
        for (int i = 0; i < labels.size(); i++){
            xAses[i] = labels.get(i);
        }





        LineData data = new LineData(labels,lineDataSets);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription(Xas_beschrijving);
        chart.setMinimumHeight(1000);
        lineDataSet.setValueTextSize(6);
        chartLayout.addView(textView);
        chartLayout.addView(chart);
        chartLayout.setPadding(20, 20, 20, 20);
        cardView.addView(chartLayout);
        layout.setPadding(50, 0, 50, 0);

        CardView.LayoutParams chartViewParams = new CardView.LayoutParams(CardView.LayoutParams.FILL_PARENT, CardView.LayoutParams.WRAP_CONTENT);
        chartViewParams.setMargins(0,50,0,20);
        cardView.setLayoutParams(chartViewParams);

        layout.addView(cardView);
    }

    private void addLineKruising(ArrayList<String> X, ArrayList<Integer> Y, String titel, String Xas_beschrijving,String Yas_beschrijving, int aantalY,  ArrayList<Integer> Y2, String Y2as_beschrijving, ArrayList<Integer> Y3, String Y3as_beschrijving, ArrayList<Integer> Y4, String Y4as_beschrijving){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText(titel);
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);

        LineChart chart = new LineChart(this);
        labels = new ArrayList<String>();
        ArrayList<Entry> entries;
        ArrayList<Entry> entries1;
        ArrayList<Entry> entries2;
        ArrayList<Entry> entries3;


        entries = new ArrayList<>();
        entries1 = new ArrayList<>();
        entries2 = new ArrayList<>();
        entries3 = new ArrayList<>();
        for (int i = 0; i<Y.size();i++){
            entries.add(new Entry(Y.get(i), i));

        }

        for (int i = 0; i<Y2.size();i++){
            entries1.add(new Entry(Y2.get(i), i));

        }

        for (int i = 0; i<Y3.size();i++){
            entries2.add(new Entry(Y3.get(i), i));

        }
        for (int i = 0; i<Y4.size();i++){
            entries3.add(new Entry(Y4.get(i), i));

        }

        LineDataSet lineDataSet = new LineDataSet(entries, Yas_beschrijving);
        lineDataSet.setColors(new int[] { R.color.backgroundcolor}, getApplicationContext());

        LineDataSet lineDataSet2 = new LineDataSet(entries1, Y2as_beschrijving);
        lineDataSet2.setColors(new int[] {R.color.colorPrimaryDark}, getApplicationContext());

        LineDataSet lineDataSet3 = new LineDataSet(entries2, Y3as_beschrijving);
        lineDataSet3.setColors(new int[] {R.color.colorPrimary}, getApplicationContext());

        LineDataSet lineDataSet4 = new LineDataSet(entries3, Y4as_beschrijving);
        lineDataSet4.setColors(new int[] {R.color.orangiee}, getApplicationContext());

        List<ILineDataSet> lineDataSets = new ArrayList<>();
        lineDataSets.add(lineDataSet);
        lineDataSets.add(lineDataSet2);
        lineDataSets.add(lineDataSet3);
        lineDataSets.add(lineDataSet4);

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }

        String[] xAses = new String[labels.size()];
        for (int i = 0; i < labels.size(); i++){
            xAses[i] = labels.get(i);
        }





        LineData data = new LineData(labels,lineDataSets);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription(Xas_beschrijving);
        chart.setMinimumHeight(1000);
        lineDataSet.setValueTextSize(6);
        chartLayout.addView(textView);
        chartLayout.addView(chart);
        chartLayout.setPadding(20, 20, 20, 20);
        cardView.addView(chartLayout);
        layout.setPadding(50, 0, 50, 0);

        CardView.LayoutParams chartViewParams = new CardView.LayoutParams(CardView.LayoutParams.FILL_PARENT, CardView.LayoutParams.WRAP_CONTENT);
        chartViewParams.setMargins(0,50,0,20);
        cardView.setLayoutParams(chartViewParams);

        layout.addView(cardView);
    }

    private void addLineKruising(ArrayList<String> X, ArrayList<Integer> Y, String titel, String Xas_beschrijving,String Yas_beschrijving, int aantalY,  ArrayList<Integer> Y2, String Y2as_beschrijving, ArrayList<Integer> Y3, String Y3as_beschrijving, ArrayList<Integer> Y4, String Y4as_beschrijving, ArrayList<Integer> Y5, String Y5as_beschrijving){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText(titel);
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);

        LineChart chart = new LineChart(this);
        labels = new ArrayList<String>();
        ArrayList<Entry> entries;
        ArrayList<Entry> entries1;
        ArrayList<Entry> entries2;
        ArrayList<Entry> entries3;
        ArrayList<Entry> entries4;


        entries = new ArrayList<>();
        entries1 = new ArrayList<>();
        entries2 = new ArrayList<>();
        entries3 = new ArrayList<>();
        entries4 = new ArrayList<>();
        for (int i = 0; i<Y.size();i++){
            entries.add(new Entry(Y.get(i), i));

        }

        for (int i = 0; i<Y2.size();i++){
            entries1.add(new Entry(Y2.get(i), i));

        }

        for (int i = 0; i<Y3.size();i++){
            entries2.add(new Entry(Y3.get(i), i));

        }
        for (int i = 0; i<Y4.size();i++){
            entries3.add(new Entry(Y4.get(i), i));

        }

        for (int i = 0; i<Y5.size();i++){
            entries4.add(new Entry(Y5.get(i), i));

        }

        LineDataSet lineDataSet = new LineDataSet(entries, Yas_beschrijving);
        lineDataSet.setColors(new int[] { R.color.backgroundcolor}, getApplicationContext());

        LineDataSet lineDataSet2 = new LineDataSet(entries1, Y2as_beschrijving);
        lineDataSet2.setColors(new int[] {R.color.colorPrimaryDark}, getApplicationContext());

        LineDataSet lineDataSet3 = new LineDataSet(entries2, Y3as_beschrijving);
        lineDataSet3.setColors(new int[] {R.color.colorPrimary}, getApplicationContext());

        LineDataSet lineDataSet4 = new LineDataSet(entries3, Y4as_beschrijving);
        lineDataSet4.setColors(new int[] {R.color.orangiee}, getApplicationContext());

        LineDataSet lineDataSet5 = new LineDataSet(entries4, Y5as_beschrijving);
        lineDataSet5.setColors(new int[] {R.color.black_overlay}, getApplicationContext());

        List<ILineDataSet> lineDataSets = new ArrayList<>();
        lineDataSets.add(lineDataSet);
        lineDataSets.add(lineDataSet2);
        lineDataSets.add(lineDataSet3);
        lineDataSets.add(lineDataSet4);
        lineDataSets.add(lineDataSet5);

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }

        String[] xAses = new String[labels.size()];
        for (int i = 0; i < labels.size(); i++){
            xAses[i] = labels.get(i);
        }





        LineData data = new LineData(labels,lineDataSets);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription(Xas_beschrijving);
        chart.setMinimumHeight(1000);
        lineDataSet.setValueTextSize(6);
        chartLayout.addView(textView);
        chartLayout.addView(chart);
        chartLayout.setPadding(20, 20, 20, 20);
        cardView.addView(chartLayout);
        layout.setPadding(50, 0, 50, 0);

        CardView.LayoutParams chartViewParams = new CardView.LayoutParams(CardView.LayoutParams.FILL_PARENT, CardView.LayoutParams.WRAP_CONTENT);
        chartViewParams.setMargins(0,50,0,20);
        cardView.setLayoutParams(chartViewParams);

        layout.addView(cardView);
    }



}
