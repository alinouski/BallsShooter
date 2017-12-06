using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ShowAndHideController))]
public abstract class ScreenController : MonoBehaviour {
    
    private ScreenController previous;
    private ShowAndHideController showAndHide;

    private void Awake()
    {
        showAndHide = GetComponent<ShowAndHideController>();
    }

    public virtual void Show()
    {
        if (showAndHide == null)
        {
            showAndHide = GetComponent<ShowAndHideController>();
        }
        showAndHide.Show();
    }

    public virtual void Show(ScreenController p)
    {
        previous = p;
        previous.Hide();
        Show();
    }

    public virtual void Hide()
    {
        if(showAndHide == null)
        {
            showAndHide = GetComponent<ShowAndHideController>();
        }
        showAndHide.Hide();
    }

    public virtual void HideAndBack()
    {
        if (previous != null)
        {
            previous.Show();
        }
        Hide();
    }
}

[System.Serializable]
public class UpdateTextField
{
    public string leftTextVal;
    public string rightTextVal;
    public Text text;
    private int c = -1;

    public void UpdateText(int newValue)
    {
        if (c != newValue)
        {
            c = newValue;                    
        }

        string newStr = string.Concat(leftTextVal, c, rightTextVal);
        if(text.text != newStr)
        {
            text.text = newStr;
        }        
    }
}
