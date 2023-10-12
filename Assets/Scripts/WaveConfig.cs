using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Configuration")]

public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public List<Transform> GetWaypoints() { 
        var waveWaypoints = new List<Transform>();
        
        foreach (Transform child in pathPrefab.transform) { 
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public float GetTimeBetweenSpawn() { return timeBetweenSpawns; }
    public float GetTimeBetweenSpawns() { return spawnRandomFactor; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }
    public float GetMoveSpeed() { return moveSpeed; }
}
