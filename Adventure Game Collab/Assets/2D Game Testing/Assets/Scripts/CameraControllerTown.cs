using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerTown : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public int room;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        room = 1;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player Position: X = " + player.transform.position.x + " --- Y = " + player.transform.position.y + " --- Z = " +
        //player.transform.position.z);
        Vector3 playerPosition = player.transform.position;
        if (room == 1) // Beginning/Beach Area
        { 
            if (playerPosition.y > 5) // Up to Intersection Room
            {
                Camera.main.transform.Translate(0, 10, 0);
                room = 2; 
            }
        }

        else if (room == 2) // Intersection Room
        {
            if (playerPosition.x < -8.5) // Enter Mayor's Room
            {
                Camera.main.transform.Translate(-18, 0, 0);
                room = 3;
            }
            if (playerPosition.x > 8.5) // Enter Jungle Enterance
            {
                Camera.main.transform.Translate(18, 0, 0);
                room = 5;
            }
            if (playerPosition.y < 5) // Return to Beginning/Beach Area
            {
                Camera.main.transform.Translate(0, -10, 0);
                room = 1;
            }
            if (playerPosition.y > 14.5) // Enter Cave Enterance
            {
                Camera.main.transform.Translate(0, 10, 0);
                room = 4;
            }
        }

        else if (room == 3) // Mayor's Room
        {
            if (playerPosition.x > -8.5) // Enter Main Room
            {
                Camera.main.transform.Translate(18, 0, 0);
                room = 2;
            }
            if (playerPosition.x < -26.5 & playerPosition.y < 6.5) // Enter Main Room
            {
                Camera.main.transform.Translate(-18, 0, 0);
                room = 6;
            }
        }
        else if (room == 4) // Bottom Room Navigation / Shop Room
        {
            if (playerPosition.y < 14.5) // Enter Main Room
            {
                Camera.main.transform.Translate(0, -10, 0);
                room = 2;
            }
        }
        
        else if (room == 5) // Top Top Room Navigation / Exit Room
        {
            if (playerPosition.x < 8.5) // Enter Main Room
            {
                Camera.main.transform.Translate(-18, 0, 0);
                room = 2;
            }
        }

        else if (room == 6) // Final Boss Room
        {
            if (playerPosition.x > -26.5 & playerPosition.y < 6.5) // Enter Main Room
            {
                Camera.main.transform.Translate(18, 0, 0);
                room = 3;
            }
        }
    }
}

