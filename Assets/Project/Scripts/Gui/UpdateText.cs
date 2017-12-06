using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour {

    public IntReference val;
    private int currentVal;
    public Text txt;

    private void Start()
    {
        if(txt == null)
        {
            Text t = GetComponent<Text>();
            if(t != null)
            {
                txt = t;
                UpdateTextValue();
            }
        }
        else
        {
            UpdateTextValue();
        }
    }

    void FixedUpdate () {
        if(currentVal != val.Value)
        {
            UpdateTextValue();
        }        
	}

    void UpdateTextValue()
    {
        currentVal = val.Value;
        txt.text = val.Value.ToString();
    }
}
