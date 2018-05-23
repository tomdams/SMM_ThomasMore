package com.example.android_smm;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.CardView;
import android.widget.LinearLayout;
import android.widget.ScrollView;
import android.widget.TextView;

import com.example.android_smm.Domain.Deelplatform;
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
import com.github.mikephil.charting.utils.ColorTemplate;



import java.util.ArrayList;

public class DashboardActivity extends AppCompatActivity {



    //BarData data;
    LinearLayout layout;
    ArrayList<String> labels;
    BarDataSet barDataSet;
    ScrollView scrollView;
    Deelplatform currentDeelplatform;





    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //(User) getIntent().getExtras().getSerializable("currentUser");
        currentDeelplatform = (Deelplatform) getIntent().getExtras().getSerializable("clickedDeelplatform");

        for (Grafiek grafiek : currentDeelplatform.getGrafieken()) {

        }

        //Dashboard scrollable maken
        scrollView = new ScrollView(this);
        layout = new LinearLayout(this);
        layout.setOrientation(LinearLayout.VERTICAL);
        LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.FILL_PARENT, LinearLayout.LayoutParams.FILL_PARENT);
        layout.setLayoutParams(layoutParams);


       /*ArrayList<String> X = new ArrayList<>();
        ArrayList<Integer> Y = new ArrayList<>();


        //TestData
        Y.add(4);
        Y.add(8);
        Y.add(6);
        Y.add(12);
        Y.add(18);
        Y.add(9);

        X.add("January");
        X.add("February");
        X.add("March");
        X.add("April");
        X.add("May");
        X.add("June");




        initializeComponents();
        addBarChart(X,Y);
        Y.add(5);
        X.add("July");
        addPieChart(X, Y);
        addLineChart(X,Y);
        scrollView.addView(layout);*/

        //Dashboard scrollable maken
        scrollView.setPadding(0,50,0,50);
        setContentView(scrollView);


    }

    private void initializeComponents(){

    }

    private void addPieChart(ArrayList<String> X, ArrayList<Integer> Y){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText("Test titel");
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);


        PieChart chart = new PieChart(this);
        ArrayList<Entry> entries;

        entries = new ArrayList<>();
        labels = new ArrayList<String>();
        for (int i = 0; i<Y.size();i++){
            entries.add(new Entry(Y.get(i), i));

        }

        PieDataSet pieDataSet = new PieDataSet(entries, "# of calls");
        pieDataSet.setColors(ColorTemplate.COLORFUL_COLORS);

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }


        PieData data = new PieData(labels, pieDataSet);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription("test beschrijving");
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

    private void addLineChart(ArrayList<String> X, ArrayList<Integer> Y){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText("Test titel");
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);

        LineChart chart = new LineChart(this);
        ArrayList<Entry> entries;

        entries = new ArrayList<>();
        labels = new ArrayList<String>();
        for (int i = 0; i<Y.size();i++){
            entries.add(new Entry(Y.get(i), i));

        }

        LineDataSet lineDataSet = new LineDataSet(entries, "# of calls");
        lineDataSet.setColors(ColorTemplate.COLORFUL_COLORS);

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }
        LineData data = new LineData(labels, lineDataSet);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription("test beschrijving");
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



    private void addBarChart(ArrayList<String> X, ArrayList<Integer> Y){
        CardView cardView = new CardView(this);
        TextView textView = new TextView(this);
        textView.setText("Test titel");
        LinearLayout chartLayout = new LinearLayout(this);
        chartLayout.setOrientation(LinearLayout.VERTICAL);

        BarChart chart = new BarChart(this);
        addGegevensXY(X, Y);
        BarData data = new BarData(labels, barDataSet);
        chart.setData(data);
        chart.animateY(1000);
        chart.setDescription("test beschrijving");
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

    private void addGegevensXY(ArrayList<String> X, ArrayList<Integer> Y){
        ArrayList<BarEntry>entries = new ArrayList<>();
        labels = new ArrayList<String>();
        for (int i = 0; i<Y.size();i++){
            entries.add(new BarEntry(Y.get(i), i));
        }

       barDataSet = new BarDataSet(entries, "# of calls");
        barDataSet.setColors(ColorTemplate.COLORFUL_COLORS);

        for (int i = 0; i <X.size(); i++){
            labels.add(X.get(i));
        }
    }
}
