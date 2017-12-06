using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdsElementController : MonoBehaviour {

    public AdsComponent ads;
    public AdsElement adsElement;
    [Range(0.1f, 20.0f)]
    public float updateFrequency;

    [Space(10)]
    public UnityEvent startEvent;

    private void Awake()
    {
        if(adsElement) ads.Add(adsElement);
    }

    private void OnDisable()
    {
        if (adsElement) ads.Remove(adsElement);
    }

    private void Start()
    {
        startEvent.Invoke();
    }

    public void StartChecker()
    {
        StopAllCoroutines();
        StartCoroutine(CheckAdsState());
    }

    public void Show()
    {
        ads.Show(adsElement);
    }

    public void ClickEvent()
    {
        if (adsElement && adsElement.IsReady)
        {
            ads.Show(adsElement);
        }
    }

    IEnumerator CheckAdsState()
    {
        adsElement.adsIsNotReady.Raise();
        ads.FetchAds(adsElement);
        while (true)
        {
            if (!ads.IsAvilable(adsElement)) {                
                adsElement.IsReady = false;
            }
            else
            {
                adsElement.IsReady = true;
            }
            yield return new WaitForSeconds(updateFrequency);
            Debug.Log("Checker work");
        }
    }
}
