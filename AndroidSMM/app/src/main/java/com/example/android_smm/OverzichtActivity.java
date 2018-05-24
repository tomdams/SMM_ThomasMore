package com.example.android_smm;

import android.content.Intent;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.CardView;
import android.view.View;

import com.example.android_smm.Api.ApiClient;
import com.example.android_smm.Api.ApiInterface;
import com.example.android_smm.Domain.Alert;
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

    @BindView(R.id.signOutId)
    CardView signOutCardView;
    @BindView(R.id.colapppsingtoolbar)
    CollapsingToolbarLayout cTl;

    // API
    private ApiInterface apiInterface;
    private String APIresponse;
    private User currentUser;
    public int i = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_overzicht);
        ButterKnife.bind(this);
        Intent i = getIntent();
        currentUser = (User) i.getExtras().getSerializable("currentUser");
        cTl.setTitle(currentUser.getUsername());
        addEventHandlers();
    }


    private void addEventHandlers() {
        dashboardCardView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                //API
                /*Intent intent = new Intent(OverzichtActivity.this, DeelplatformActivity.class);
                intent.putExtra("currentUser",currentUser);
                startActivity(intent);*/



                final Map<String, String> data = new HashMap<>();
                data.put("username", currentUser.getUsername());
                data.put("password", currentUser.getWachtwoord());

                // MAARTEN : Dit is voor het ophalen van de deelplatformen, deze zijn aan te spreken in de dashboardactivity.

                apiInterface = ApiClient.getApiClient().create(ApiInterface.class);
                final Call<String> deelplatform = apiInterface.DeelplatformenVoorUser(data);
                deelplatform.enqueue(new Callback<String>() {
                    @Override
                    public void onResponse(Call<String> call, Response<String> response) {
                        APIresponse = response.body().toString();
                        List<Deelplatform> deelplatforms = (List<Deelplatform>) fromJson(APIresponse, new TypeToken<List<Deelplatform>>() {}.getType());

                        currentUser.setDeelplatformen(deelplatforms);


                        for (final Deelplatform d:currentUser.getDeelplatformen()) {
                            data.put("deelplatformid", String.valueOf(d.getId()));
                            apiInterface = ApiClient.getApiClient().create(ApiInterface.class);
                            final Call<String> grafiek = apiInterface.DashboardVoorGekozenDeelplatform(data);
                            grafiek.enqueue(new Callback<String>() {
                                @Override
                                public void onResponse(Call<String> call, Response<String> response) {
                                    APIresponse = response.body().toString();
                                    List<Grafiek> grafieks = (List<Grafiek>) fromJson(APIresponse, new TypeToken<List<Grafiek>>() {}.getType());
                                    d.setGrafieken(grafieks);
                                   // om te debuggen --> d = gevuld :)
                                    d.getGrafieken();


                                    i++;
                                    if(i == currentUser.getDeelplatformen().size()){
                                        Intent intent = new Intent(OverzichtActivity.this, DeelplatformActivity.class);
                                        // intent.putExtra("deelplatformen",(Serializable) deelplatforms);
                                        intent.putExtra("currentUser", currentUser);
                                        startActivity(intent);
                                    }
                    }
                                @Override
                                public void onFailure(Call<String> call, Throwable t) {
                                    String debug;
                                }
                            });
                        }
                    }
                    @Override
                    public void onFailure(Call<String> call, Throwable t) {
                        // error handling
                    }

                });
            }
        });














        notificationCardView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                final Map<String, String> data = new HashMap<>();
                data.put("username", currentUser.getUsername());
                data.put("password", currentUser.getWachtwoord());

                apiInterface = ApiClient.getApiClient().create(ApiInterface.class);
                final Call<String> notifications = apiInterface.GetAlertsVoorUser(data);
                notifications.enqueue(new Callback<String>() {
                    @Override
                    public void onResponse(Call<String> call, Response<String> response) {
                        APIresponse = response.body().toString();
                        List<Alert> alerts = (List<Alert>) fromJson(APIresponse,new TypeToken<List<Alert>>(){}.getType());

                        // check outcome
                        Intent intent = new Intent(OverzichtActivity.this, NotificationActivity.class);
                        currentUser.setAlerts(alerts);
                        intent.putExtra("currentUser", currentUser);
                        startActivity(intent);


                    }

                    @Override
                    public void onFailure(Call<String> call, Throwable t) {

                    }

                });



            }
        });



        signOutCardView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(OverzichtActivity.this, LoginActivity.class);
                currentUser = null;
                startActivity(intent);
            }
        });


    }

    public static Object fromJson(String jsonString, Type type) {
        return new Gson().fromJson(jsonString, type);
    }

    @Override
    public void onBackPressed() {
        moveTaskToBack(true);
    }
}
