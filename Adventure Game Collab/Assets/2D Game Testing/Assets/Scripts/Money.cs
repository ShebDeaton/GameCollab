using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int value = 5;
    Rigidbody2D rb;
    public AudioSource coinSource;
    public AudioClip coinSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioSource coinSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            coinSource.PlayOneShot(coinSound);
            Destroy(gameObject);
            PlayerController controller = collision.gameObject.GetComponent<PlayerController>();
            if (controller != null)
                controller.ChangeBalance(value);
            
        }
    }

}
