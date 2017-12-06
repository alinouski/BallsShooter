using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class ShowAndHideController : MonoBehaviour {

    [Header("Show settings")]
    public bool waitShow = false;
    public float waitShowTime = 0;
    public string show;

    [Space(10)]
    [Header("Hide settings")]
    public bool waitHide = false;
    public float waitHideTime = 0;
    public string hide;

    protected Animation anim;

    private void Awake()
    {
        anim = GetComponent<Animation>();   
    }

    public virtual void Show()
    {
        if (waitShow)
        {
            StartCoroutine(WaitAndPlay(waitShowTime, AnimationShow));
        }
        else
        {
            AnimationShow();
        }
    }

    void AnimationShow()
    {
        gameObject.SetActive(true);
        if (!string.IsNullOrEmpty(show))
        {
            anim.Play(show);
        }
    }

    public virtual void Hide()
    {
        if (waitHide)
        {
            StartCoroutine(WaitAndPlay(waitHideTime, AnimationHide));
        }
        else
        {
            AnimationHide();
        }
    }

    void AnimationHide()
    {
        if (!string.IsNullOrEmpty(hide))
        {
            anim.Play(hide);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator WaitAndPlay(float time, Action act)
    {
        yield return new WaitForSeconds(time);
        act();
    }
}
