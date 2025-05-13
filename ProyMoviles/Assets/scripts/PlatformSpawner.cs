using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms = 100;
    public float levelWidth = 3f;
    public float minY = 1f;
    public float maxY = 2f;

    public float startY = 0f;
    private float spawnY;

    void Start()
    {
        spawnY = startY;

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-levelWidth, levelWidth), spawnY, 0);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            spawnY += Random.Range(minY, maxY);
        }
    }
}
