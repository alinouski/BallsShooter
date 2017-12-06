using UnityEngine;
using System.Collections;
using System;
#if HEYZAP
using Heyzap;

[CreateAssetMenu(fileName ="heyzapAds", menuName = "Ads/Heyzap")]
public class AdsHeyzap : AdsComponent
{
    public string apiKey = "004f95322e0abbd38a67f81d8c2e188e";
    public bool showBanner = true;

#region Fetch_ADS
    public override void FetchAds(AdsElement type)
    {
        if (!AdsController.NoAds)
        {
            switch (type.type)
            {
                case AdsType.Banner:
                    break;
                case AdsType.Interstitial:
                    HZInterstitialAd.Fetch(type.name);
                    break;
                case AdsType.Video:
                    HZVideoAd.Fetch(type.name);
                    break;
                case AdsType.RewardedVideo:
                    HZIncentivizedAd.Fetch(type.name);
                    break;
            }
        }
    }
#endregion

    public override void Init()
    {
        if (!AdsController.NoAds)
        {
            HeyzapAds.Start(apiKey, HeyzapAds.FLAG_DISABLE_AUTOMATIC_FETCHING);

            SetCallbacks();
            if (showBanner)
            {
                HZBannerShowOptions showOptions = new HZBannerShowOptions();
                showOptions.Position = HZBannerShowOptions.POSITION_BOTTOM;               
                HZBannerAd.ShowWithOptions(showOptions);
            }

            for (int i = values.Count - 1; i >= 0; i--)
            {
                FetchAds(values[i]);
            }
        }
    }

#region IsAvilable_ADS
    public override bool IsAvilable(AdsElement type)
    {
        if (!AdsController.NoAds)
        {
            switch (type.type)
            {
                case AdsType.Interstitial:
                    HZInterstitialAd.IsAvailable(type.name);
                    break;
                case AdsType.Video:
                    HZVideoAd.IsAvailable(type.name);
                    break;
                case AdsType.RewardedVideo:
                    HZIncentivizedAd.IsAvailable(type.name);
                    break;
            }
        }
        return false;
    }
#endregion

