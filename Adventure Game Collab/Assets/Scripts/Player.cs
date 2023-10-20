using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : LivingCreature
{
    //The class for the player.
    public int Money {  get; set; } 
    public int Experience { get; set; }
    public int Level {  get; set; }

    public List<Items> Inventory { get; set; }
    public List<Quest> Quests { get; set; }

    public Player(int currHitPoints, int maxHitPoints, int money,
        int experience, int level) : base(currHitPoints,maxHitPoints)
    {
        Money = Money;
        Experience = experience;
        Level = level;

        Inventory = new List<Items>();
        Quests = new List<Quest>();
    }

    // Start is called before the first frame update
    void Start(){}
    // Update is called once per frame
    void Update()
    {
    }
}
