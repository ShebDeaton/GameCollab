using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PebbleController : MonoBehaviour
{
    public GameObject projectilePrefab;
    Rigidbody2D rb;
    public int dir;
    private Vector2 Direction;
    public int maxHealth = 5;
    int currentHealth;
    public float delay = 3.0f;

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
}