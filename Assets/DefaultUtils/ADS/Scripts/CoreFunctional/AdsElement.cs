using System;
using UnityEngine;

[CreateAssetMenu(fileName = "adsElement", menuName = "Ads/AdsTypeElement")]
[Serializable]
public class AdsElement : ScriptableObject
{
    public AdsType type;
    public string adsName = "";
    [NonSerialized]
    private bool m_isReady = false;
    public bool IsReady
    {
        get { return m_isReady; }
        set
        {
            if(value != m_isReady)
            {
                m_isReady = value;
                if (m_isReady)
                {
                    AdsReady();
                }
                else
                {
                    AdsNotReady();                    
                }
            }
        }
    }

    public GameEvent adsIsReady;
    public GameEvent adsIsNotReady;
    public GameEvent adsClick;
    public GameEvent adsWatch;

    public void AdsReady()
    {
        if (adsIsReady) adsIsReady.Raise();
    }

    public void AdsNotReady()
    {
        if (adsIsNotReady) adsIsNotReady.Raise();
    }

    public void AdsClick()
    {
        if (adsClick) adsClick.Raise();
    }

    public void AdsWatch()
    {
        if (adsWatch) adsWatch.Raise();
    }
}

public enum AdsType
{
    Banner,
    Interstitial,
    Video,
    NonSkipableVideo,
    RewardedVideo
}
