package com.example.android_smm;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;

/**
 * Created by Maart on 7/05/2018.
 */

public class NotificationActivity extends AppCompatActivity {
    ArrayList<Notification> notifications;

    @BindView(R.id.lvNotifications)
    ListView lvNotifications;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_notification);
        ButterKnife.bind(this);
        addEventHandlers();

        //Data in een list steken
        notifications = new ArrayList<>();
        notifications.add(new Notification("Bart De Wever"));
        notifications.add(new Notification("Theo Francken"));

        //Data in de arrayadapter steken
        NotificationsAdapter notificationAdapter = new NotificationsAdapter(getBaseContext(), notifications);

        lvNotifications.setAdapter(notificationAdapter);

    }

    private void addEventHandlers(){
        lvNotifications.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                String selectedName = notifications.get(i).getOnderwerp();
                Toast.makeText(getBaseContext(), selectedName, Toast.LENGTH_LONG).show();
            }
        });
    }
}
