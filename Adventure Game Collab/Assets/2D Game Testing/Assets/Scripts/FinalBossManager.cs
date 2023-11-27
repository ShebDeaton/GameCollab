using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossManager : MonoBehaviour
{
    public int maxHealth = 1;
    public int currentHealth;
    Rigidbody2D rb;
    public GameObject winText;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth == 0)
        {
            Destroy(gameObject);
            MainManager.Instance.EnemiesKilled++;
            MainManager.Instance.currentHealth = 0;
            winText.SetActive(true);

        }
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
