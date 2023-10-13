using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : LivingCreature
{
    //A blueprint for every monster enemy in the game
    public int ID { get; set; }
    public string Name { get; set; }
    public int Damage { get; set; }
    public int RewardEXP {  get; set; }
    private Player Player;
    //public Items Drop { get; set; }
    //public Money Money { get; set; }
    public Monsters(int id, string name, int damage,int rewardEXP, int currHitPoints,
        int maxHitPoints/*, Money money, Items drop = null*/) : base(currHitPoints, maxHitPoints)
    {
        ID = id;
        Name = name;
        Damage = damage;
        RewardEXP = rewardEXP;
        //Drop = drop;
        //Money = money;
    }
    //Rewards the player on the monster's death
    public void Death()
    {
        //Player.Money += Money.Amount;
        //Player.Inventory.Add(new Inventory(Drop,1));
        Player.Experience += RewardEXP;
    }
    //Damages the Player.
    public void DamagePlayer()
    {
        Player.CurrHitPoints -= Damage;
    }
    // Start is called before the first frame update
    void Start(){}
    // Update is called once per frame
    void Update()
    {
        //Checks to see if the monster has died.
        if(this.CurrHitPoints >= 0)
        {
            Death();
        }
    }
}
