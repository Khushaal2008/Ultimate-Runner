using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AdManager : MonoBehaviour, IInterstitialAdListener
{
    public const string appKey = "3bfdd67549892cb1853e7e693a58bfd227c501f10c463a6f";
    bool consentValue = false;
    // Start is called before the first frame update
    void Start()
    {
        Appodeal.setAutoCache(Appodeal.INTERSTITIAL, false);
        Appodeal.cache(Appodeal.INTERSTITIAL);
        Appodeal.initialize(appKey, Appodeal.INTERSTITIAL, consentValue);
        Appodeal.setInterstitialCallbacks(this);
    }

    public void ToShowInterstitialAds()
    {
        //if(Appodeal.isLoaded(Appodeal.INTERSTITIAL)) 
        //{
	        Appodeal.show(Appodeal.INTERSTITIAL);	
       // }
    }

    #region Interstitial callback handlers

// Called when interstitial was loaded (precache flag shows if the loaded ad is precache)
public void onInterstitialLoaded(bool isPrecache) 
{ 
	Debug.Log("Interstitial loaded"); 
} 

// Called when interstitial failed to load
public void onInterstitialFailedToLoad() 
{ 
	Debug.Log("Interstitial failed"); 
} 

// Called when interstitial was loaded, but cannot be shown (internal network errors, placement settings, or incorrect creative)
public void onInterstitialShowFailed() 
{ 
	Debug.Log ("Interstitial show failed"); 
} 

// Called when interstitial is shown
public void onInterstitialShown() 
{ 
	Debug.Log("Interstitial opened"); 
} 

// Called when interstitial is closed
public void onInterstitialClosed() 
{ 
	Debug.Log("Interstitial closed"); 
} 

// Called when interstitial is clicked
public void onInterstitialClicked() 
{
	Debug.Log("Interstitial clicked"); 
} 

// Called when interstitial is expired and can not be shown
public void onInterstitialExpired() 
{
	Debug.Log("Interstitial expired"); 
} 

#endregion
}
