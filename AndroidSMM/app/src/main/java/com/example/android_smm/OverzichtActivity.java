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
    @BindView(R.id.notificationId)
    CardView notificationCardView;
    @BindView(R.id.accountSettingsId)
    CardView accountSettingsCardView;
    @BindView(R.id.chartSettingsId)
    CardView chardSettingsCardView;
    @BindView(R.id.signOutId)
    CardView signOutCardView;

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

        notificationCardView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(OverzichtActivity.this, NotificationActivity.class);
                startActivity(intent);
            }
        });

        accountSettingsCardView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(OverzichtActivity.this, AccountSettingsActivity.class);
                startActivity(intent);
            }
        });

        chardSettingsCardView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(OverzichtActivity.this, ChartSettingsActivity.class);
                startActivity(intent);
            }
        });

        signOutCardView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(OverzichtActivity.this, LoginActivity.class);
                startActivity(intent);
            }
        });


    }
}
