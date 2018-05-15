package com.example.android_smm;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import java.io.Console;

/**
 * Created by Maart on 20/04/2018.
 */

public class DatabaseHelper extends SQLiteOpenHelper {
    public static final String DATABASE_NAME = "SMMDatabase";
    public static final String TABLE_NAME = "dbo.Users";
    public static final String COL1 = "id";
    public static final String COL2 = "email";
    public static final String COL3 = "wachtwoord";
    public static final String COL4 = "username";
    public static final String COL5 = "type";
    public static final String COL6 = "compareWachtwoord";
    public DatabaseHelper(Context context) {
        super(context, DATABASE_NAME, null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {

    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {

    }

    public String getWachtwoord(String email){
        SQLiteDatabase db = this.getWritableDatabase();


        Cursor res = db.rawQuery("select email from " + TABLE_NAME , null);
        return res.getString(0);
    }
}
