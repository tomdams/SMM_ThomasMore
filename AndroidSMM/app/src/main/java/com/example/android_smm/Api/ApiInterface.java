package com.example.android_smm.Api;

import java.util.Map;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.QueryMap;

public interface ApiInterface {
    @GET("Getuser")
    Call<String> AuthenticateUser(@QueryMap Map<String, String> userToAuthenticate);
    @GET("Getdeelplatformen")
    Call<String> DeelplatformenVoorUser(@QueryMap Map<String, String> user);
    @GET("Getgrafieken")
    Call<String> DashboardVoorGekozenDeelplatform(@QueryMap Map<String, String> user_deelplatformid);
}




