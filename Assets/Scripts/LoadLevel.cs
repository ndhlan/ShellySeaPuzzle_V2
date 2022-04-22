using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public int levelIndex;

    void OnMouseDown()
    {
        FindObjectOfType<AudioControl>().Play("MouseClick");

        SceneManager.LoadScene(levelIndex);
    }


}
