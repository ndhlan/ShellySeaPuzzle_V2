using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneControl : MonoBehaviour
{
    // load PuzzleList page
    public void LoadPuzzleList()
    {
        SceneManager.LoadScene("1.PuzzleList");
    }

    // load PuzzleSizeOption page
    public void LoadPuzzleSizeOption()
    {
        SceneManager.LoadScene("2.PuzzleSizeOption");
    }

    //load puzzle intro page
    public void LoadPuzzleIntro()
    {
        SceneManager.LoadScene("3.PuzzleIntro");
    }

    //load puzzle play page
    public void LoadPuzzlePlay()
    {
        SceneManager.LoadScene("4.PuzzlePlay");
    }

    //load main menu page
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //exit game
    public void Quit()
    {

    }

    //Play again
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