    public override void SetCallbacks()
    {
#region banner_callback
        HZBannerAd.AdDisplayListener listener = delegate (string adState, string adTag)
        {
            if (adState == "click")
            {
                ClickAdsEvent(adTag);
                Analytic.Instance.CustomEvent("ADS", "Banner_click", "");
            }
            if (adState == "loaded")
            {
                // Do something when the banner ad is loaded
            }
            if (adState == "error")
            {
                // Do something when the banner ad fails to load (they can fail when refreshing after successfully loading)
            }
        };
        HZBannerAd.SetDisplayListener(listener);
#endregion

#region interstitial_callback
        HZInterstitialAd.AdDisplayListener listenerInterstitial = delegate (string adState, string adTag) {
            if (adState.Equals("show"))
            {
                ShowAdsEvent(adTag);
                Analytic.Instance.CustomEvent("ADS", "show", adTag);
            }
            if (adState.Equals("hide"))
            {
                Analytic.Instance.CustomEvent("ADS", "hide", adTag);
            }
            if (adState.Equals("click"))
            {
                ClickAdsEvent(adTag);
                Analytic.Instance.CustomEvent("ADS", "click", adTag);
            }
            if (adState.Equals("failed"))
            {
                Analytic.Instance.CustomEvent("ADS", "failed", adTag);
            }
            if (adState.Equals("available"))
            {
                AvailableAdsEvent(adTag);
                Analytic.Instance.CustomEvent("ADS", "available", adTag);
            }
            if (adState.Equals("fetch_failed"))
            {
                Analytic.Instance.CustomEvent("ADS", "fetch_failed", adTag);
            }
            if (adState.Equals("audio_starting"))
            {
                Analytic.Instance.CustomEvent("ADS", "audio_starting", adTag);
            }
            if (adState.Equals("audio_finished"))
            {
                Analytic.Instance.CustomEvent("ADS", "audio_finished", adTag);
            }
        };

        HZInterstitialAd.SetDisplayListener(listenerInterstitial);
#endregion

#region video_callback
        HZVideoAd.AdDisplayListener listenerVideo= delegate (string adState, string adTag) {
            if (adState.Equals("show"))
            {
                ShowAdsEvent(adTag);
                Analytic.Instance.CustomEvent("ADS", "show", adTag);
            }
            if (adState.Equals("hide"))
            {
                Analytic.Instance.CustomEvent("ADS", "hide", adTag);
            }
            if (adState.Equals("click"))
            {
                ClickAdsEvent(adTag);
                Analytic.Instance.CustomEvent("ADS", "click", adTag);
            }
            if (adState.Equals("failed"))
            {
                Analytic.Instance.CustomEvent("ADS", "failed", adTag);
            }
            if (adState.Equals("available"))
            {
                AvailableAdsEvent(adTag);
                Analytic.Instance.CustomEvent("ADS", "available", adTag);
            }
            if (adState.Equals("fetch_failed"))
            {
                Analytic.Instance.CustomEvent("ADS", "fetch_failed", adTag);
            }
            if (adState.Equals("audio_starting"))
            {
                Analytic.Instance.CustomEvent("ADS", "audio_starting", adTag);
            }
            if (adState.Equals("audio_finished"))
            {
                Analytic.Instance.CustomEvent("ADS", "audio_finished", adTag);
            }
        };

        HZVideoAd.SetDisplayListener(listenerVideo);
#endregion

#region rewarded_callback
        HZIncentivizedAd.AdDisplayListener listenerRewarded = delegate (string adState, string adTag) {
            if (adState.Equals("show"))
            {                
                Analytic.Instance.CustomEvent("ADS", "show", adTag);
            }
            if (adState.Equals("hide"))
            {
                Analytic.Instance.CustomEvent("ADS", "hide", adTag);
            }
            if (adState.Equals("click"))
            {
                ClickAdsEvent(adTag);
                Analytic.Instance.CustomEvent("ADS", "click", adTag);
            }
            if (adState.Equals("failed"))
            {
                Analytic.Instance.CustomEvent("ADS", "failed", adTag);
            }
            if (adState.Equals("available"))
            {
                AvailableAdsEvent(adTag);
                Analytic.Instance.CustomEvent("ADS", "available", adTag);
            }
            if (adState.Equals("fetch_failed"))
            {
                Analytic.Instance.CustomEvent("ADS", "fetch_failed", adTag);
            }
            if (adState.Equals("audio_starting"))
            {
                Analytic.Instance.CustomEvent("ADS", "audio_starting", adTag);
            }
            if (adState.Equals("audio_finished"))
            {
                Analytic.Instance.CustomEvent("ADS", "audio_finished", adTag);
            }
            if (adState.Equals("incentivized_result_complete"))
            {
                ShowAdsEvent(adTag);
                Analytic.Instance.CustomEvent("ADS", "incentivized_result_complete", adTag);
            }
            if (adState.Equals("incentivized_result_incomplete"))
            {
                Analytic.Instance.CustomEvent("ADS", "incentivized_result_incomplete", adTag);
            }
        };

        HZIncentivizedAd.SetDisplayListener(listenerRewarded);
#endregion
    }

    private void ClickAdsEvent(string adsTag)
    {
        for (int i = values.Count - 1; i >= 0; i--)
        {
            if (values[i].name == adsTag)
            {
                values[i].AdsClick();
                break;
            }
        }
    }

    private void ShowAdsEvent(string adsTag)
    {
        for (int i = values.Count - 1; i >= 0; i--)
        {
            if (values[i].name == adsTag)
            {
                values[i].AdsWatch();
                values[i].IsReady = false;
                FetchAds(values[i]);
                break;
            }
        }
    }

    private void AvailableAdsEvent(string adsTag)
    {
        for (int i = values.Count - 1; i >= 0; i--)
        {
            if(values[i].name == adsTag)
            {
                values[i].IsReady = true;
                break;
            }
        }
    }

    public override void Show(AdsElement type)
    {
        if (!AdsController.NoAds)
        {
            
            switch (type.type)
            {
                case AdsType.Interstitial:
                    HZShowOptions showOptions = new HZShowOptions();
                    showOptions.Tag = type.name;
                    HZInterstitialAd.ShowWithOptions(showOptions);
                    break;
                case AdsType.Video:
                    HZShowOptions showOptionsVideo = new HZShowOptions();
                    showOptionsVideo.Tag = type.name;
                    HZVideoAd.ShowWithOptions(showOptionsVideo);
                    break;
                case AdsType.RewardedVideo:
                    HZIncentivizedShowOptions showOptionsReward = new HZIncentivizedShowOptions();
                    showOptionsReward.Tag = type.name;
                    HZIncentivizedAd.ShowWithOptions(showOptionsReward);
                    break;
            }
        }
    }
}
#endif