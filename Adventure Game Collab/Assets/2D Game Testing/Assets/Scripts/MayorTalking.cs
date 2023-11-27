using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MayorTalking : MonoBehaviour
{
    public GameObject TextbarBox;
    public TextMeshProUGUI dialogueText;
    public List<string> dialogues = new List<string>();
    private bool canTalk = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canTalk)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canTalk = false;
                //Starts the Talking
                GameObject player = GameObject.Find("Player");
                PlayerController controller = player.gameObject.GetComponent<PlayerController>();
                controller.isTalking(true);
                TextbarBox.SetActive(true);
                StartCoroutine(playTexts());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canTalk = true;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTalk = false;
    }

    IEnumerator playTexts()
    {
        //Plays each text one at a time
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < dialogues.Count; i++)
        {

            yield return StartCoroutine(showText(dialogues[i]));
        }
        TextbarBox.SetActive(false);
        GameObject player = GameObject.Find("Player");
        PlayerController controller = player.gameObject.GetComponent<PlayerController>();
        controller.isTalking(false);
        canTalk = true;
    }

    IEnumerator showText(string text)
    {
        //Displays the text itself
        dialogueText.text = text;
        if (MainManager.Instance != null)
        {
            //If the player exits the tutorial (level == 2)
            if (MainManager.Instance.level == 2)
            {
                //Ask the player to visit cave
                //Mark tutorial complete
                MainManager.Instance.TutorialComplete = true;
            }
            //If the player exits the cave (level == 3
            if (MainManager.Instance.level == 3)
            {
                //Ask the player to visit forest.
                //Inform of new player: Deflect
                //Mark cave complete
                MainManager.Instance.CaveComplete = true;
            }
            //If the player exits the forest (level == 4)
            if (MainManager.Instance.level == 4)
            {
                //Ask the player to visit the back room.
                //Ominous text. The final step.
                //Mark the Forest complete.
                MainManager.Instance.ForestComplete = true;
            }
        }
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
