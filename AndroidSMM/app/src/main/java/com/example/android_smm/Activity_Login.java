package com.example.android_smm;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Button;

import butterknife.BindView;
import butterknife.ButterKnife;

public class Activity_Login extends AppCompatActivity {
    @BindView(R.id.button_signin) Button btn_signin;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity__login);
        ButterKnife.bind(this);

    }

    private void initializeComponents(){
        //button_signin = view
    }
}
