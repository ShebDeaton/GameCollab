using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteTutorialFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MainManager.Instance.TutorialComplete = true;
            MainManager.Instance.level++;
            MainManager.Instance.currentHealth += (MainManager.Instance.difficulty);
        }
    }
}
