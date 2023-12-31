using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TownProgressionFences : MonoBehaviour
{
    public Tilemap Map;
    public Tile DoorOpen;
    public Tile Fence;
    public Tile wall;
    public bool isRotated;
    private GameObject[] FinalBosses;
    private GameObject[] FinalBossMinions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.Instance != null)
        {
            if (MainManager.Instance.TutorialComplete)
            {
                Vector3Int CaveFence1 = Map.WorldToCell(new Vector3(-1, 23, 0));
                CaveFence1.z += 1;
                Vector3Int CaveFence2 = Map.WorldToCell(new Vector3(0, 23, 0));
                CaveFence2.z += 1;
                Map.SetTile(CaveFence1, null); // Open the Cave Fence 
                Map.SetTile(CaveFence2, null); // Open the Cave Fence
            }
            if (MainManager.Instance.level == 3 || MainManager.Instance.level == 4) 
            {
                Vector3Int CaveFence1 = Map.WorldToCell(new Vector3(-1, 23, 0));
                CaveFence1.z += 1;
                Vector3Int CaveFence2 = Map.WorldToCell(new Vector3(0, 23, 0));
                CaveFence2.z += 1;
                Map.SetTile(CaveFence1, Fence); // Close the Cave Fence 
                Map.SetTile(CaveFence2, Fence); // Close the Cave Fence
            }
            if (MainManager.Instance.CaveComplete)
            {
                Vector3Int ForestFence1 = Map.WorldToCell(new Vector3(25, 10, 0));
                ForestFence1.z += 1;
                Vector3Int ForestFence2 = Map.WorldToCell(new Vector3(25, 9, 0));
                ForestFence2.z += 1;
                Map.SetTile(ForestFence1, null); // Open the Forest Fence 
                Map.SetTile(ForestFence2, null); // Open the Forest Fence
            }
            if (MainManager.Instance.level == 4)
            {
                Vector3Int ForestFence1 = Map.WorldToCell(new Vector3(25, 10, 0));
                ForestFence1.z += 1;
                Vector3Int ForestFence2 = Map.WorldToCell(new Vector3(25, 9, 0));
                ForestFence2.z += 1;
                Map.SetTile(ForestFence1, Fence); // Close the Forest Fence 
                Map.SetTile(ForestFence2, Fence); // Close the Forest Fence
            }
            if (MainManager.Instance.ForestComplete)
            {
                Vector3Int FinalDoor = Map.WorldToCell(new Vector3(-27, 6, 0));
                FinalDoor.z += 1;
                if (!isRotated)
                {
                    //Rotate the exit
                    isRotated = true;
                    Quaternion rotation = Quaternion.Euler(0, 0, 90f);
                    Map.SetTransformMatrix(FinalDoor, Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one));
                }
                Map.SetTile(FinalDoor, DoorOpen); // Open the Final Boss Door 
                Vector3Int FinalDoorFence = Map.WorldToCell(new Vector3(-27, 6, 0));
                FinalDoorFence.z -= 1;
                Map.SetTile(FinalDoorFence, null); // Open the Final Fence
            }
        }
        FinalBosses = GameObject.FindGameObjectsWithTag("Final Boss");
        if (FinalBosses.Length == 1) // Final Boss has been spawned and is alive
        {
            Vector3Int FinalBossIndoorDoor = Map.WorldToCell(new Vector3(-28, 6, 0));
            Map.SetTile(FinalBossIndoorDoor, wall); // Cosmetic block
            Vector3Int FinalBossIndoorDoorFence = Map.WorldToCell(new Vector3(-28, 6, 0));
            FinalBossIndoorDoorFence.z -= 1;
            Map.SetTile(FinalBossIndoorDoorFence, Fence); // Block the exit 
        }


    }
}
