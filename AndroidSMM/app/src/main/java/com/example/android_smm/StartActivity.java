package com.example.android_smm;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.ImageView;
import android.widget.TextView;

import butterknife.BindView;
import butterknife.ButterKnife;

/**
 * Created by Maart on 25/05/2018.
 */

public class StartActivity extends AppCompatActivity{
    @BindView(R.id.tvTitel)
    TextView tvTitel;

    @BindView(R.id.tvDescription)
    TextView tvDescription;

    @BindView(R.id.ivWorld)
    ImageView ivWorld;


    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_start);
        ButterKnife.bind(this);

        Animation myAnim=  AnimationUtils.loadAnimation(this, R.anim.mytransition);
        tvTitel.startAnimation(myAnim);
        tvDescription.startAnimation(myAnim);
        ivWorld.setAnimation(myAnim);
        final Intent loginIntent = new Intent(StartActivity.this, LoginActivity.class);
        Thread timer = new Thread() {
            public void run() {
                try {
                    sleep(5000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                } finally {
                    startActivity(loginIntent);
                    finish();
                }
            }




        };

        timer.start();

    }

    @Override
    public void onBackPressed() {
        moveTaskToBack(true);
    }
}
