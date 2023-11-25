using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public GameObject titleScreen;
    public Button StartButton;
    public Button QuitButton;
    public Button OtherButton;
    public Button DifficultyButton;
    public GameObject StartGameScene;
    public GameObject DifficultySelectScene;
    public GameObject OtherSelectScene;
    public Button BackButton1;
    public Button BackButton2;
    public Button BackButton3;
    public Toggle GModeButton;
    
    // Start the game, remove title screen, reset score, and adjust spawnRate based on difficulty button clicked
    void Start()
    {
        StartGameScene.SetActive(false);
        DifficultySelectScene.SetActive(false);
        OtherSelectScene.SetActive(false);
        titleScreen.SetActive(true);

        StartButton.onClick.AddListener(StartGameScreen);

        OtherButton.onClick.AddListener(OtherGameScreen);

        QuitButton.onClick.AddListener(Application.Quit);
    }

    public void BackButtonStart()
    {
        StartGameScene.SetActive(false);
        DifficultySelectScene.SetActive(false);
        OtherSelectScene.SetActive(false);
        titleScreen.SetActive(true);

        StartButton.onClick.AddListener(StartGameScreen);

        OtherButton.onClick.AddListener(OtherGameScreen);

        QuitButton.onClick.AddListener(Application.Quit);
    }
    
    public void StartGameScreen()
    { 
        titleScreen.SetActive(false);
        DifficultySelectScene.SetActive(false);
        StartGameScene.SetActive(true);
        DifficultyButton.onClick.AddListener(DifficultySelectScreen);
        ///need to set what happens when this is clicked
        ///GModeButton.onValueChanged();
    }

    public void OtherGameScreen()
    {
        titleScreen.SetActive(false);
        OtherSelectScene.SetActive(true);

    }

    public void DifficultySelectScreen()
    {
        StartGameScene.SetActive(false);
        DifficultySelectScene.SetActive(true);
    }
}
