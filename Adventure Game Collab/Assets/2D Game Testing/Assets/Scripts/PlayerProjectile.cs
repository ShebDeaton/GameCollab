using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector2 dir;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
        dir = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Projectile Collided With " + collision.gameObject);
        GameObject player = GameObject.Find("Player");
        PlayerController pcontroller = player.gameObject.GetComponent<PlayerController>();
        if (pcontroller != null)
        {
            if (pcontroller.speedGrade)
            {
                if (!collision.gameObject.CompareTag("ProjectileEnemy"))
                {
                    Destroy(gameObject);
                }
                Launch(dir, 300.0f);
            }
            else
            {
                Destroy(gameObject);
            }
            if (collision.gameObject.CompareTag("Enemy"))
            {

                PebbleController controller = collision.gameObject.GetComponent<PebbleController>();
                if (controller != null)
                {
                    controller.ChangeHealth(-1);
                }
                CrabController controller2 = collision.gameObject.GetComponent<CrabController>();
                if (controller2 != null)
                {
                    controller2.ChangeHealth(-1);
                }
            }
        }
    }
}
