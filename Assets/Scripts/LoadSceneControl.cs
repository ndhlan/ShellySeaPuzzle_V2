using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneControl : MonoBehaviour
{
    // load LevelList page
    public void LoadLevelList()
    {
        SceneManager.LoadScene("LevelList");
    }


    //load level intro scene
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    //From level intro scene, start level main scene
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
