using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleDoorsManager : MonoBehaviour
{
    public GameObject exitDoor;
    public GameObject BossDoor;
    private GameObject[] enemies;
    private GameObject[] Bosses;
    bool opened = false;
    bool opened2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bosses = GameObject.FindGameObjectsWithTag("Boss");
        if (Bosses.Length == 0 && !opened) // Boss is Alive.
        {
            Destroy(exitDoor);
            opened=true;
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 4 && !opened2) //All enemies outside boss are alive.
        {
            Destroy(BossDoor);
            opened2 = true;
        }
    }
}
