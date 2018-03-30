package com.example.android_smm;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Button;

public class Activity_Login extends AppCompatActivity {
    private Button button_signin;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity__login);
    }

    private void initializeComponents(){
        //button_signin = view
    }
}
