using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAds{

    void Init();

    void SetCallbacks();

    void Show(AdsElement type);

    bool IsAvilable(AdsElement type);

    void FetchAds(AdsElement type);
}
