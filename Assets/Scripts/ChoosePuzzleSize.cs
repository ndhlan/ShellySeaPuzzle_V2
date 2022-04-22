using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChoosePuzzleSize : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public int puzzleSize;

    public void OnPointerClick(PointerEventData eventData)
    {
        FindObjectOfType<AudioControl>().Play("MouseClick");

        //Set PuzzleSize
        PlayerPrefs.SetInt("PuzzleSize", puzzleSize);

        //Load PuzzleIntro page
        SceneManager.LoadScene("3.PuzzleIntro");
    }

}
