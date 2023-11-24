using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ButtonPress : MonoBehaviour
{
    public Tile buttonPressed;
    public Tile CageOpen;
    public Tile DoorOpen;
    public Tilemap Map;
    private GameObject[] enemies;

    private Vector3 Button1;
    private Boolean Button1Pressed = false;
    private Vector3 Button2;
    private Boolean Button2Pressed = false;
    private Vector3 Button3;
    private Boolean Button3Pressed = false;
    private int ButtonsPressed = 0;

    private Vector3 RedKey;
    private Boolean RedKeyAquired = false;
    // Start is called before the first frame update
    void Start()
    {
        Button1.Set(-25, 2, 0); // Left Room Button
        Button2.Set(-7, -13, 0); // Bottom Room Button
        Button3.Set(24, 2, 0); //Right Room Button

        RedKey.Set(0, -12, 1); // Bottom Room Red Key     
    }

    // Update is called once per frame
    void Update()
    {
       //Open Red Door
       if (RedKeyAquired)
        {
            Vector3Int RedDoorLocation = Map.WorldToCell(new Vector3(-7,-11,0));
            Map.SetTile(RedDoorLocation,DoorOpen);
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if ( enemies.Length == 0 ) //Enemy Door Left Room
         {
             Vector3Int DoorLocation = (Map.WorldToCell(Button1));
             DoorLocation.y -= 2;
             Map.SetTile(DoorLocation, CageOpen); // Open the Door
         }

       //Open Boss Room
       if (ButtonsPressed == 3)
        {
            Vector3Int BossDoorLocation1 = Map.WorldToCell(new Vector3(-1, 4, 0));
            BossDoorLocation1.z += 1;
            Vector3Int BossDoorLocation2 = Map.WorldToCell(new Vector3(0, 4, 0));
            BossDoorLocation2.z += 1;
            Vector3Int BossDoorLocation3 = Map.WorldToCell(new Vector3(-2, 4, 0));
            BossDoorLocation3.z += 1;
            Vector3Int BossDoorLocation4 = Map.WorldToCell(new Vector3(-3, 4, 0));
            BossDoorLocation4.z += 1;
            Vector3Int BossDoorLocation5 = Map.WorldToCell(new Vector3(1, 4, 0));
            BossDoorLocation5.z += 1;
            Vector3Int BossDoorLocation6 = Map.WorldToCell(new Vector3(2, 4, 0));
            BossDoorLocation6.z += 1;
            Map.SetTile(BossDoorLocation1, null); // Open the Boss Door
            Map.SetTile(BossDoorLocation2, null); // Open the Boss Door
            Map.SetTile(BossDoorLocation3, null); // Open the Boss Door
            Map.SetTile(BossDoorLocation4, null); // Open the Boss Door
            Map.SetTile(BossDoorLocation5, null); // Open the Boss Door
            Map.SetTile(BossDoorLocation6, null); // Open the Boss Door
        }
    }

    private void LateUpdate()
    {
        //Left Room Button
        if (Vector3.Distance(Map.WorldToCell(transform.position), Map.WorldToCell(Button1)) <= .5)
        {
            Vector3Int ButtonLocation = Map.WorldToCell(Button1);
            Map.SetTile(ButtonLocation, buttonPressed); // Press Button
            if (!Button1Pressed)
            {
                Button1Pressed = true;
                ButtonsPressed++;
            }
        }
        //Bottom Room Button
        if (Vector3.Distance(Map.WorldToCell(transform.position), Map.WorldToCell(Button2)) <= .5)
        {
            Vector3Int ButtonLocation = Map.WorldToCell(Button2);
            Map.SetTile(ButtonLocation, buttonPressed); // Press Button
            if (!Button2Pressed)
            {
                Button2Pressed = true;
                ButtonsPressed++;
            }
        }
        //Right Room Button
        if (Vector3.Distance(Map.WorldToCell(transform.position), Map.WorldToCell(Button3)) <= .5)
        {
            Vector3Int ButtonLocation = Map.WorldToCell(Button3);
            Map.SetTile(ButtonLocation, buttonPressed); // Press Button
            if (!Button3Pressed)
            {
                Button3Pressed = true;
                ButtonsPressed++;
            }
        }
        

        //Red Key Aquire
        if (Vector3.Distance(Map.WorldToCell(transform.position), Map.WorldToCell(RedKey)) <= 1)
        {
            PlayerController controller = gameObject.GetComponent<PlayerController>();
            if (controller.bal >= 3) //Check for Balance
            {
                //Space to Confirm Purchase
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Vector3Int KeyLocation = Map.WorldToCell(RedKey);
                    KeyLocation.z += 1;
                    Map.SetTile(KeyLocation, null); // Take Key
                    if (!RedKeyAquired)
                    {
                        RedKeyAquired = true;
                    }
                    controller.ChangeBalance(-3);
                }
            }
        }
    }
}
