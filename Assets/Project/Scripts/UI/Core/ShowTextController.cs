using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ShowTextController : MonoBehaviour {

    [ContextMenuItem("play", "StartEffect")]
    public bool playAutomaticaly = false;
    public bool loop = false;       

    public Color start;
    public Color final;
    
    public float showTime;
    public float visibleTime;
    public float hideTime;

    private bool locked = false;
    private bool loopFinish = false;
    private Text txt;
    private Step step = Step.Show;
    private void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.color = start;
        if (playAutomaticaly)
        {
            StartEffect();
        }
    }    

    public void StartEffect()
    {
        txt.color = start;
        if (!locked)
        {
            loopFinish = false;
            locked = true;
            StartCoroutine(StartEffectLerp());
        }
    }

    IEnumerator StartEffectLerp() {
        float valueTime = 0.0001f;        
        while (!loopFinish || loop)
        {
            switch (step)
            {
                case Step.Show:
                    LerpByTime(final, ref valueTime, showTime);
                    break;
                case Step.View:                    
                    if (valueTime >= visibleTime) {
                        valueTime = 0.000001f;
                        NextStep();
                    }
                    break;
                case Step.Hide:
                    LerpByTime(start, ref valueTime, hideTime);
                    break;
            }
            valueTime += Time.deltaTime;
            yield return null;
        }
        locked = false;
        Debug.Log("unlocked");
    }

    private void LerpByTime(Color fin , ref float valueTime, float totalDuration)
    {
        float a = txt.color.a;
        float r = txt.color.r;
        float g = txt.color.g;
        float b = txt.color.b;

        a = Mathf.MoveTowards(a, fin.a, Time.deltaTime);// valueTime / totalDuration);
        r = Mathf.MoveTowards(r, fin.r, Time.deltaTime);// valueTime / totalDuration);
        g = Mathf.MoveTowards(g, fin.g, Time.deltaTime);// valueTime / totalDuration);
        b = Mathf.MoveTowards(b, fin.b, Time.deltaTime);// valueTime / totalDuration);
        txt.color = new Color(r,g,b,a); 


        if (valueTime >= totalDuration) {
            NextStep();
            valueTime = 0.000001f;            
        }
    }

    private void NextStep()
    {
        if (step == Step.Hide)
        {
            step = Step.Show;
            loopFinish = true;
        }
        else if (step == Step.Show)
        {
            step = Step.View;
        }
        else if(step == Step.View)
        {
            step = Step.Hide;
        }
    }
}
enum Step
{
    Show,
    View,
    Hide
}
