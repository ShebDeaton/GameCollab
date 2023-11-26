using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBossController : MonoBehaviour
{
    public GameObject projectilePrefab;
    Rigidbody2D rb;
    float timer;
    public float pathTime = 3.0f;
    public bool horizontal;
    int pathDirection = -1;
    public float speed = 3.0f;
    public int dir;
    private Vector2 Direction;
    public int maxHealth = 5;
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
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            pathDirection = -pathDirection;
            transform.Rotate(Vector3.up, 180);
            timer = pathTime;
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            timer += Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        if (currentHealth == 0)
        {
            gameObject.SetActive(false);
            MainManager.Instance.EnemiesKilled++;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rb.position;
        if (!isInvincible)
        {
            if (horizontal)
            {
                position.x = position.x + Time.deltaTime * speed * pathDirection;
            }
            else
            {
                position.y = position.y + Time.deltaTime * speed * pathDirection;
            }
        }

        rb.MovePosition(position);
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
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector2.down * 1f, Quaternion.identity);

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
        BossHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
