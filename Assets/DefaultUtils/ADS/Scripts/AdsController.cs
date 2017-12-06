using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsController : MonoBehaviour{

    public AdsComponent heyzap;
    public AdsComponent appodeal;
    public AdsComponent custom;

    private AdsComponent ads;

    private static AdsController m_instance;
    public static AdsController Instance
    {
        get { return m_instance; }
    }

    private void Awake()
    {
#if HEYZAP
        ads = heyzap;
#elif APPODEAL
        ads = appodeal;
#else
        ads = custom;
#endif
    }

    private void Start()
    {
        if (Instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);

            if (ads)
            {
                ((IAds)ads).Init();
                ((IAds)ads).SetCallbacks();
            }
            else
            {
                Debug.LogError("ADS conponent not initialized");
            }
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public static bool NoAds
    {
        get { return PlayerPrefs.GetInt("noads") > 0 ? true : false; }

        set
        {
            if (value)
            {
                PlayerPrefs.SetInt("noads", 1);
            }
            else
            {
                PlayerPrefs.SetInt("noads", 0);
            }
        }
    }
}
