using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class Trailer : MonoBehaviour, IPermissionGrantedListener
{
    void Awake() {
        Appodeal.disableLocationPermissionCheck();
        //Appodeal.disableWriteExternalStoragePermissionCheck();
        Appodeal.requestAndroidMPermissions(this);
    }

    public void writeExternalStorageResponse(int result) { 
  if(result == 0) {
    Debug.Log("WRITE_EXTERNAL_STORAGE permission granted"); 
  } else {
    Debug.Log("WRITE_EXTERNAL_STORAGE permission grant refused"); 
  }
}
public void accessCoarseLocationResponse(int result) { 
  if(result == 0) {
    Debug.Log("ACCESS_COARSE_LOCATION permission granted"); 
  } else {
    Debug.Log("ACCESS_COARSE_LOCATION permission grant refused"); 
  }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
