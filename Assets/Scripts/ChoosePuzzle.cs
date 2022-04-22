using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChoosePuzzle : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public int puzzleIndex;

    public void OnPointerClick(PointerEventData eventData)
    {        
        FindObjectOfType<AudioControl>().Play("MouseClick");

        //Set PuzzleIndex
        PlayerPrefs.SetInt("PuzzleIndex", puzzleIndex);

        //Load PuzzleSizeOption page
        SceneManager.LoadScene("2.PuzzleSizeOption");        
    }


}
