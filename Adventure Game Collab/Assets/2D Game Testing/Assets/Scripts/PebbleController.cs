using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PebbleController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject Money;
    Rigidbody2D rb;
    public int dir;
    private Vector2 Direction;
    public int maxHealth = 3;
    int currentHealth;
    public float delay = 3.0f;
    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 0.25f;
    public int health { get { return currentHealth; } }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        StartCoroutine(ShootProjectile());
        if (dir == 1)
        {
            Direction = Vector2.left;
        }
        if (dir == 2)
        {
            Direction = Vector2.right;
        }
        if (dir == 3)
        {
            Direction = Vector2.up;
        }
        if (dir == 4)
        {
            Direction = Vector2.down;
        }
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
            if (MainManager.Instance != null)
                MainManager.Instance.EnemiesKilled++;
        }
    }

    IEnumerator ShootProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Launch(Direction);
        }
    }
    void Launch(Vector2 Direction)
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Direction * 0.5f, Quaternion.identity);

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