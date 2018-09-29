using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private float minSpawn = -70f;
    private float maxSpawn = 70f;

    [SerializeField] private int amountToSpawn;

    [SerializeField] private GameObject coinPrefab;

    private void Start()
    {
        SpawnCoin(amountToSpawn);
    }

    public void SpawnCoin(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 spawnPosition = Utility.PickSpawnLocation(minSpawn, maxSpawn);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
