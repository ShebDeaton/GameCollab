using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CrabController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool horizontal;
    public float pathTime = 3.0f;
    float timer;
    int pathDirection = -1;
    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = pathTime;
        animator = GetComponent<Animator>(); 
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
    }

    void FixedUpdate()
    {
        Vector2 position = rb.position;

        if (horizontal)
        {
            position.x = position.x + Time.deltaTime * speed * pathDirection;
        }
        else
        {
            position.y = position.y + Time.deltaTime * speed * pathDirection;
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
}
