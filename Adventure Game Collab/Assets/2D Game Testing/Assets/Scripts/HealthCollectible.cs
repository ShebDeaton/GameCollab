using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{

    public int value = 1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        
        if (player != null)
        {
            if (player.health < player.maxHealth)
            {
                player.ChangeHealth(value);
                Destroy(gameObject);
            }
        }
    }
}
