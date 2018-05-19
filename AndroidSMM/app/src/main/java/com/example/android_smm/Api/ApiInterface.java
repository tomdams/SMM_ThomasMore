package com.example.android_smm.Api;

import com.example.android_smm.Domain.User;

import java.util.Map;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Query;
import retrofit2.http.QueryMap;

public interface ApiInterface {
    @GET("GetUsername")
    Call<User> AuthenticateUser(@QueryMap Map<String, String> usertoVerify);
}




// 1 paramater naar de webapi meegeven voorbeeld
// Call<String> AuthenticateUser(@Query("username") String username);