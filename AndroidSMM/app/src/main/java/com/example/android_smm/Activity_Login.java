package com.example.android_smm;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.widget.Button;
import android.widget.EditText;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;

public class Activity_Login extends AppCompatActivity {
    @BindView(R.id.button_signin)
    Button buttonSignin;
    @BindView(R.id.editText_username)
    EditText editTextUsername;
    @BindView(R.id.editText_password)
    EditText editTextPassword;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity__login);
        ButterKnife.bind(this);

    }

    @OnClick(R.id.button_signin)
    public void onViewClicked() {
        if(!editTextPassword.getText().toString().isEmpty() && !editTextUsername.getText().toString().isEmpty()){
            Intent intent = new Intent(Activity_Login.this, Dashboard_Activity.class);
            startActivity(intent);
        }

    }
}
