using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public Sound[] sounds;

    public static SoundManager Instance
    {
        get { return _instance; }
    }

    private static SoundManager _instance;

	void Awake () {
		if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        InitSounds();
        CheckEnabled();
    }

    void InitSounds()
    {
        foreach (Sound s in sounds)
        {
            s.InitSound(gameObject.AddComponent<AudioSource>());
        }
    }	

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.Play();
        }
    }

    public void Mute()
    {
        Enable = false;
        foreach (Sound s in sounds)
        {
            s.Mute();
        }
    }

    public void Unmute()
    {
        Enable = true;
        foreach (Sound s in sounds)
        {
            s.Unmute();
        }
    }

    void CheckEnabled()
    {
        if (Enable)
        {
            Unmute();
        }
        else
        {
            Mute();
        }
    }

    public bool Enable
    {
        get { return PlayerPrefs.GetInt("sound") > 0 ? false : true; }
        set
        {
            PlayerPrefs.SetInt("sound",value?0:1);
        }
    }
}
