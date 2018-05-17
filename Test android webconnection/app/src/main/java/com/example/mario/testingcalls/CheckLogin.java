package com.example.mario.testingcalls;

import android.annotation.SuppressLint;
import android.os.AsyncTask;
import android.os.StrictMode;
import android.util.Log;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class CheckLogin extends AsyncTask<String,String,String> {
    @Override
    protected String doInBackground(String... strings) {
        // db variabelen
        Connection con;
        String username,password,database,ip,result;
        ip = "10.134.216.25";
        username= "dbuserTeam19";
        password="Inkooppo0";
        database="dbTeam19";
        result ="";
        try{
            con = connectionClass(username,password,database,ip);
            if (con ==null){
                result ="check internet";
            }else {
                String query = "select * from users where username ='Testgebruiker'";
                Statement statement = con.createStatement();
                ResultSet rs =statement.executeQuery(query);
                if(rs.next()){
                    result="good";
                    con.close();
                }else{
                    result="bad";
                }


            }
        }catch (Exception e){
            result= e.getMessage();
        }
        return result;
    }




    public Connection connectionClass(String user,String password,String database,String server){
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
        Connection connection =null;
        String connectionURL= null;
        try{
            Class.forName("net.sourceforge.jtds.jdbc.Driver");
            connectionURL ="jdbc:jtds:sqlserver://"+server+database+";user="+user+";password="+password+";";
            connection = DriverManager.getConnection(connectionURL);
        }catch (SQLException se){
            Log.e("sql error",se.getMessage());
        }catch (ClassNotFoundException cnfe){
            Log.e("classnotfound",cnfe.getMessage() );
        }catch (Exception e){
            Log.e("different error",e.getMessage());
        }
        return connection;
    }

}
