package com.example.android_smm;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.widget.Button;
import android.widget.EditText;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

import com.example.android_smm.Api.ApiClient;
import com.example.android_smm.Api.ApiInterface;
import com.example.android_smm.Domain.User;
import com.facebook.CallbackManager;
import com.facebook.FacebookCallback;
import com.facebook.FacebookException;
import com.facebook.GraphRequest;
import com.facebook.GraphResponse;
import com.facebook.login.LoginManager;
import com.facebook.login.LoginResult;
import com.facebook.login.widget.LoginButton;
import com.google.gson.Gson;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

public class LoginActivity extends AppCompatActivity {
    @BindView(R.id.button_signin)
    Button buttonSignin;
    @BindView(R.id.editText_username)
    EditText editTextUsername;
    @BindView(R.id.editText_password)
    EditText editTextPassword;
    @BindView(R.id.facebooklogo)
    LoginButton facebookLogoLogin;

    CallbackManager callbackManager;
    DatabaseHelper databaseHelper;


    // API
    private ApiInterface apiInterface;
    private String opgehaaldeUser;
    private User jsonuser;

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        callbackManager.onActivityResult(requestCode, resultCode, data);
        super.onActivityResult(requestCode, resultCode, data);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        databaseHelper = new DatabaseHelper(this);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity__login);
        ButterKnife.bind(this);
        callbackManager = CallbackManager.Factory.create();
        final String EMAIL = "email";
        facebookLogoLogin.setReadPermissions(Arrays.asList("email", "public_profile"));












        LoginManager.getInstance().registerCallback(callbackManager, new FacebookCallback<LoginResult>() {
            @Override
            public void onSuccess(LoginResult loginResult) {
                String userid= loginResult.getAccessToken().getUserId();

                GraphRequest graphRequest = GraphRequest.newMeRequest(loginResult.getAccessToken(), new GraphRequest.GraphJSONObjectCallback() {
                    @Override
                    public void onCompleted(JSONObject object, GraphResponse response) {
                        displayUserInfo(object);
                        String x = "jow";
                        String email = "test";
                        try {
                            email = object.getString("email");
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                        x = databaseHelper.getWachtwoord(email);

                        buttonSignin.setText(x);
                    }
                });
                Bundle parameters = new Bundle();
                parameters.putString("fields", "first_name, last_name, email, id");
                graphRequest.setParameters(parameters);
                graphRequest.executeAsync();
            }

            @Override
            public void onCancel() {

            }

            @Override
            public void onError(FacebookException error) {

            }
        });



    }

    @OnClick(R.id.button_signin)
    public void onViewClicked() {
        if(!editTextPassword.getText().toString().isEmpty() && !editTextUsername.getText().toString().isEmpty()){
          final  Intent intent = new Intent(LoginActivity.this, OverzichtActivity.class);




          // API
            Map<String, String> data = new HashMap<>();
            data.put("username", editTextUsername.getText().toString());
            data.put("password", editTextPassword.getText().toString());

            apiInterface= ApiClient.getApiClient().create(ApiInterface.class);
            final Call<String> user = apiInterface.AuthenticateUser(data);
            user.enqueue(new Callback<String>() {
                 @Override
                 public void onResponse(Call<String> call, Response<String> response) {
                     opgehaaldeUser=response.body();
                     Gson gson = new Gson();
                     jsonuser=gson.fromJson(opgehaaldeUser,User.class);

                     if(jsonuser != null){
                         if (jsonuser.isConfirmEmail()){
                             intent.putExtra("username",jsonuser);
                             startActivity(intent);
                         }
                     }

                 }

         @Override
         public void onFailure(Call<String> call, Throwable t) {
            jsonuser=null;
            // eventueel melding geven nog ?
         }
     });






        }

    }

    public void displayUserInfo(JSONObject object){
        String first_name, last_name, email, id;
        try {
            first_name = object.getString("first_name");
            last_name = object.getString("last_name");
            email = object.getString("email");
            id = object.getString("id");
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }


}
