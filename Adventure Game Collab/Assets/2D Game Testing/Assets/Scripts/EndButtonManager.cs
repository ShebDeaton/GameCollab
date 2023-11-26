using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndButtonManager : MonoBehaviour
{
    public TextMeshProUGUI Stats;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.Instance != null)
        {
            Stats.text = "Enemies Killed: " + MainManager.Instance.EnemiesKilled + "\n" +
                     "Damage Taken: " + MainManager.Instance.DamageTaken + "\n" +
                     "Projectiles Deflected: " + MainManager.Instance.ProjectilesDeflected;
        }
    }
}
