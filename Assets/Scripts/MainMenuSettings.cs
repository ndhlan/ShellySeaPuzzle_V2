using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;



public class MainMenuSettings : MonoBehaviour
{

    private GameObject mainMenu;

    private GameObject volumeMenu;
 
    private GameObject instructionsMenu;

    private GameObject creditsMenu;


    private Button volumeButton;

    private Button instructionsButton;

    private Button playButton;

    private Button creditsButton;


    private Button instructionsBackButton;

    private Button volumeBackButton;

    private Button creditsBackButton;
    

    void Awake()
    {
                
        mainMenu = GameObject.Find("MainMenu");
        instructionsMenu = GameObject.Find("InstructionsMenu");
        volumeMenu = GameObject.Find("VolumeMenu");
        creditsMenu = GameObject.Find("CreditsMenu");


        volumeButton = GameObject.Find("VolumeButton").GetComponent<Button>();
        instructionsButton = GameObject.Find("InstructionsButton").GetComponent<Button>();
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        creditsButton = GameObject.Find("CreditsButton").GetComponent<Button>();


        instructionsBackButton = GameObject.Find("InstructionsMenu/BackButton").GetComponent<Button>();
        volumeBackButton = GameObject.Find("VolumeMenu/BackButton").GetComponent<Button>();
        creditsBackButton = GameObject.Find("CreditsMenu/BackButton").GetComponent<Button>();         

    }

    // Start is called before the first frame update
    void Start()
    {
        //default display Main Menu & play background music        
        FindObjectOfType<BackgroundMusicControl>().Play();

        MainMenuDisplay();


        //set on click listener to buttons
        playButton.onClick.AddListener(PlayButtonOnClick);

        instructionsButton.onClick.AddListener(InstructionsButtonOnClick);        
        instructionsBackButton.onClick.AddListener(InstructionsBackButtonOnClick);

        volumeButton.onClick.AddListener(VolumeButtonOnClick);
        volumeBackButton.onClick.AddListener(VolumeBackButtonOnClick);

        creditsButton.onClick.AddListener(CreditsButtonOnClick);
        creditsBackButton.onClick.AddListener(CreditsBackButtonOnClick);


    }


    //displays

    void MainMenuDisplay()
    {
        mainMenu.SetActive(true);

        instructionsMenu.SetActive(false);
        volumeMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    void VolumeMenuDisplay()
    {
        volumeMenu.SetActive(true);

        mainMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    void InstructionMenuDisplay()
    {
        instructionsMenu.SetActive(true);

        mainMenu.SetActive(false);
        volumeMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }



    void CreditsMenuDisplay()
    {
        creditsMenu.SetActive(true);

        mainMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        volumeMenu.SetActive(false);

    }

    // buttons onclick 

    void PlayButtonOnClick()
    {      
        FindObjectOfType<AudioControl>().Play("MouseClick");

        LoadSceneControl.LoadPuzzleList();
    }



    void InstructionsButtonOnClick()
    {
        FindObjectOfType<AudioControl>().Play("MouseClick");

        InstructionMenuDisplay();

        FindObjectOfType<BackgroundMusicControl>().Pause();

        FindObjectOfType<AudioControl>().Play("Instruction");
    }


    void InstructionsBackButtonOnClick()
    {
        FindObjectOfType<AudioControl>().Play("MouseClick");

        MainMenuDisplay();

        FindObjectOfType<BackgroundMusicControl>().UnPause();

        FindObjectOfType<AudioControl>().Stop("Instruction");
    }


    void VolumeButtonOnClick()
    {
        FindObjectOfType<AudioControl>().Play("MouseClick");

        VolumeMenuDisplay();

    }

    void VolumeBackButtonOnClick()
    {
        FindObjectOfType<AudioControl>().Play("MouseClick");

        MainMenuDisplay();
    }


    void CreditsButtonOnClick()
    {
        FindObjectOfType<AudioControl>().Play("MouseClick");

        CreditsMenuDisplay();

    }

    void CreditsBackButtonOnClick()
    {
        FindObjectOfType<AudioControl>().Play("MouseClick");

        MainMenuDisplay();

    }







   



}
