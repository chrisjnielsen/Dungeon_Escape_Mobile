using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOsGameId;
    [SerializeField] bool _testMode = true;
    [SerializeField] bool _enablePerPlacementMode = true;
    [SerializeField] GameObject _rewardAdButton;
    private string _gameId;

    void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        //_gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
        //    ? _iOsGameId
        //    : _androidGameId;
        _gameId = _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, _enablePerPlacementMode, _rewardAdButton.GetComponent<RewardedAdsButton>());
    }

    public void OnInitializationComplete()
    {
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {

    }
}