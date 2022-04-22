using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMusicVolume(float sliderValue)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSoundEffectVolume(float sliderValue)
    {
        audioMixer.SetFloat("SoundEffectVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetVoiceVolume(float sliderValue)
    {
        audioMixer.SetFloat("VoiceVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetMusicVolumeDown()
    {
        audioMixer.SetFloat("MusicVolume", 0.3f);
    }

}
