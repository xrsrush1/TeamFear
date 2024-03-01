using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;

public class AirtableManager : MonoBehaviour
{   

    [Header("Airtable Elements")]
    // Airtable API endpoint and authentication details
    public string airtableEndpoint = "https://api.airtable.com/v0/";
    public string accessToken = "YOUR_ACCESS_TOKEN";
    public string baseId = "YOUR_BASE_ID";
    public string tableName = "YOUR_TABLE_NAME";
    

    [Header("Data For Airtable")]
    // Data fields for recording information
    public string dateTime;
    public string question1;
    public string question2;
    public string question3;
    public string question4;
    public string question5;
    public string time;
      

    // Method to create a new record in Airtable
    public void CreateRecord()
    {
       
        // Get the current date and time
        dateTime = DateTime.Now.ToString("dd.MM.yyyy HH.mm");

        // Create the URL for the API request
        string url = airtableEndpoint + baseId + "/" + tableName;

        // Create JSON data for the API request
        string jsonFields = "{\"fields\": {" +
                                    "\"DateTime\":\"" + dateTime + "\", " +
                                    "\"questionone\":\"" + question1 + "\", " +
                                    "\"questiontwo\":\"" + question2 + "\", " +
                                    "\"questionthree\":\"" + question3 + "\", " +
                                    "\"questionfour\":\"" + question4 + "\", " +
                                    "\"questionfive\":\"" + question5 + "\", " +
                                    "\"time\":\"" + time + "\"" +
                                    "}}";

        // Start the coroutine to send the API request
        StartCoroutine(SendRequest(url, "POST", response =>
        {
            // Log the response from the API
            Debug.Log("Record created: " + response);
                        
        }, jsonFields));
    }

    // Coroutine to make API requests
    private IEnumerator SendRequest(string url, string method, Action<string> callback, string jsonData = "")
    {
        // Create a HTTP web request
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = method;
        request.ContentType = "application/json";
        request.Headers["Authorization"] = "Bearer " + accessToken;

        // Include JSON data in the request if provided
        if (!string.IsNullOrEmpty(jsonData))
        {
            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(jsonData);
            }
        }

        // Get the response from the API
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string jsonResponse = reader.ReadToEnd();
                // Invoke the callback with the response
                if (callback != null)
                {
                    callback(jsonResponse);
                }
            }
        }

        // Yield to the next frame
        yield return null;
    }    
}
