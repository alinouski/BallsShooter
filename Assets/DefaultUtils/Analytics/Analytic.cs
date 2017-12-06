using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Analytic : MonoBehaviour{

    [HideInInspector]
    public string analyticName;

    private static Analytic m_analytic;
    public static Analytic Instance
    {
        get { return m_analytic; }
    }

    private void Awake()
    {
        if (m_analytic)
        {
            Destroy(m_analytic);
        }
        else
        {
            m_analytic = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public virtual void ButtonClick(string btnKey) { }
    public virtual void OpenScene(string sceneName) { }
    public virtual void ShowAds(string adsType, int value) { }
    public virtual void CustomEvent(string eventType, string eventName, string value) { }
    public virtual void CustomEvent(string eventType) { }
}
