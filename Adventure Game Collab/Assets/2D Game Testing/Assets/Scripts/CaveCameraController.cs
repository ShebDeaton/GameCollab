using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCameraController : MonoBehaviour
{
    private GameObject player;
    private int room;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        room = 1; // Main Room 

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        if (room == 1) // Main Room Navigation
        {
            if (playerPosition.x > 9.5) // Enter Right Room
            {
                Camera.main.transform.Translate(18, 0, 0);
                room = 2;
            }
            if (playerPosition.x < -9.4) // Enter Left Room
            {
                Camera.main.transform.Translate(-18, 0, 0);
                room = 3;
            }
            if (playerPosition.y > 5.1) // Enter Top Room
            {
                Camera.main.transform.Translate(0, 10, 0);
                room = 5;
            }
        }
        else if (room == 2) // Right Room Navigation / Enemy Room
        {
            if (playerPosition.x < 8.3) // Enter Main Room
            {
                Camera.main.transform.Translate(-18, 0, 0);
                room = 1;
            }
        }
        else if (room == 3) // Left Room Navigation / Maze Room
        {
            if (playerPosition.y > 5) // Enter Shop Room in Left Room
            {
                Camera.main.transform.Translate(0, 10, 0);
                room = 4;
            }

            if (playerPosition.x > -8.4) // Enter Main Room
            {
                Camera.main.transform.Translate(18, 0, 0);
                room = 1;
            }
        }
        else if (room == 4) // Upper Left Room Navigation / Shop Room
        {
            if (playerPosition.y < 4) // Enter Left Room
            {
                Camera.main.transform.Translate(0, -10, 0);
                room = 3;
            }
        }
        else if (room == 5) // Top Room Navigation / Boss Room
        {
            if (playerPosition.y < 3.9) // Enter Main Room
            {
                Camera.main.transform.Translate(0, -10, 0);
                room = 1;
            }
            //if (playerPosition.y > 15) // Enter Exit Room
            //{
                //Camera.main.transform.Translate(0, 10, 0);
                //room = 1;
            //}
        }
        //else if (room == 1) // Top Top Room Navigation / Exit Room
        //{
            //if (playerPosition.y < 14) // Enter Boss Room
            //{
                //Camera.main.transform.Translate(0, -10, 0);
                //room = 2;
            //}
        //}
    }
}
