using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BarrelBridgeTutorial : MonoBehaviour
{
    public Tile Bridge;
    public Tilemap Map;
    public Vector3 bridgeArea;
    private Boolean bridgePlaced = false;
    private Boolean isRotated = false;
    private Vector3 barrelStart;
    private int room;

    // Start is called before the first frame update
    void Start()
    {
        bridgeArea.Set(22,-3,0); // Area for Bridge
        barrelStart.Set(17,-2,0);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        room = GameObject.Find("Main Camera").GetComponent<CameraController>().room;
        if (Vector3.Distance(Map.WorldToCell(transform.position), Map.WorldToCell(bridgeArea)) <= 1.5)
        {
            Vector3Int BridgeLocation = Map.WorldToCell(bridgeArea);        
            if (!bridgePlaced)
            {
                bridgePlaced = true;
                Destroy(this.gameObject);
            }
            Map.SetTile(BridgeLocation, Bridge); // Place the Bridge
            if (!isRotated)
            {
                //Rotate the bridge
                isRotated = true;
                Quaternion rotation = Quaternion.Euler(0,0,90f);
                Map.SetTransformMatrix(BridgeLocation, Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one));
            }
        }

        if (!bridgePlaced && (room != 5)) //Room isn't 5 (Movement Room) AND Bridge has not been placed
        {
            //Set Barrel back to starting position.
            transform.position = barrelStart;
        }
    }
}
