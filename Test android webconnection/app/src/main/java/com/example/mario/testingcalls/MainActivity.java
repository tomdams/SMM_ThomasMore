package com.example.mario.testingcalls;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.example.mario.testingcalls.Rest.RestClient;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.jar.Attributes;


public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button signin = findViewById(R.id.button_signin);
        final EditText username = findViewById(R.id.editText_username);
        final EditText password = findViewById(R.id.editText_password);

        signin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String response;
                Intent i = new Intent(MainActivity.this,receivedDataActivity.class);
                RestClient rc = new RestClient();

                List<NameValuePair> parameters = new ArrayList<NameValuePair>();
                parameters.add(new BasicNameValuePair("username",username.getText().toString()));
                parameters.add(new BasicNameValuePair("password",password.getText().toString()));

                try {
                    rc.Execute(RestClient.RequestMethod.GET, "http://localhost:11981/android/login", parameters);
                    response=rc.getResponse();
                }catch(Exception e){
                    response= e.getMessage();
                }
                if (response ==null){
                    response=rc.all;
                }

                i.putExtra("response",response);
                startActivity(i);
            }
        });
    }

}
