using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingCreature : MonoBehaviour
{
    //The super class for all living creatures in the game.
    public int CurrHitPoints { get; set; }
    public int MaxHitPoints { get; set; }

    public LivingCreature(int currHitPoints, int maxHitPoints)
    {
        CurrHitPoints = currHitPoints; 
        MaxHitPoints = maxHitPoints;
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
