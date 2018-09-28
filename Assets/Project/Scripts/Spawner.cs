using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float minSpawn = -21f;
    private float maxSpawn = 21f;

    [SerializeField] private int amountToSpawn;

    [SerializeField] private GameObject enemyPrefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy(amountToSpawn);
        }
    }

    public void SpawnEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 spawnPosition = PickSpawnLocation();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 PickSpawnLocation()
    {
        float randomX = Random.Range(minSpawn, maxSpawn);
        float randomZ = Random.Range(minSpawn, maxSpawn);
        Vector3 spawnPos = new Vector3(randomX, 1.5f, randomZ);

        return spawnPos;
    }
}
