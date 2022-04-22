using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicControl : MonoBehaviour
{
    public Sound backgroundMusic;

    public static BackgroundMusicControl backgroundMusicControlInstance;


    void Awake()
    {
        //check if there is already an intance of AudioControl
        //to make background music continue through different scene instead of restart on new scene
        if (backgroundMusicControlInstance == null)
        {
            backgroundMusicControlInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        


        //assign background music property

        backgroundMusic.source = gameObject.AddComponent<AudioSource>();
        backgroundMusic.source.clip = backgroundMusic.clip;
        backgroundMusic.source.volume = backgroundMusic.volume;
        backgroundMusic.source.loop = backgroundMusic.loop;
        backgroundMusic.source.outputAudioMixerGroup = backgroundMusic.audioMixer;
        
    }


    public void Play()
    {
        if (backgroundMusic.source.isPlaying)
        {
            return;
        }
        backgroundMusic.source.Play();

    }


    public void Pause()
    {
        backgroundMusic.source.Pause();

    }

    public void UnPause()
    {
        backgroundMusic.source.UnPause();

    }

    public void Stop()
    {
        backgroundMusic.source.Stop();

    }

    public void VolumeDown()
    {
        backgroundMusic.source.volume = 0.1f;

    }

    public void VolumeBackToPreviousLevel()
    {
        backgroundMusic.source.volume = backgroundMusic.volume;

    }






}
