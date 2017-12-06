using UnityEngine;
using System.Collections;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;
    public bool loop = false;
    public bool playOnAwake = false;
    [Range(0.0f,1.0f)]
    public float volume;

    private AudioSource src;

    public void InitSound(AudioSource s)
    {
        src = s;
        src.volume = volume;
        src.loop = loop;
        src.playOnAwake = playOnAwake;
    }

    public void Play()
    {
        src.PlayOneShot(clip);
    }

    public void Mute()
    {
        src.volume = 0;
    }

    public void Unmute()
    {
        src.volume = volume;
    }
}
