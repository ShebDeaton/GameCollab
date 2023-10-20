using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMath : MonoBehaviour
{
    //Class for dealing with game math, specifically the random loot
    //The class gets three lists of Items' Ids, Each for a different rarity.
    public int GetRandomLootFrom(List<int> common, List<int> uncommon = null, List<int> rare = null)
    {
        int[] RarityOptions = new int[10];
        //If there are Common, Uncommon, and Rare (0,1,2)
        if (rare != null)
        {
            //60%/30%/10%
            for (int i = 6; i <= 8; i++)
            {
                RarityOptions[i] = 1;
            }
            RarityOptions[9] = 2;
        }
        //If there are Common and Uncommon
        else if ( uncommon != null ) 
        {
            //70%/30%
            for (int i = 7; i <= 9; i++)
            {
                RarityOptions[i] = 1;
            }
        }
        //If there is only Common.
        else
        {
            //100% Uncommon
            //Technically useless, but used to keep things consistent. 
            for (int i = 0; i <= 9; i++)
            {
                RarityOptions[i] = 0;
            }
        }
        //Grab a random rarity.
        int index = Random.Range(0, RarityOptions.Length);
        int Rarity = RarityOptions[index];
        //Go through the appropriate rarity List and return a random ID from it.
        if (Rarity == 2)
            return ChooseRandomID(rare);
        else if (Rarity == 1)
            return ChooseRandomID(uncommon);
        else 
            return ChooseRandomID(common);
    }

    public int ChooseRandomID(List<int> rarityLoot)
    {
        //Return a random id from the list.
        int index = Random.Range(0, rarityLoot.Count);
        return rarityLoot[index];
    }
}
