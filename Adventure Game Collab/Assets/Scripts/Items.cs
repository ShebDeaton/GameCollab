using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int ID {  get; set; }
    public string Name { get; set; }
    
    public Items(int  id, string name)
    {
        ID = id;
        Name = name;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
