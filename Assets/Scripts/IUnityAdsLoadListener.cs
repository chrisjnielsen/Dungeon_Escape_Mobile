using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public interface IUnityAdsLoadListener
{
    void OnUnityAdsAdLoaded(string adUnitId);
    void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message);
}
