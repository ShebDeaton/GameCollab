using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCs : LivingCreature
{
    //The class for non-monster characters.
    public string Name { get; set; }
    //public Quest QuestGiven { get; set; }
    public bool IsImportant { get; set; }
    public TextMeshProUGUI Dialogue { get; set; }

    private Player Player;
    public NPCs(int currHitPoints, int maxHitPoints, string name,TextMeshProUGUI dialogue,
        bool isImportant = false/*, Quest questGiven = null*/)
        : base(currHitPoints, maxHitPoints)
    {
        Name = name;
        Dialogue = dialogue;
        IsImportant = isImportant;
        //QuestGiven = questGiven;
    }
    //Rewards the quest if its completed.
    /*public Items RewardQuest()
    {
        if (QuestGiven.IsCompleted)
        {
            Player.Quests.Remove(QuestGiven);
            return QuestGiven.Reward;
        }
        else
            return null;
    }*/
    //Adds the quest to the player's lists of quests.
    public void GiveQuest()
    {
        //Player.Quests.Add(QuestGiven);
    }
    //To modify the text for the dialogue.
    public void SpeakToPlayer(String text)
    {
        Dialogue.text = text;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
