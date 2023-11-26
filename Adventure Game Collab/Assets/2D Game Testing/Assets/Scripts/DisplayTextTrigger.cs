using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;
using UnityEngine.UI;
using TMPro;

public class DisplayTextTrigger : MonoBehaviour
{
    public GameObject TextbarBox;
    public TextMeshProUGUI dialogueText;
    public List<string> dialogues = new List<string>();
    public bool singleTime = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.gameObject.CompareTag("Player"))
        {
            //Starts the Talking
            PlayerController controller = collision.gameObject.GetComponent<PlayerController>();
            controller.isTalking(true);
            TextbarBox.SetActive(true);
            StartCoroutine(playTexts());
            
        }
    }

    IEnumerator playTexts()
    {
        //Plays each text one at a time
        
        for (int i = 0; i < dialogues.Count; i++)
        {

            yield return StartCoroutine(showText(dialogues[i]));
        }       
        TextbarBox.SetActive(false);
        GameObject player = GameObject.Find("Player");
        PlayerController controller = player.gameObject.GetComponent<PlayerController>();
        controller.isTalking(false);
        if (singleTime)
        {
            //If it's a one-time dialogue, delete it after.
            Destroy(gameObject);
        }
    }

    IEnumerator showText(string text)
    {
        //Displays the text itself
        dialogueText.text = text;
        //Waits for space
        yield return StartCoroutine(WaitForKey(KeyCode.Space));
    }

    IEnumerator WaitForKey(KeyCode key)
    {
        while (!Input.GetKeyDown(key))
            yield return null;
        yield return new WaitForFixedUpdate();
    }

}
