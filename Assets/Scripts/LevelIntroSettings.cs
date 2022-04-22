using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;




public class LevelIntroSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //default play Did You Know voice         
        FindObjectOfType<AudioControl>().Play("DYKVoice");
        

        //lower volume of background music
        FindObjectOfType<BackgroundMusicControl>().VolumeDown();

        

    }

    // Update is called once per frame
    void Update()
    {
        //find sound name "DYKVoice" from AudioControl and check if it's is playing
        if (FindObjectOfType<AudioControl>().FindSoundByName("DYKVoice").source.isPlaying)
        {
            return;
        }
        else
        {
            //if not, turn background music back to its original volume level
            FindObjectOfType<BackgroundMusicControl>().VolumeBackToPreviousLevel();
        }
    }
}
