﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarAwayBattleFX : MonoBehaviour
{
    private float spawnPosX = 7.0f;
    private float spawnPosXx = 10.0f;
    private float spawnRangeY = 2.0f;
    private float spawnPosZ = 0.0f;
    public float spawnInterval = 1.25f;
    public float startDelay;

    // Spawn manager array for enemy prefabs
    public GameObject[] explosionPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        // Method to call a function at a certain time
        InvokeRepeating("SpawnRandomExplosion", startDelay, spawnInterval);
    }

    // Custom functions to spawn random explosions
    void SpawnRandomExplosion()
    {
        // Randomly generate explosions
        int explosionIndex = Random.Range(0, explosionPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosXx), Random.Range(-spawnRangeY, spawnRangeY), spawnPosZ);
        Instantiate(explosionPrefabs[explosionIndex], spawnPos, explosionPrefabs[explosionIndex].transform.rotation);
    }
}
