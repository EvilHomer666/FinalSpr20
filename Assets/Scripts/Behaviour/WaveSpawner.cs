using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState
    {
        SPAWNING, WAITING, COUNTING
    }

    // Start is called before the first frame update
    void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if(!EnemyIsAlive())
            {
                // begin new round of waves
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }

        if(waveCountDown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    private void WaveCompleted()
    {
        Debug.Log("Wave completed");
        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length -1)
        {
            nextWave = 0;
            Debug.Log("All waves complete! Looping...");

            // Here we can add difficulty multiplier or load a new scene etc.
        }
        else
        {
            nextWave++;
        }
    }

    private bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("EnemyShip") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log($"Spawning wave: {wave.name}");
        state = SpawnState.SPAWNING;
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy (Transform enemy)
    {
        // spawn enemy
        Debug.Log($"Spawning Enemy: {enemy.name}");
        Transform spawnLocation = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, spawnLocation.position, spawnLocation.rotation);
    }

    // Custom methods 
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float spawnRate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountDown;

    private float searchCountDown = 1f;

    private SpawnState state = SpawnState.COUNTING;
}
