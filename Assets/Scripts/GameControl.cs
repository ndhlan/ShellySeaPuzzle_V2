using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour
{

    private GameObject[] pieces;

    [SerializeField]
    private GameObject endGamePopUp;

    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    private GameObject timesupPanel;

    [SerializeField]
    private GameObject thumbnail;

    [SerializeField]
    private Button backButton;

    [SerializeField]
    private Button playAgainButton;

    [SerializeField]
    private Text timeCounterText;

    [SerializeField]
    private GameObject timeField;

    private float currentTime = 0f;
    private float startingTime;

    private readonly float durationSize2 = 15f;
    private readonly float durationSize3 = 30f;
    private readonly float durationSize4 = 45f;

    private readonly float imageSize = 1080f;

    private int puzzleIndex;
    private int puzzleSize;

    public static bool isWin;
    public static bool isTimesup;


    // Start is called before the first frame update
    void Start()
    {
        //Get puzzle index
        puzzleIndex = PlayerPrefs.GetInt("PuzzleIndex", 1);
        Debug.Log("Index " + puzzleIndex);

        //Get puzzle size
        puzzleSize = PlayerPrefs.GetInt("PuzzleSize", 1);
        Debug.Log("Size " + puzzleSize);

        //Initialize puzzle pieces
        InitializePuzzlePieces();

        //Split image and display to puzzle field
        SplitPuzzleImage();

        //random rotate pieces
        randomRotatePieces();

        //Set startingTime based on Puzzle size
        SetStartingTime(puzzleSize);

        //Set End game pop up off
        endGamePopUp.SetActive(false);

        //Set win status off
        winPanel.SetActive(false);
        isWin = false;

        //Set timesup status off
        timesupPanel.SetActive(false);
        isTimesup = false;

        ////Set guidance Text on
        //guidanceText.SetActive(true);

        //set current time
        currentTime = startingTime;

        //start time counter
        TimeCounter();
        
    }

    // Update is called once per frame
    void Update()
    {
        //only check win status if enGamePopup is not active (game's not ended)
        if (endGamePopUp.activeSelf == false)
        {
            // check win status        
            if (CheckWinStatus())
            {
                isWin = true;

                WinDisplay();

                // play GameWin sound effect
                FindObjectOfType<AudioControl>().Play("GameWin");
            }
        }
    }

    void InitializePuzzlePieces()
    {
        int piecesNumber = puzzleSize * puzzleSize;

        pieces = new GameObject[piecesNumber];
    }

    bool CheckWinStatus()
    {
        bool isRotationZCorrect = true;

        Quaternion correctRotation = Quaternion.Euler(0f, 0f, 0f);

        //loop through all pieces, check if the angle between correct z direction and current z direction > 0.001 ==> not in correct direction
        for (int i = 0; i < pieces.Length; i++)
        {
            Quaternion currentRotation = Quaternion.Euler(pieces[i].transform.eulerAngles);

            float angle = Quaternion.Angle(correctRotation, currentRotation);

            if (Mathf.Abs(angle) > 1e-3f)
            {
                isRotationZCorrect = false;
            }
        }

        return isRotationZCorrect;
    }

    void SetStartingTime(int puzzleSize)
    {
        if (puzzleSize == 2)
        {
            startingTime = durationSize2;
        }
        else if (puzzleSize == 3)
        {
            startingTime = durationSize3;
        }
        else
        {
            startingTime = durationSize4;
        }
    }


    void TimeCounter()
    {
        if (!isWin)
        {
            if (currentTime > 0)
            {
                timeCounterText.text = currentTime.ToString("00");
                currentTime--;
                Invoke("TimeCounter", 1.0f);
            }
            else
            {//when time's up
                isTimesup = true;

                TimesUpDisplay();

                // play Timesup sound effect
                //check if Timesup is already played
                if (FindObjectOfType<AudioControl>().FindSoundByName("Timesup").source.isPlaying)
                {
                    return;
                }
                else
                {
                    //if not, play Timesup effect
                    FindObjectOfType<AudioControl>().Play("Timesup");
                }
            }
        }
        
        
    }


    void SplitPuzzleImage()
    {
        Texture2D imgTexture = (Texture2D)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/PuzzleImages/Puzzle" + puzzleIndex + ".png", typeof(Texture2D));
        float pieceSize = imageSize / puzzleSize;

        for (int i = 0; i < puzzleSize; i++)
        {
            for (int j = 0; j < puzzleSize; j++)
            {
                Sprite newSprite = Sprite.Create(imgTexture, new Rect(i * pieceSize, j * pieceSize, pieceSize, pieceSize), new Vector2(0.5f, 0.5f));
                GameObject n = new GameObject();
                n.AddComponent<SpriteRenderer>();
                SpriteRenderer sr = n.GetComponent<SpriteRenderer>();
                sr.sprite = newSprite;
                sr.sortingOrder = 1;
                n.AddComponent<BoxCollider2D>();
                n.AddComponent<TouchRotate>();
                n.transform.parent = GameObject.Find("PuzzleField").transform;
                
                Vector3 positionOffset = new Vector3((imageSize/ 2) - (pieceSize / 2), (imageSize / 2) - (pieceSize / 2), 0);
                Vector3 localScale = new Vector3(100, 100, 100);
                n.transform.localPosition = new Vector3(i * pieceSize, j * pieceSize, 0) - positionOffset;
                n.transform.localScale = localScale;
                n.SetActive(true);

                pieces[i * puzzleSize + j] = n;

                pieces[i * puzzleSize + j].name = (i * puzzleSize + j).ToString();

            }
        }
    }


    void randomRotatePieces()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            Vector3 randomRotation = new Vector3(0, 0, Random.Range(1, 4) * 90);

            pieces[i].transform.eulerAngles = randomRotation;

        }
    }





    void WinDisplay()
    {
        EndGamePopUpDisplay();

        timesupPanel.SetActive(false);

        winPanel.SetActive(true);
    }

    void TimesUpDisplay()
    {
        EndGamePopUpDisplay();

        winPanel.SetActive(false);
        timesupPanel.SetActive(true);        

        //FindObjectOfType<AudioControl>().Play("Timesup");       

    }

    void EndGamePopUpDisplay()
    {
        //guidanceText.SetActive(false);
        timesupPanel.SetActive(false);
        timeField.SetActive(false);

        endGamePopUp.SetActive(true);

        backButton.onClick.AddListener(BackButtonOnClick);
        playAgainButton.onClick.AddListener(PlayAgainButtonOnClick);
    }


    void BackButtonOnClick()
    {
        FindObjectOfType<AudioControl>().Play("MouseClick");

        SceneManager.LoadScene("LevelList");
                
    }

    void PlayAgainButtonOnClick()
    {
        FindObjectOfType<AudioControl>().Play("MouseClick");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }








}
