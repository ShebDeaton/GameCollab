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
    public Tile BossTile;
    public Tilemap Map;
    public GameObject BossHealthBar;
    private bool isRotated = false;
    private GameObject[] enemies;
    private GameObject[] Bosses;

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
        if ( enemies.Length == 0) //Enemy Door Left Room
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
        Bosses = GameObject.FindGameObjectsWithTag("Boss");
        //Opens Exit Room
        if (Bosses.Length == 0) //kill the Boss
        {
            BossHealthBar.SetActive(false);
            Vector3Int ExitDoorLocation1 = Map.WorldToCell(new Vector3(-1, 14, 0));
            ExitDoorLocation1.z += 1;
            Vector3Int ExitDoorLocation2 = Map.WorldToCell(new Vector3(0, 14, 0));
            ExitDoorLocation2.z += 1;
            Vector3Int ExitDoorLocation3 = Map.WorldToCell(new Vector3(-2, 14, 0));
            ExitDoorLocation3.z += 1;
            Vector3Int ExitDoorLocation4 = Map.WorldToCell(new Vector3(-3, 14, 0));
            ExitDoorLocation4.z += 1;
            Vector3Int ExitDoorLocation5 = Map.WorldToCell(new Vector3(1, 14, 0));
            ExitDoorLocation5.z += 1;
            Vector3Int ExitDoorLocation6 = Map.WorldToCell(new Vector3(2, 14, 0));
            ExitDoorLocation6.z += 1;
            Map.SetTile(ExitDoorLocation1, null); // Open the Exit Door
            Map.SetTile(ExitDoorLocation2, null); // Open the Exit Door
            Map.SetTile(ExitDoorLocation3, null); // Open the Exit Door
            Map.SetTile(ExitDoorLocation4, null); // Open the Exit Door
            Map.SetTile(ExitDoorLocation5, null); // Open the Exit Door
            Map.SetTile(ExitDoorLocation6, null); // Open the Exit Door
            Vector3Int BossDoorLocation1 = Map.WorldToCell(new Vector3(-1, 5, 0));
            BossDoorLocation1.z += 1;
            Vector3Int BossDoorLocation2 = Map.WorldToCell(new Vector3(0, 5, 0));
            BossDoorLocation2.z += 1;
            Vector3Int BossDoorLocation3 = Map.WorldToCell(new Vector3(-2, 5, 0));
            BossDoorLocation3.z += 1;
            Vector3Int BossDoorLocation4 = Map.WorldToCell(new Vector3(-3, 5, 0));
            BossDoorLocation4.z += 1;
            Vector3Int BossDoorLocation5 = Map.WorldToCell(new Vector3(1, 5, 0));
            BossDoorLocation5.z += 1;
            Vector3Int BossDoorLocation6 = Map.WorldToCell(new Vector3(2, 5, 0));
            BossDoorLocation6.z += 1;
            Map.SetTile(BossDoorLocation1, null); // Open the Boss Door
            Map.SetTile(BossDoorLocation2, null); // Open the Boss Door
            Map.SetTile(BossDoorLocation3, null); // Open the Boss Door
            Map.SetTile(BossDoorLocation4, null); // Open the Boss Door
            Map.SetTile(BossDoorLocation5, null); // Open the Boss Door
            Map.SetTile(BossDoorLocation6, null); // Open the Boss Door
            isRotated = false;
        }
        if (Bosses.Length == 1) // Boss is Alive.
        {
            BossHealthBar.SetActive(true);
            Vector3Int BossDoorLocation1 = Map.WorldToCell(new Vector3(-1, 5, 0));
            BossDoorLocation1.z += 1;
            Vector3Int BossDoorLocation2 = Map.WorldToCell(new Vector3(0, 5, 0));
            BossDoorLocation2.z += 1;
            Vector3Int BossDoorLocation3 = Map.WorldToCell(new Vector3(-2, 5, 0));
            BossDoorLocation3.z += 1;
            Vector3Int BossDoorLocation4 = Map.WorldToCell(new Vector3(-3, 5, 0));
            BossDoorLocation4.z += 1;
            Vector3Int BossDoorLocation5 = Map.WorldToCell(new Vector3(1, 5, 0));
            BossDoorLocation5.z += 1;
            Vector3Int BossDoorLocation6 = Map.WorldToCell(new Vector3(2, 5, 0));
            BossDoorLocation6.z += 1;
            Map.SetTile(BossDoorLocation1, BossTile); // Close the Boss Door
            Map.SetTile(BossDoorLocation2, BossTile); // Close the Boss Door
            Map.SetTile(BossDoorLocation3, BossTile); // Close the Boss Door
            Map.SetTile(BossDoorLocation4, BossTile); // Close the Boss Door
            Map.SetTile(BossDoorLocation5, BossTile); // Close the Boss Door
            Map.SetTile(BossDoorLocation6, BossTile); // Close the Boss Door
            if (!isRotated)
            {
                //Rotate the exit
                isRotated = true;
                Quaternion rotation = Quaternion.Euler(0, 0, 180f);
                Map.SetTransformMatrix(BossDoorLocation1, Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one));
                Map.SetTransformMatrix(BossDoorLocation2, Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one));
                Map.SetTransformMatrix(BossDoorLocation3, Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one));
                Map.SetTransformMatrix(BossDoorLocation4, Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one));
                Map.SetTransformMatrix(BossDoorLocation5, Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one));
                Map.SetTransformMatrix(BossDoorLocation6, Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one));
            }
            Vector3Int ExitDoorLocation1 = Map.WorldToCell(new Vector3(-1, 14, 0));
            ExitDoorLocation1.z += 1;
            Vector3Int ExitDoorLocation2 = Map.WorldToCell(new Vector3(0, 14, 0));
            ExitDoorLocation2.z += 1;
            Vector3Int ExitDoorLocation3 = Map.WorldToCell(new Vector3(-2, 14, 0));
            ExitDoorLocation3.z += 1;
            Vector3Int ExitDoorLocation4 = Map.WorldToCell(new Vector3(-3, 14, 0));
            ExitDoorLocation4.z += 1;
            Vector3Int ExitDoorLocation5 = Map.WorldToCell(new Vector3(1, 14, 0));
            ExitDoorLocation5.z += 1;
            Vector3Int ExitDoorLocation6 = Map.WorldToCell(new Vector3(2, 14, 0));
            ExitDoorLocation6.z += 1;
            Map.SetTile(ExitDoorLocation1, BossTile); // Close the Exit Door
            Map.SetTile(ExitDoorLocation2, BossTile); // Close the Exit Door
            Map.SetTile(ExitDoorLocation3, BossTile); // Close the Exit Door
            Map.SetTile(ExitDoorLocation4, BossTile); // Close the Exit Door
            Map.SetTile(ExitDoorLocation5, BossTile); // Close the Exit Door
            Map.SetTile(ExitDoorLocation6, BossTile); // Close the Exit Door
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
                if (Input.GetKeyDown(KeyCode.Q))
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
