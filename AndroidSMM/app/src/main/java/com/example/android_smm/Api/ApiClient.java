package com.example.android_smm.Api;

import com.google.gson.Gson;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.GET;

import static retrofit2.converter.gson.GsonConverterFactory.create;

/**
 * Created by mario on 18-5-2018.
 */

public class ApiClient {

    public static final String BASE_URL="http://10.0.2.2:11981/api/android/";
   // public static final String BASE_URL="http://10.134.216.25:8019/api/android";
    public static Retrofit retrofit=null;

    public  static Retrofit getApiClient(){

        if (retrofit==null){
            retrofit = new Retrofit.Builder().baseUrl(BASE_URL).addConverterFactory(GsonConverterFactory.create()).build();
        }
        return retrofit;

    }
}
