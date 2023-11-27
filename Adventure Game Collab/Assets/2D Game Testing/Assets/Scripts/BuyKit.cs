using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyKit : MonoBehaviour
{
    private bool canBuy = false;
    public AudioSource healthSource;
    // Start is called before the first frame update
    void Start()
    {
        healthSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canBuy)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if(MainManager.Instance.money > 0)
                {
                    GameObject player = GameObject.Find("Player");
                    PlayerController controller = player.gameObject.GetComponent<PlayerController>();
                    if (!(controller.currentHealth == controller.maxHealth))
                    {
                        healthSource.Play();
                        controller.ChangeHealth(+1);
                        controller.ChangeBalance(-1);
                    }

                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canBuy = true;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canBuy = false;
    }
}
