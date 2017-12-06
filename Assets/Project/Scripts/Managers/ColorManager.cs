using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="colorManager", menuName ="Managers/Color", order = 51)]
public class ColorManager : ScriptableObject {

    public Color[] values;

    public Color RandomColor
    {
        get {
            Color c = Color.white;
            if (values.Length > 0)
            {
                c = values[UnityEngine.Random.Range(0, values.Length)];
            }
            return c;
        }
    }

}
