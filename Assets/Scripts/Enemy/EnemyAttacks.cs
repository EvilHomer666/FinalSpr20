using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] Transform enemyFireSpawn;
    private SoundManager soundManager;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        InvokeRepeating("Attack", delay, fireRate);
    }

    // Custom method for enemy to attack player with a projectile
        void Attack()
    {
        // Instantiate enemy projectile at enemy position and play SFX
        Instantiate(enemyProjectile, enemyFireSpawn.position, enemyFireSpawn.rotation);
        soundManager.EnemyHomingProjectile();
    }
}
