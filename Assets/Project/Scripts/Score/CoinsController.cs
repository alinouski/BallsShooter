using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour {

    public IntReference coins;
    private int current = 0;

    private void Awake()
    {
        coins.Value = current = Coins;
    }

    private void FixedUpdate()
    {
        if (coins.Value != current)
        {
            current = coins.Value;
            Coins = current;
        }
    }

    public static int Coins
    {
        get { return PlayerPrefs.GetInt("coins"); }
        set { PlayerPrefs.SetInt("coins", value); }
    }
}
