using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float dieLevel;
    [HideInInspector] public float playerHealth;
    [HideInInspector] public int coins;
    [HideInInspector] public int maxCoins = 10;

    [HideInInspector] public GameObject player;
    [HideInInspector] public bool isPlayerAlive;
    private bool gameWon;

    [SerializeField] private GameObject winUI;

    public List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        isPlayerAlive = true;
        player = FindObjectOfType<PlayerController>().gameObject;
        gameWon = false;
    }

    private void Update()
    {
        if (!isPlayerAlive)
            return;

        CheckForBounds();

        if (playerHealth <= 0)
        {
            EndGame();
            RestartLevel();
        }

        if(coins == maxCoins)
        {
            WinGame();
            gameWon = true;
        }

        if(gameWon)
        {
            if (Input.GetKeyDown(KeyCode.P))
                RestartLevel();
        }
    }

    void CheckForBounds()
    {
        if (player.transform.position.y < dieLevel)
            RestartLevel();
    }

    void WinGame()
    {
        winUI.SetActive(true);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        coins = 0;
    }

    public void DamagePlayer(int amount)
    {
        if (playerHealth > 1)
            playerHealth -= amount;
        else
            playerHealth = 0;
    }

    void EndGame()
    {
        isPlayerAlive = false;
        Destroy(player.gameObject);

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        enemies.Clear();
    }
}
