using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TouchRotate : MonoBehaviour
{

   private void OnMouseDown()
    { // if not win or time's up, rotate 90 degree on each touch
        if (!GameControl.isWin && !GameControl.isTimesup)
        {
            FindObjectOfType<AudioControl>().Play("Rotate");
            transform.Rotate(0, 0, 90);
            
        }
    }


    private void OnMouseOver()
    {

    }


}
