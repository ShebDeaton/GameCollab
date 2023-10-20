using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int balance = 0;

    public TextMeshProUGUI moneyText;
    void Start()
    {
        moneyText.text = "" + balance;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AddMoney(10);
        }
    }
    public void AddMoney(int cash)
    {
        balance += cash;
        moneyText.text = ""+balance;
    }
}
