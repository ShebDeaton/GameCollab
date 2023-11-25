using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBossController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject Money;
    Rigidbody2D rb;
    public int dir;
    private Vector2 Direction;
    public int maxHealth = 3;
    int currentHealth;
    public float delay = 1.5f;
    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 0.25f;
    public int health { get { return currentHealth; } }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
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
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector2.down * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(Vector2.down, 300.0f);
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
