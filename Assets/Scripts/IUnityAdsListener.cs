using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public interface IUnityAdsListener
{
    

    void OnUnityAdsReady(string placementID);
    void OnUnityAdsDidError(string message);
    void OnUnityAdsDidStart(string placementID);
    void OnUnityAdsDidFinish(string placementID, ShowResult showResult);


}
