using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdsComponent : RuntimeSet<AdsElement>, IAds {
    
    public abstract void Init();

    public abstract void SetCallbacks();

    public abstract void Show(AdsElement type);

    public abstract bool IsAvilable(AdsElement type);

    public abstract void FetchAds(AdsElement type);
}
