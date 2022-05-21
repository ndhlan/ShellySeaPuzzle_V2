using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class TutorialControl : MonoBehaviour
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
    private Button playButton;

    [SerializeField]
    private Text timeCounterText;

    [SerializeField]
    private GameObject timeField;

    private float currentTime = 0f;
    private float startingTime = 30f;

    public static bool isWinTT;
    public static bool isTimesupTT;


    void Start()
    {
        //Set End game pop up off
        endGamePopUp.SetActive(false);

        //Set win status off
        winPanel.SetActive(false);
        isWinTT = false;

        //Set timesup status off
        timesupPanel.SetActive(false);
        isTimesupTT = false;

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
                isWinTT = true;

                WinDisplay();
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
        if (!isWinTT)
        {
            if (currentTime > 0)
            {
                timeCounterText.text = currentTime.ToString("00");
                currentTime--;
                Invoke("TimeCounter", 1.0f);
            }
            else
            {//when time's up
                isTimesupTT = true;

                TimesUpDisplay();
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
    }

    void EndGamePopUpDisplay()
    {       
        timesupPanel.SetActive(false);
        timeField.SetActive(false);

        endGamePopUp.SetActive(true);

        playButton.onClick.AddListener(PlayButtonOnClick);
    }


    void PlayButtonOnClick()
    {
        FindObjectOfType<AudioControl>().Play("MouseClick");

        SceneManager.LoadScene("1.PuzzleList");
    }



}
