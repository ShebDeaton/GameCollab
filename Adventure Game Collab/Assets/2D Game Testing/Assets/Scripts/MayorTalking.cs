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
        if (MainManager.Instance != null)
        {
            //If the player exits the tutorial (level == 2)
            if (MainManager.Instance.level == 2)
            {
                //Ask the player to visit cave
                dialogues[0] = "A hero! Finally! Please help me! For some unknown reason, we are in danger!";
                dialogues[1] = "Please, go to the cave to the north and get part of the legendary sword!";
                dialogues[2] = "Come back to me after!";
                //Mark tutorial complete
                MainManager.Instance.TutorialComplete = true;
            }
            //If the player exits the cave (level == 3
            if (MainManager.Instance.level == 3)
            {
                //Ask the player to visit forest.
                dialogues[0] = "You've returned! The next part is in the jungle to the right!";
                dialogues[1] = "Come back to me after!";
                //Inform of new player: Deflect
                dialogues[2] = "By the way, you can now reflect projectiles by hitting them!";
                //Mark cave complete
                MainManager.Instance.CaveComplete = true;
            }
            //If the player exits the forest (level == 4)
            if (MainManager.Instance.level == 4)
            {
                //Ask the player to visit the back room.
                dialogues[0] = "You've finally done it, with this last step your reflected projectiles are stronger.";
                dialogues[1] = "Now, come with me to the backroom.";
                //Ominous text. The final step.
                dialogues[2] = "It's almost time to complete the final step.";
                //Mark the Forest complete.
                MainManager.Instance.ForestComplete = true;
            }
        }
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
