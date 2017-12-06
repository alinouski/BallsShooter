using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "customAds", menuName = "Ads/Custom")]
public class AdsCustom : AdsComponent
{
    public bool showLogs = true;

    #region Fetch_ADS
    public override void FetchAds(AdsElement type)
    {
        if (!AdsController.NoAds && showLogs)
        {
            Debug.Log(string.Format("ads {0} fetched", type.name));
        }
    }
    #endregion

    public override void Init()
    {
        if (!AdsController.NoAds && showLogs)
        {
            Debug.Log("Ads inited");
            SetCallbacks();
        }
    }

    #region IsAvilable_ADS
    public override bool IsAvilable(AdsElement type)
    {
        if (!AdsController.NoAds && showLogs)
        {
            Debug.Log(string.Format("ads {0} avilable", type.name));
        }
        return false;
    }
    #endregion

    public override void SetCallbacks()
    {
        if (showLogs)
        {
            Debug.Log(string.Format("ads callbacks seted"));
        }
        #region banner_callback
       
        #endregion

        #region interstitial_callback
        
        #endregion

        #region video_callback
       
        #endregion

        #region rewarded_callback
        
        #endregion
    }

    public override void Show(AdsElement type)
    {
        if (!AdsController.NoAds && showLogs)
        {
            Debug.Log(string.Format("ads {0} show", type.name));
        }
    }
}
