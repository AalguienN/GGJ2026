using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioGod : MonoBehaviour
{
    AudioSource AudioSource;

    public static AudioGod Instance;
    public AudioMixerSnapshot AMSInside;
    public AudioMixerSnapshot AMSOuside;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        Console.WriteLine(gameObject.name);
    }

    public void UpdateMusicByZone(Zone.ZType zone)
    {
        Debug.Log("CHANGING MUSIC ZONE?");
        switch(zone)
        {
            case Zone.ZType.Outside:
                Debug.Log("OUT");
                AMSOuside.TransitionTo(0.5f);
                break;

            case Zone.ZType.Inside:
                Debug.Log("IN");
                AMSInside.TransitionTo(0.5f);
                break;
            default:
                break;
        }
    }
}
