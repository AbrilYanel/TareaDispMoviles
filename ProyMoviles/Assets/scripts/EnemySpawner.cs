using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 20;
    public float levelWidth = 3f;
    public float minY = 2f;
    public float maxY = 80f;

    void Start()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            float spawnX = Random.Range(-levelWidth, levelWidth);
            float spawnY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
