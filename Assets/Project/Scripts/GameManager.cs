using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float dieLevel;
    [SerializeField] private float playerHealth;

    [HideInInspector] public GameObject player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void Update()
    {
        CheckForBounds();

        if (playerHealth <= 0)
        {
            EndGame();
        }

        if (Input.GetKey(KeyCode.R))
            EndGame();
    }

    void CheckForBounds()
    {
        if (player.transform.position.y < dieLevel)
        {
            // Show restart prompt
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void DamagePlayer(int amount)
    {
        playerHealth -= amount;
    }

    void EndGame()
    {
        Destroy(player.gameObject);
    }

}
