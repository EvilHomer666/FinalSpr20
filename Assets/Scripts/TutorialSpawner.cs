using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawner : MonoBehaviour
//{
//    [SerializeField] GameObject smallMeteor;
//    [SerializeField] GameObject largeMeteor;
//    private float spawnPosX = 15f;
//    private float spawnRangeY = 7f;
//    private float spawnPosZ = -9.3f;
//    private float timeBetweenEnemy;
//    public float startTimeBetweenEnemies;
//    public int numberOfEnemies;

//    // Update is called once per frame
//    void Update()
//    {
//        if (timeBetweenEnemy <= 0 && numberOfEnemies > 0)
//        {

//            Vector3 spawnPos = new Vector3(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), spawnPosZ);
//            Instantiate(smallMeteor, spawnPos, smallMeteor.transform.rotation);

//            //Instantiate(asteroid, transform.position, Quaternion.identity);
//            timeBetweenEnemy = startTimeBetweenEnemies;
//            numberOfEnemies --;
//        }
//        else
//        {
//            timeBetweenEnemy -= Time.deltaTime;
//        }
//    }
//}

{ 
    [SerializeField] float startDelay;
    [SerializeField] float spawnInterval;
    private float spawnPosX = 15f;
    private float spawnRangeY = 7f;
    private float spawnPosZ = -9.3f;

    // Spawn manager array for enemies
    public GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        // Method to call a function at a certain time
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);

        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
    }

    // Custom functions to spawn random enemies and power ups
    void SpawnRandomEnemy()
    {
        // Randomly generate enemies
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, Random.Range (-spawnRangeY, spawnRangeY), spawnPosZ);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}