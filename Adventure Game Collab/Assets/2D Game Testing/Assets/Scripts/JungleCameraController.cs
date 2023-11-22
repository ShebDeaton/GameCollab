using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleCameraController : MonoBehaviour
{
    private GameObject player;
    public int room;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        room = 4;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player Position: X = " + player.transform.position.x + " --- Y = " + player.transform.position.y + " --- Z = " +
        //player.transform.position.z);
        Vector3 playerPosition = player.transform.position;
        if (room == 4) // Main Room Navigation
        {
            if (playerPosition.x > 9.5) // Enter Right Room
            {
                Camera.main.transform.Translate(18, 0, 0);
                room = 5;
            }
            if (playerPosition.x < -9.5) // Enter Left Room
            {
                Camera.main.transform.Translate(-18, 0, 0);
                room = 3;
            }
            if (playerPosition.y < -6) // Enter Bottom Room
            {
                Camera.main.transform.Translate(0, -10, 0);
                room = 6;
            }
            if (playerPosition.y > 5) // Enter Top Room
            {
                Camera.main.transform.Translate(0, 10, 0);
                room = 2;
            }
        }
        else if (room == 5) // Right Room Navigation / Movement Room
        {
            if (playerPosition.x < 8.5) // Enter Main Room
            {
                Camera.main.transform.Translate(-18, 0, 0);
                room = 4;
            }
        }
        else if (room == 3) // Left Room Navigation / Enemy Room
        {
            if (playerPosition.x > -8.5) // Enter Main Room
            {
                Camera.main.transform.Translate(18, 0, 0);
                room = 4;
            }
        }
        else if (room == 6) // Bottom Room Navigation / Shop Room
        {
            if (playerPosition.y > -5) // Enter Main Room
            {
                Camera.main.transform.Translate(0, 10, 0);
                room = 4;
            }
        }
        else if (room == 2) // Top Room Navigation / Boss Room
        {
            if (playerPosition.y < 4) // Enter Main Room
            {
                Camera.main.transform.Translate(0, -10, 0);
                room = 4;
            }
            if (playerPosition.y > 15) // Enter Exit Room
            {
                Camera.main.transform.Translate(0, 10, 0);
                room = 1;
            }
        }
        else if (room == 1) // Top Top Room Navigation / Exit Room
        {
            if (playerPosition.y < 14) // Enter Boss Room
            {
                Camera.main.transform.Translate(0, -10, 0);
                room = 2;
            }
        }
    }
}
