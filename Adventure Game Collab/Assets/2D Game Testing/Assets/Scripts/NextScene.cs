using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class NextScene : MonoBehaviour
{
    public string SceneName;

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
            SceneManager.LoadScene(SceneName);
        }
    }

    public void loadTutorialDungeon()
    {
        SceneManager.LoadScene("Tutorial Dungeon");
    }

    public void setDifficulty(int diff)
    {
        MainManager.Instance.difficulty = diff;
        MainManager.Instance.currentHealth = 10 + MainManager.Instance.level * diff;
    }
}
