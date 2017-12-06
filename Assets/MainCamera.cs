using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class MainCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RequestBanner();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void RequestBanner(){
	    #if UNITY_EDITOR
	        string adUnitId = "unused";
	    #elif UNITY_ANDROID
	        string adUnitId = "ca-app-pub-6539635200421204/6690344170";
	    #elif UNITY_IPHONE
	        string adUnitId = "ca-app-pub-6539635200421204/9709046174";
	    #else
	        string adUnitId = "unexpected_platform";
	    #endif

	    // Create a 320x50 banner at the top of the screen.
	    BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
	    // Create an empty ad request.
	    AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
	    // Load the banner with the request.
	    bannerView.LoadAd(request);
	}
}
