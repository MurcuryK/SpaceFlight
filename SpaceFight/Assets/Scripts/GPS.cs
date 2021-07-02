using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{

    public Text uiTest;

    public static string latitude;
    public static string longitude;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLocationService());
    }

    private void Update()
    {
       // uiTest.text = "lat: " + latitude.ToString() + "     Lon: " + longitude.ToString();
    }

    private IEnumerator StartLocationService()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            latitude = Input.location.lastData.latitude.ToString();
            longitude = Input.location.lastData.longitude.ToString();

            //uiTest.text = ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude);
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();

        //latitude = Input.location.lastData.latitude;
        //longitude = Input.location.lastData.longitude;

       // yield break;
    }


}
