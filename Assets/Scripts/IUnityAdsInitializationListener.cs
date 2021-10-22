using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public interface IUnityAdsInitializationListener
{
    void OnInitializationComplete();
    void OnInitializationFailed(UnityAdsInitializationError error, string message);
}
