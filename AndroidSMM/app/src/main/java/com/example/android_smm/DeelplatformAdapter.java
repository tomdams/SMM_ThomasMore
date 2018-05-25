package com.example.android_smm;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.android_smm.Domain.Deelplatform;

import java.util.ArrayList;

import butterknife.BindView;

/**
 * Created by Maart on 20/05/2018.
 */

public class DeelplatformAdapter extends ArrayAdapter{


    public DeelplatformAdapter(@NonNull Context context, @NonNull ArrayList<Deelplatform> deelplatforms) {
        super(context, -1, deelplatforms);

    }



    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        Deelplatform deelplatform = (Deelplatform)getItem(position);

        if(convertView == null){
            LayoutInflater inflater = (LayoutInflater) getContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(R.layout.dashboard_list_item, parent, false);
        }

        TextView tvOnderwerp = convertView.findViewById(R.id.tvOnderwerp);
        TextView tvAantalGrafs = convertView.findViewById(R.id.tvAantalGrafs);
        ImageView ivDashboard = convertView.findViewById(R.id.ivDashboard);
        ImageView ivChart = convertView.findViewById(R.id.ivChart);
        tvOnderwerp.setText(deelplatform.getNaam());
        tvAantalGrafs.setText(deelplatform.getGrafieken().size()+"");
        ivChart.setImageResource(R.drawable.chart);
        ivDashboard.setImageResource(R.drawable.dashboard);

        return convertView;
    }
}
