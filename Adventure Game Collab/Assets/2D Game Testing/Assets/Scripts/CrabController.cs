using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CrabController : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject Money;
    public bool horizontal;
    public float pathTime = 3.0f;
    float timer;
    int pathDirection = -1;
    Rigidbody2D rb;
    Animator animator;
    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 0.25f;
    public int health { get { return currentHealth; } }
    public int maxHealth = 5;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = pathTime;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
       timer -= Time.deltaTime;
        
        if (timer < 0)
        {
            pathDirection = -pathDirection;
            transform.Rotate(Vector3.up,180);
            timer = pathTime;
        }

        if (isInvincible)
        {
            timer += Time.deltaTime;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
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
