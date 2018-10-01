using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Image healthBarSprite;
    [SerializeField] private Text healthText;
    [SerializeField] private Text coinText;

    private void Start()
    {

    }

    private void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = gameManager.coins.ToString() + " / " + gameManager.maxCoins.ToString();
        healthText.text = "Health: " + gameManager.playerHealth + " /5";

        healthBarSprite.fillAmount = Mathf.Lerp(healthBarSprite.fillAmount, gameManager.playerHealth / 5f, 0.1f);
    }
}
