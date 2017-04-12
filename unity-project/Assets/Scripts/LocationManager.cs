using UnityEngine;
using System.Collections;

public class LocationManager : MonoBehaviour {
  public GameObject rotaterGO;

  // Use this for initialization
  IEnumerator Start(){

    //First, check if user has location service enabled
    if (!Input.location.isEnabledByUser){
      Debug.LogWarning("Location Service is Disabled");
      yield break;
    }


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
      Debug.LogWarning("Timed out");
      yield break;
    }


    // Connection has failed
    if (Input.location.status == LocationServiceStatus.Failed)
    {
      Debug.LogWarning("Unable to determine device location");
      yield break;
    }
    else
    {
      // Access granted and location value could be retrieved
      Debug.LogWarning("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
    }

    // Stop service if there is no need to query location updates continuously
    //Input.location.Stop();
  }


  // Update is called once per frame
  void Update () {
    //only update every 3 minutes
    if(Time.time % 3*60 == 0){
      serverUpdate();
      modelUpdate();
    }

  }

  void serverUpdate(){
    //WWW update
  }

  void modelUpdate(){
    //WWW request to the server
    //then just load the models at the right spot
  }
}
