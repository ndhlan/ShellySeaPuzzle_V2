using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneControl : MonoBehaviour
{
    // load PuzzleList page
    public static void LoadPuzzleList()
    {
        SceneManager.LoadScene("1.PuzzleList");
    }

    // load PuzzleSizeOption page
    public static void LoadPuzzleSizeOption()
    {
        SceneManager.LoadScene("2.PuzzleSizeOption");
    }

    //load puzzle intro page
    public static void LoadPuzzleIntro()
    {
        SceneManager.LoadScene("3.PuzzleIntro");
    }

    //load puzzle play page
    public static void LoadPuzzlePlay()
    {
        SceneManager.LoadScene("4.PuzzlePlay");
    }

    //load How to play page
    public static void LoadHowToPlay()
    {
        SceneManager.LoadScene("5.HowToPlay");
    }


    //load main menu page
    public static void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //exit game
    public static void Quit()
    {
        Application.Quit();
    }

    //Play again
    public static void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
