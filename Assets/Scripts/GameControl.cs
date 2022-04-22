using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;

    [SerializeField]
    private GameObject endGamePopUp;

    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    private GameObject timesupPanel;

    [SerializeField]
    private GameObject guidanceText;

    [SerializeField]
    private Button backButton;

    [SerializeField]
    private Button playAgainButton;

    [SerializeField]
    private Text timeCounterText;

    [SerializeField]
    private GameObject timeField;

    private float currentTime = 0f;
    private float startingTime = 30f;

    public static bool isWin;
    public static bool isTimesup;


    // Start is called before the first frame update
    void Start()
    {

        //Set End game pop up off
        endGamePopUp.SetActive(false);

        //Set win status off
        winPanel.SetActive(false);
        isWin = false;

        //Set timesup status off
        timesupPanel.SetActive(false);
        isTimesup = false;

        //Set guidance Text on
        guidanceText.SetActive(true);

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



    bool CheckWinStatus()
    {
        bool isRotationZCorrect = true;

        //loop through all pieces, if any piece's rotation z is not 0, then isRotationZCorrect is false
        for (int i = 0; i < pictures.Length; i++)
        {
            if (pictures[i].rotation.z != 0)
            {
                isRotationZCorrect = false;
            }
            
        }

        return isRotationZCorrect;
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
        guidanceText.SetActive(false);
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
