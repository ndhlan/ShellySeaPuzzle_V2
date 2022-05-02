using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;




public class AudioControl : MonoBehaviour
{

    public Sound[] sounds;

    void Awake()
    {
        //loop through all sounds to be used in the scene
        foreach (Sound s in sounds)
        {            
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.outputAudioMixerGroup = s.audioMixer;            
        }
    }

    public Sound FindSoundByName(string name)
    {
        return Array.Find(sounds, sound => sound.name == name);
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null) // if name inputted is incorrect, do nothing
        {
            return;            
        }
        s.source.Play();
    }


    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) // if name inputted is incorrect, do nothing
        {
            return;
        }
        s.source.Pause();

    }

    public void UnPause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) // if name inputted is incorrect, do nothing
        {
            return;
        }
        s.source.UnPause();

    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) // if name inputted is incorrect, do nothing
        {
            return;
        }
        s.source.Stop();

    }







    
}
