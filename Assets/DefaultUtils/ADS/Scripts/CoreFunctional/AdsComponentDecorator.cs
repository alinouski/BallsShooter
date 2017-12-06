using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdsComponentDecorator : AdsComponent
{
    public AdsComponent ads;
    
    public override void FetchAds(AdsElement type)
    {
        if (ads)
        {
            ads.FetchAds(type);
        }
    }

    public override void Init()
    {
        if (ads)
        {
            ads.Init();
        }
    }   

    public override void SetCallbacks()
    {
        if (ads)
        {
            ads.SetCallbacks();
        }
    }

    public override void Show(AdsElement type)
    {
        if (ads)
        {
            ads.Show(type);
        }
    }
}
