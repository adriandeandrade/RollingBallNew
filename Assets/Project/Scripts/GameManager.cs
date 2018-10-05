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

    public static GameObject player;

    private bool gameWon;

    public List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private Vector3 teleportPos;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        gameWon = false;
        coins = 0;
    }

    private void Update()
    {
        if (player == null)
            return;

        CheckForBounds();

        if (playerHealth <= 0)
        {
            EndGame();
        }

        if (coins == maxCoins)
        {
            UIManager.ActivateUI("winUI");
            gameWon = true;
        }

        // Restart game
        if (gameWon)
        {
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }

            enemies.Clear();

            if (Input.GetKeyDown(KeyCode.P))
                EndGame();
        }
    }

    void CheckForBounds()
    {
        if (player.transform.position.y < dieLevel)
        {
            player.transform.position = teleportPos;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero; // Reset speed after reset so the ball doesnt keep moving.
        }
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
        Destroy(player.gameObject);

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        enemies.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
