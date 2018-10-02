using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float minSpawn = -70f;
    private float maxSpawn = 70f;

    [SerializeField] private int amountOfEnemies;
    [SerializeField] private int amountOfCoins;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        SpawnObjects(amountOfCoins, coinPrefab);
        SpawnObjects(amountOfEnemies, enemyPrefab);
    }

    public void SpawnObjects(int amount, GameObject objectToSpawn)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 spawnPosition = Utility.PickSpawnLocation(minSpawn, maxSpawn);
            GameObject obj = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            if (obj.CompareTag("Enemy"))
            {
                gameManager.enemies.Add(obj);
            }
        }
    }
}
