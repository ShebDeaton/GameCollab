using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private int room;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        room = 4;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player Position: X = " + player.transform.position.x + " --- Y = " + player.transform.position.y + " --- Z = " +
        player.transform.position.z);
        Vector3 playerPosition = player.transform.position;
        if (playerPosition.x > 9.5 && room == 4)
        {
            Camera.main.transform.Translate(18, 0, 0);
            room = 5;
        }
        if (playerPosition.x < 8.5 && room == 5)
        {
            Camera.main.transform.Translate(-18, 0, 0);
            room = 4;
        }
    }
}
