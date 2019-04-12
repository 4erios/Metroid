﻿using System;
using UnityEngine.Audio;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{

    public Sound[] sounds;

    public static Audio_Manager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds )
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        FindObjectOfType<Audio_Manager>().Play("Theme1");
    }

    public void Play (string name)
    {
        Sound s  =Array.Find(sounds, sound => sound.name == name);
        if (s==null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

       
        s.source.Play();
       
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
    }
}
