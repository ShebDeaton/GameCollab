using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthBar : MonoBehaviour
{
    public static PlayerHealthBar instance { get ; private set; }
    public TextMeshProUGUI coinAmount;
    public Image mask;
    float originalSize;
    // Start is called before the first frame update
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * (MainManager.Instance.currentHealth / (float)(10 + (MainManager.Instance.level * MainManager.Instance.difficulty))));
    }

    private void Awake()
    {
        instance = this;
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }

    public void SetBalance(int bal)
    {
        coinAmount.text = bal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
