package com.example.android_smm;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.android_smm.Domain.Deelplatform;
import com.example.android_smm.Domain.User;

import java.io.Serializable;
import java.util.ArrayList;

import butterknife.BindView;
import butterknife.ButterKnife;



public  class DeelplatformActivity extends AppCompatActivity {

    ArrayList<Deelplatform> deelplatformen;
    @BindView(R.id.lvDashboard)
    ListView lvDashboarden;
    User currentUser;


    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_deelplatformen);
        ButterKnife.bind(this);
        currentUser = (User) getIntent().getExtras().getSerializable("currentUser");

        deelplatformen = new ArrayList<>();

        for (int i =0; i<currentUser.getDeelplatformen().size();i++){
            deelplatformen.add(currentUser.getDeelplatformen().get(i));
        }

        DeelplatformAdapter deelplatformAdapter = new DeelplatformAdapter(getBaseContext(), deelplatformen);

        lvDashboarden.setAdapter(deelplatformAdapter);

        addEventhandlers();

    }

    private void addEventhandlers(){
        lvDashboarden.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                TextView tv = (TextView) view.findViewById(R.id.tvOnderwerp);
                String deelplatformNaam = tv.getText().toString();
                //Toast.makeText(getApplicationContext(), tv.getText(), Toast.LENGTH_SHORT).show();

                Deelplatform clickedDeelplatform = currentUser.getDeelplatform(deelplatformNaam);

                Intent intent = new Intent(DeelplatformActivity.this, DashboardActivity.class);
                intent.putExtra("clickedDeelplatform", clickedDeelplatform);

                startActivity(intent);
            }
        });
    }
}

