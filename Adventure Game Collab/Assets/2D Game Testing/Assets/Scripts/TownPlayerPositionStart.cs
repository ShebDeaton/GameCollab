using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TownPlayerPositionStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance.level == 2) //From Tutorial
        {
            transform.position = new Vector3 (0,-4,0);
        }
        if (MainManager.Instance.level == 3) //From Cave
        {
            transform.position = new Vector3(0, 22, 0);
        }
        if (MainManager.Instance.level == 4) //From Forest
        {
            transform.position = new Vector3(24, 9.5f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
