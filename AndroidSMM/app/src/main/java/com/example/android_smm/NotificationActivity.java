package com.example.android_smm;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import com.example.android_smm.Domain.Alert;
import com.example.android_smm.Domain.User;

import java.util.ArrayList;

import butterknife.BindView;
import butterknife.ButterKnife;

/**
 * Created by Maart on 7/05/2018.
 */

public class NotificationActivity extends AppCompatActivity {
    ArrayList<Alert> alertList;
    private User currentUser;

    @BindView(R.id.lvNotifications)
    ListView lvNotifications;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_notification);
        ButterKnife.bind(this);
        currentUser = (User) getIntent().getExtras().getSerializable("currentUser");
        addEventHandlers();

        //Data in een list steken
        alertList = new ArrayList<>();
        //alertList.add(new Notification("Bart De Wever"));
        //alertList.add(new Notification("Theo Francken"));
        for (int i = currentUser.getAlerts().size()-1; i>=0; i--){
            alertList.add(currentUser.getAlerts().get(i));

        }


        //Data in de arrayadapter steken
        NotificationsAdapter notificationAdapter = new NotificationsAdapter(getBaseContext(), alertList);

        lvNotifications.setAdapter(notificationAdapter);

    }

    private void addEventHandlers(){
        lvNotifications.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                String selectedName = alertList.get(i).getMessage();
                Toast.makeText(getBaseContext(), selectedName, Toast.LENGTH_LONG).show();
            }
        });
    }
}
