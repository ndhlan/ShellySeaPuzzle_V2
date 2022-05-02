using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleIntroControl : MonoBehaviour
{
    int puzzleIndex;
    Texture2D puzzle;
    string DYKText;
    string DYKVoiceName;
    private readonly float imageSize = 1080f;

    // Start is called before the first frame update
    void Start()
    {
        //Get puzzle index
        puzzleIndex = PlayerPrefs.GetInt("PuzzleIndex", 1);

        //Find puzzle based on puzzle index
        puzzle = (Texture2D)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/PuzzleImages/Puzzle" + puzzleIndex+".png", typeof(Texture2D));

        //display puzzle to PuzzleField
        Sprite newSprite = Sprite.Create(puzzle, new Rect(0, 0, imageSize, imageSize), new Vector2(0.5f, 0.5f));
        GameObject n = new GameObject();
        n.AddComponent<SpriteRenderer>();
        SpriteRenderer sr = n.GetComponent<SpriteRenderer>();
        sr.sprite = newSprite;
        sr.sortingOrder = 1;
        n.transform.parent = GameObject.Find("PuzzleField").transform;
        Vector3 localScale = new Vector3(100, 100, 100);
        n.transform.localPosition = new Vector3(0, 0, 0);
        n.transform.localScale = localScale;
        n.SetActive(true);

        //get DYKText
        DidYouKnowText dykText = new DidYouKnowText();
        DYKText = dykText.GetDYKText(puzzleIndex);
        GameObject.Find("DYKText").GetComponent<Text>().text = DYKText;


        // play Did You Know voice
        DYKVoiceName = "DYKVoice" + puzzleIndex;
        FindObjectOfType<AudioControl>().Play(DYKVoiceName);


        //lower volume of background music
        FindObjectOfType<BackgroundMusicControl>().VolumeDown();

    }

    // Update is called once per frame
    void Update()
    {

        //find sound name "DYKVoice" from AudioControl and check if it's is playing
        if (FindObjectOfType<AudioControl>().FindSoundByName(DYKVoiceName).source.isPlaying)
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
