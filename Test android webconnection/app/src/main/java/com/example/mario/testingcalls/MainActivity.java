package com.example.mario.testingcalls;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.Checkable;
import android.widget.EditText;
import android.widget.TextView;




import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
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
        final EditText usernametext = findViewById(R.id.editText_username);
        final EditText passwordtext = findViewById(R.id.editText_password);
        Intent i = new Intent(MainActivity.this,receivedDataActivity.class);




       signin.setOnClickListener(new View.OnClickListener() {
           @Override
           public void onClick(View v) {
               CheckLogin checkLogin = new CheckLogin();
               checkLogin.execute("");
           }
       });




    }

}

