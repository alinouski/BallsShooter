using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDisabler : MonoBehaviour {

    public BulletCollection collection;

	public void DisableAll()
    {
        for (int i = collection.values.Count - 1; i >= 0; i--)
        {
            collection.values[i].DestroySelf();
        }
    }
}
