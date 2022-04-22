using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundToggle : MonoBehaviour
{    
  


    // Start is called before the first frame update
    void Start()
    {

        Toggle soundToggle = FindObjectOfType<UnityEngine.UI.Toggle>();

        if (PlayerPrefs.GetInt("isChecked", 0) == 1)
        { 
            soundToggle.isOn = true;
        }
        else
        {
            soundToggle.isOn = false;
        }



    }



    public void ToggleSound(bool isChecked)
    {
        if (isChecked)
        {
            AudioListener.volume = 0.0001f;
            PlayerPrefs.SetInt("isChecked", 1);

        }
        else
        {

            AudioListener.volume = 1f;
            PlayerPrefs.SetInt("isChecked", 0);

        }
    }




}
