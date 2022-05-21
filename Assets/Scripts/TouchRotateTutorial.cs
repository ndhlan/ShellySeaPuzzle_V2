using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotateTutorial : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!TutorialControl.isWinTT && !TutorialControl.isTimesupTT)
        {
            FindObjectOfType<AudioControl>().Play("Rotate");
            transform.Rotate(0, 0, 90);
        }
    }



}
