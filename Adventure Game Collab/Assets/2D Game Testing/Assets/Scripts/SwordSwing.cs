using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    Rigidbody2D rb;
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
