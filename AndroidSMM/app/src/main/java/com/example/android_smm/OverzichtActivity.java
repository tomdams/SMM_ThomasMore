package com.example.android_smm;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.CardView;
import android.view.View;

import butterknife.BindView;
import butterknife.ButterKnife;

public class OverzichtActivity extends AppCompatActivity {
    @BindView(R.id.dashboardId)
    CardView dashboardCardView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_overzicht);
        ButterKnife.bind(this);
        addEventHandlers();
    }


    private void addEventHandlers(){


        dashboardCardView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(OverzichtActivity.this, DashboardActivity.class);
                startActivity(intent);
            }
        });
    }
}
