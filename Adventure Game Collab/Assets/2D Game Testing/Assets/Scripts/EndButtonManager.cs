using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class EndButtonManager : MonoBehaviour
{
    public TextMeshProUGUI Stats;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.Instance != null)
        {
            Stats.text = "Enemies Killed: " + MainManager.Instance.EnemiesKilled + "\n" +
                     "Damage Taken: " + MainManager.Instance.DamageTaken + "\n" +
                     "Projectiles Deflected: " + MainManager.Instance.ProjectilesDeflected;
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void tryAgain()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.currentHealth = 10 + MainManager.Instance.level * MainManager.Instance.difficulty;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("UI Scene");
    }

    public void loadCredits()
    {
        Stats.text = "Sheb Deaton:Player Mechanics + Coin Sprite \n" +
                     "Landon Arnold:UI + Forest Boss Sprite\n" +
                     "Logan Mancilla:Enemy Mechanics + Medkit Sprite\n" +
                     "Cameron Boddie:Level Design + Axe Sprite\n" +
                     "Top Down Adventure Assets: Tiles+Npcs+Player\n" +
                     "Enemy Galore 1 - Pixel Art: Enemies+Animation\n" +
                     "xxx: Music";
    }
}
