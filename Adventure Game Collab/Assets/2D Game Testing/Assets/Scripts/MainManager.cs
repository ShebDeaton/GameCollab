using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    //Dungeon Flags
    public bool TutorialComplete;
    public bool CaveComplete;
    public bool ForestComplete;
    //Saved Stated
    public int EnemiesKilled;
    public int DamageTaken;
    public int ProjectilesDeflected;
    //Player Stats
    public int currentHealth;
    public int level;
    public int money;
    public bool godMode;
    public int difficulty;

    private void Awake()
    {
        // If it already exists...
        if (Instance != null)
        {
            //Destroy it!
            Destroy(gameObject);
            return;
        }
        //Carry on

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //Starting Defaults
        currentHealth = 13;
        level = 1;
        money = 0;
        godMode = false;
        difficulty = 3;

        TutorialComplete = false;
        CaveComplete = false;
        ForestComplete = false;

        EnemiesKilled = 0;
        DamageTaken = 0;
        ProjectilesDeflected = 0;
    }
}
