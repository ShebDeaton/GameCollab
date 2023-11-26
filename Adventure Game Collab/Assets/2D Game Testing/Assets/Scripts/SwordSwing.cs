using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SwordSwing : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Sword Collided With " + collision.gameObject);
        if (collision.gameObject.CompareTag("ProjectileEnemy"))
        {
            Destroy(collision.gameObject);
            GameObject player = GameObject.Find("Player");
            PlayerController controller = player.gameObject.GetComponent<PlayerController>();
            if(controller != null)
            {
                if (controller.reflect)
                {
                    GameObject projectileObject = Instantiate(projectilePrefab, rb.position, Quaternion.identity);

                    PlayerProjectile projectile = projectileObject.GetComponent<PlayerProjectile>();
                    projectile.Launch(controller.lookdir, 150.0f);
                    if (MainManager.Instance != null)
                        MainManager.Instance.ProjectilesDeflected++;
                }
            }
            
        }

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
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
            TutorialBossController controller3 = collision.gameObject.GetComponent<TutorialBossController>();
            if (controller3 != null)
            {
                controller3.ChangeHealth(-1);
            }
        }
    }
}
