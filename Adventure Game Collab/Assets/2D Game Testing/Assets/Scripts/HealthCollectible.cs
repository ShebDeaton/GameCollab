using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{

    public int value = 1;
    public AudioSource healthSource;

    private void Start()
    {
        healthSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        
        if (player != null)
        {
            healthSource.Play();
            if (player.health < player.maxHealth)
            {
                player.ChangeHealth(value);
                Destroy(gameObject);
            }
        }
    }
}
