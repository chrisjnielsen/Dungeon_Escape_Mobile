using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;


public class AdsManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{

    private int _rewardValue = 100;
    private Player _player;
     
    [SerializeField] string _androidAdUnitId = "Rewarded_Android"; 
    [SerializeField] string _iOsAdUnitId = "Rewarded_iOS";
    string _adUnitId;

    public Button unityAdButton;

    private void Awake()
    {
        
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (_player == null)
            Debug.Log("Player is null");
        
            // Get the Ad Unit ID for the current platform:
            _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? _iOsAdUnitId
                : _androidAdUnitId;

            //Disable button until ad is ready to show
            unityAdButton.interactable = false;
        

    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Enable the button for users to click:
            unityAdButton.interactable = true;
            // Configure the button to call the ShowAd() method when clicked:
            unityAdButton.onClick.AddListener(ShowAd);
            
        }
    }


    // Implement a method to execute when the user clicks the button.
    public void ShowAd()
    {
        // Disable the button: 
        unityAdButton.interactable = false;
        // Then show the ad:
        Advertisement.Show(_adUnitId);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.
            _player.AddGems(_rewardValue);

            // Load another ad:
            Advertisement.Load(_adUnitId);
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        unityAdButton.onClick.RemoveAllListeners();
    }

  
}
