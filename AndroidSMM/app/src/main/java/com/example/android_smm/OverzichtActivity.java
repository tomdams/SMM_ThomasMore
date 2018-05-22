package com.example.android_smm;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.CardView;
import android.view.View;

import com.example.android_smm.Api.ApiClient;
import com.example.android_smm.Api.ApiInterface;
import com.example.android_smm.Domain.Deelplatform;
import com.example.android_smm.Domain.Grafiek;
import com.example.android_smm.Domain.User;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.io.Serializable;
import java.lang.reflect.Type;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import butterknife.BindView;
import butterknife.ButterKnife;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

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

    // API
    private ApiInterface apiInterface;
    private String APIresponse;



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

               //API



             /*

             Map<String, String> data = new HashMap<>();
                final User u =(User)getIntent().getExtras().getSerializable("username");
                data.put("username",u.getUsername());
                data.put("password",u.getWachtwoord());

                // MAARTEN : Dit is voor het ophalen van de deelplatformen, deze zijn aan te spreken in de dashboardactivity.

                apiInterface= ApiClient.getApiClient().create(ApiInterface.class);
                final Call<String> deelplatform = apiInterface.DeelplatformenVoorUser(data);
                deelplatform.enqueue(new Callback<String>() {
                    @Override
                    public void onResponse(Call<String> call, Response<String> response) {
                        APIresponse = response.body().toString();
                        List<Deelplatform> deelplatforms = (List<Deelplatform>) fromJson(APIresponse,new TypeToken<List<Deelplatform>>(){}.getType());

                        Intent intent = new Intent(OverzichtActivity.this, DashboardActivity.class);
                        intent.putExtra("username",u);
                        intent.putExtra("deelplatformen",(Serializable) deelplatforms);
                        startActivity(intent);
                    }

                    @Override
                    public void onFailure(Call<String> call, Throwable t) {
                            // error handling
                    }
                });

                */


                //MAARTEN : Dit is voor het ophalen van de grafieken voor een bepaald deelplaatform/dashboard van de user.
                //Plaats maar waar je het wil doen!
                Map<String, String> data = new HashMap<>();
                final User u =(User)getIntent().getExtras().getSerializable("username");
                data.put("username",u.getUsername());
                data.put("password",u.getWachtwoord());
                // de 1 te vervangen door opgehaalde deelplatformid van bovenstaande API call
                data.put("deelplatformid","1");


                apiInterface=ApiClient.getApiClient().create(ApiInterface.class);
                final Call<String> grafiek = apiInterface.DashboardVoorGekozenDeelplatform(data);
                grafiek.enqueue(new Callback<String>() {
                    @Override
                    public void onResponse(Call<String > call, Response<String> response) {
                        APIresponse = response.body().toString();
                        List<Grafiek> grafieks = (List<Grafiek>) fromJson(APIresponse,new TypeToken<List<Grafiek>>(){}.getType());

                        Intent intent = new Intent(OverzichtActivity.this, DashboardActivity.class);
                        intent.putExtra("username",u);
                        intent.putExtra("grafieken",(Serializable) grafieks);
                        startActivity(intent);
                    }

                    @Override
                    public void onFailure(Call<String> call, Throwable t) {
                        String debug;
                    }
                });


















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
    public static Object fromJson(String jsonString, Type type) {
        return new Gson().fromJson(jsonString, type);
    }
}
