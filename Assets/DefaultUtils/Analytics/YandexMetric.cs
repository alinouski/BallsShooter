using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if APP_METRICA
public class YandexMetric : Analytic {


    public AppMetrica metrica;

    void Start()
    {
        analyticName = gameObject.GetType().ToString();
    }

    public override void ButtonClick(string btnKey)
    {
        metrica.CustomEvent("Buttons", "click", btnKey);
    }

    public override void ShowAds(string type, int count)
    {
        metrica.CustomEvent("ADS", type, count.ToString());
    }

    public override void OpenScene(string sceneName)
    {
        metrica.CustomEvent("Screens", "open", sceneName);
    }

    public override void CustomEvent(string eventType, string eventName, string value)
    {
        metrica.CustomEvent(eventType, eventName, value);
    }

    public override void CustomEvent(string eventType)
    {
        metrica.CustomEvent(eventType);
    }
}
#endif