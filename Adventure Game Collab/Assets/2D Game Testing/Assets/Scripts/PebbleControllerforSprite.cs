using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PebbleControllerforSprite : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject Money;
    public GameObject HealthCollectible;
    Rigidbody2D rb;
    public int dir;
    private Vector2 Direction1;
    private Vector2 Direction2;
    private Vector2 Direction3;
    public int maxHealth = 10;
    int currentHealth;
    public float delay = 0.25f;
    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 0.25f;
    public int health { get { return currentHealth; } }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        
       
        Direction1 = Vector2.left;
        
        Direction2 = Vector2.right;
        
        Direction3 = Vector2.down;

        StartCoroutine(ShootProjectile());
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        if (currentHealth == 0)
        {
            Destroy(gameObject);
            Instantiate(Money, rb.position, Quaternion.identity);
            Instantiate(HealthCollectible, rb.position, Quaternion.identity);
        }
    }

    IEnumerator ShootProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Launch(Direction1);
            Launch(Direction2);
            Launch(Direction3);
        }
    }
    void Launch(Vector2 Direction)
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Direction * 2.0f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(Direction, 150.0f);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}