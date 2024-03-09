using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class RewardAd : MonoBehaviour, IRewardedVideoAdListener
{
    public const string appKey = "3bfdd67549892cb1853e7e693a58bfd227c501f10c463a6f";
    bool consentValue = false;
    // Start is called before the first frame update
    void Start()
    {
       Appodeal.setAutoCache(Appodeal.REWARDED_VIDEO, false);
       Appodeal.cache(Appodeal.REWARDED_VIDEO);
       Appodeal.initialize(appKey, Appodeal.REWARDED_VIDEO, consentValue);
       Appodeal.setRewardedVideoCallbacks(this);
    }

    public void ToShowRewardAds()
    {
        Appodeal.show(Appodeal.REWARDED_VIDEO);
    }

    #region Rewarded Video callback handlers

//Called when rewarded video was loaded (precache flag shows if the loaded ad is precache).
public void onRewardedVideoLoaded(bool isPrecache) 
{ 
	print("Video loaded"); 
} 

// Called when rewarded video failed to load
public void onRewardedVideoFailedToLoad() 
{ 
	print("Video failed"); 
} 

// Called when rewarded video was loaded, but cannot be shown (internal network errors, placement settings, or incorrect creative)
public void onRewardedVideoShowFailed() 
{ 
	print ("Video show failed"); 
} 

// Called when rewarded video is shown
public void onRewardedVideoShown() 
{ 
	print("Video shown"); 
} 

// Called when reward video is clicked
public void onRewardedVideoClicked()
{ 
	print("Video clicked"); 
} 

// Called when rewarded video is closed
public void onRewardedVideoClosed(bool finished) 
{ 
	print("Video closed"); 
}

// Called when rewarded video is viewed until the end
public void onRewardedVideoFinished(double amount, string name) 
{ 
	print("Reward: " + amount + " " + name); 
}

//Called when rewarded video is expired and can not be shown
public void onRewardedVideoExpired() 
{ 
	print("Video expired"); 
}
 
#endregion
}
