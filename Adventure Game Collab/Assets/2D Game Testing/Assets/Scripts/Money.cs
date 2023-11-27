using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int value = 5;
    Rigidbody2D rb;
    public AudioClip audioClip;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerController controller = collision.gameObject.GetComponent<PlayerController>();
            if (controller != null)
                controller.ChangeBalance(value);
            GetComponent<AudioSource>().Play();
        }
    }

}
