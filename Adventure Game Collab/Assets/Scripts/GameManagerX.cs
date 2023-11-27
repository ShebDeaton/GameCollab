using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

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

    public Button EasyButton;
    public Button MediumButton;
    public Button HardButton;
    public TextMeshProUGUI TextScreen;
    // Start the game, remove title screen, reset score, and adjust spawnRate based on difficulty button clicked
    void Start()
    {
        StartGameScene.SetActive(false);
        DifficultySelectScene.SetActive(false);
        OtherSelectScene.SetActive(false);
        titleScreen.SetActive(true);

        StartButton.onClick.AddListener(StartGameScreen);

        OtherButton.onClick.AddListener(OtherGameScreen);

        QuitButton.onClick.AddListener(QuitGame);
    }
    public void QuitGame()
    {
        Application.Quit();
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

    public void changeText(int text)
    {
        if (text == 1)// Story
        {
            TextScreen.text = "Story \n"+
                              "You, the hero, awaken in a strange dungeon.\n"+
                              "It seems you've been chosen to save the world, but first\n"+
                              "must prove yourself! After winning, you find a single villager,\n"+
                              "They instruct you to conquer the nearby dungeons to form a sword\n"+
                              "to defeat the ultimate evil! Are you up to the challenge?";
        }
        if (text == 2)// Guide
        {
            TextScreen.text = "Controls \n"+
                              "Movement - WASD\n" +
                              "Attack/Continue - Space\n" +
                              "Talk/Interact - E\n"+
                              "Buy - Q \n"+
                              "Return to Menu - Escape \n"+
                              "God Mode - G";
        }
        if (text == 3)// Credits
        {
            TextScreen.text = "Credits \n"+
                     "Sheb Deaton: Player Mechanics + Coin Sprite \n" +
                     "Landon Arnold: UI + Forest Boss Sprite\n" +
                     "Logan Mancilla: Enemy Mechanics + Medkit Sprite\n" +
                     "Cameron Boddie: Level Design + Healthbar\n" +
                     "Top Down Adventure Assets: Tiles+Npcs+Player\n" +
                     "Enemy Galore 1 - Pixel Art: Enemies+Animation\n" +
                     "Adventure Music and SFX: Background Music\n" +
                     "Blades & Bludgeoning Free Sample Pack: Collision Sounds";
        }
       
    }
}
