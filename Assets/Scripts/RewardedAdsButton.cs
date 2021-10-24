using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsListener, IUnityAdsInitializationListener
{
    [SerializeField] Button _showAdButton;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    //[SerializeField] string _iOsAdUnitId = "Rewarded_iOS";
    public string _adUnitId;
    private Timer _time;
    private bool _timerRunning;
    public float _adWatchTime;    

    void Awake()
    {
        _adUnitId = _androidAdUnitId;
        Advertisement.AddListener(this);
        _time = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        _adWatchTime = 0;
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            _showAdButton.onClick.AddListener(ShowAd);
            
            // Enable the button for users to click:
            _showAdButton.interactable = true;
        }
    }

    // Implement a method to execute when the user clicks the button.
    public void ShowAd()
    {
        // Disable the button: 
        _showAdButton.interactable = false;
        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        _adWatchTime += Time.deltaTime;
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            GameManager.Instance.Player.AddGems(100);
            UIManager.Instance.OpenShop(GameManager.Instance.Player.diamonds);
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

    public void OnUnityAdsShowStart(string adUnitId) 
    {
        
    }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        _showAdButton.onClick.RemoveAllListeners();
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _adUnitId)
        {
            _showAdButton.interactable = true;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("Ad Finished");
        StartCoroutine(WaitforNewAds());
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        LoadAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public bool TimerRunning(bool timer)
    {
        return _timerRunning = timer;
    }

   IEnumerator WaitforNewAds()
    {
        Debug.Log("Run Coroutine");
        float waitforAd = 20f - _adWatchTime;
        Debug.Log(waitforAd);
        if (waitforAd > 0) 
        {
            _time.ChangeAdDisplay(20f - _adWatchTime);
            yield return new WaitForSeconds(20f - _adWatchTime);
            Debug.Log("LoadAd called");
            LoadAd();
        }
        else
        {
            _time.ChangeAdDisplay(0);
            yield return new WaitForSeconds(0.5f);   
            LoadAd();
        }  
    }
}
