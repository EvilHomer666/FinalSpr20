using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float startDelay;
    private float spawnPosX = 15f;
    private float spawnRangeY = 7f;
    private float spawnPosZ = -9.3f;
    private ScoreManager scoreManager;
    private int scoreHighWaterMarkA = 100000;
    private int scoreHighWaterMarkB = 200000;
    private int scoreHighWaterMarkC = 300000;
    private float spawnRate = 0.25f;
    private float minSpawnInterval = 0.5f;
    public float spawnInterval = 1.25f;

    // Spawn manager array for enemies
    public GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        // Method to call a function at a certain time
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);

        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(scoreManager.score > scoreHighWaterMarkA)
        {
            incrementSpawnRate();
        }
        if (scoreManager.score > scoreHighWaterMarkB)
        {
            incrementSpawnRate();
        }
        if (scoreManager.score > scoreHighWaterMarkC)
        {
            incrementSpawnRate();
        }
    }

    // Custom functions to spawn random enemies and power ups
    void SpawnRandomEnemy()
    {
        // Randomly generate enemies
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, Random.Range (-spawnRangeY, spawnRangeY), spawnPosZ);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }

    // Custom method to decrease spawning enemies delay
    void incrementSpawnRate()
    {
        if (spawnInterval > minSpawnInterval)
        {
            spawnInterval = spawnInterval - spawnRate;
        }
    }
}


