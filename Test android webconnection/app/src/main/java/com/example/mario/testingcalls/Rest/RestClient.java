package com.example.mario.testingcalls.Rest;

import android.widget.TextView;

import org.apache.http.HttpConnection;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.methods.HttpUriRequest;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpConnectionParams;
import org.apache.http.params.HttpParams;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.List;

import static java.net.Proxy.Type.HTTP;

public class RestClient
{
    public enum RequestMethod
    {
        GET,
        POST
    }

    public int responseCode=0;
    public String message;
    public String response;
    public String all;
    public void Execute(RequestMethod method, String url, List<NameValuePair> params) throws Exception
    {
        switch (method)
        {
            case GET:
            {
                // add parameters
                String combinedParams = "";
                if (params!=null)
                {
                    combinedParams += "?";
                    for (NameValuePair p : params)
                    {
                        String paramString = p.getName() + "=" + URLEncoder.encode(p.getValue(),"UTF-8");
                        if (combinedParams.length() > 1)
                            combinedParams += "&" + paramString;
                        else
                            combinedParams += paramString;
                    }
                }

                HttpGet request = new HttpGet(url + combinedParams);

                // example link:
                // ( werkt in PCbrowser)
                // http://localhost:11981/android/login?username=test&password=123
                executeRequest(request, url);
                break;




            }
            case POST:
            {
                HttpPost request = new HttpPost(url);
                if (params!=null)
                    request.setEntity(new UrlEncodedFormEntity(params, "UTF_8"));
                executeRequest(request, url);
                break;
            }
        }
    }






    private void executeRequest(HttpUriRequest request, String url)
    {

        HttpResponse httpResponse;
        HttpParams httpParams = new BasicHttpParams();
        HttpConnectionParams.setConnectionTimeout(httpParams,5000);
        HttpClient client = new DefaultHttpClient(httpParams);
        try
        {

            //url tonen in view om te testen
            all = request.getURI().toString();
            // Hier blijft hij hangen.....

            httpResponse = client.execute(request);



            responseCode = httpResponse.getStatusLine().getStatusCode();
            message = httpResponse.getStatusLine().getReasonPhrase();
            HttpEntity entity = httpResponse.getEntity();

            if (entity != null)
            {
                InputStream instream = entity.getContent();
                response = convertStreamToString(instream);
                instream.close();
            }
        }
        catch (Exception e)
        { }
    }


    private static String convertStreamToString(InputStream is)
    {
        BufferedReader reader = new BufferedReader(new InputStreamReader(is));
        StringBuilder sb = new StringBuilder();
        String line = null;
        try
        {
            while ((line = reader.readLine()) != null)
            {
                sb.append(line + "\n");
            }
            is.close();
        }
        catch (IOException e)
        { }
        return sb.toString();
    }
    public String getResponse(){
        return response;
    }
}