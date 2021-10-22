using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public interface IUnityAdsShowListener
{
    void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message);
    void OnUnityAdsShowStart(string adUnitId);
    void OnUnityAdsShowClick(string adUnitId);
    void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState);
}
