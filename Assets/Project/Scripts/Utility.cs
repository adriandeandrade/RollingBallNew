using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Helper class to for useful functions. 
 */

public static class Utility
{
    public static Vector3 PickSpawnLocation(float min, float max)
    {
        float randomX = Random.Range(min, max);
        float randomZ = Random.Range(min, max);
        Vector3 spawnPos = new Vector3(randomX, 1.5f, randomZ);

        return spawnPos;
    }
}
