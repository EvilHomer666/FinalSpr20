﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] int scoreValue;
    [SerializeField] float enemyHitPoints;
    [SerializeField] bool holdsPowerUp;
    [SerializeField] GameObject powerUpDrop;
    [SerializeField] Transform powerUpSpawn;
    [SerializeField] GameObject onDestroyExplosion;
    private ProjectileImpact damageMultiplier;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private float minimumDamage = 1f;
    private float collateralDamage = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to GameManager script
        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();

        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        damageMultiplier = FindObjectOfType<ProjectileImpact>();
    }

    // On trigger enter function over-ride - Destroy target and projectile on collision
    private void OnTriggerEnter(Collider other)
    {
        // Player fire check
        if (other.gameObject.tag == "PlayerProjectile")
        {
            Debug.Log("Target Hit!");
            Destroy(other.gameObject);
            if (damageMultiplier != null)
            {
                enemyHitPoints -= damageMultiplier.damageValueMultiplier;
            }
            else
            {
                enemyHitPoints -= minimumDamage;
            }

            if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "EnemyShip")
            {
                soundManager.EnemyShipEngaged();
            }
            else if (enemyHitPoints <= 0)
            {
                Instantiate(onDestroyExplosion, transform.position, transform.rotation);
                GameObject.Find("Flash").GetComponent<ParticleSystem>().Play();
                soundManager.EnemyShipDestroyed();
                scoreManager.IncrementScore(scoreValue);
                Destroy(gameObject);
                Debug.Log("Target Destroyed!");

            }

            if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Hazard")
            {
                soundManager.LargeAsteroidHit();
            }
            else if (enemyHitPoints <= 0)
            {
                Instantiate(onDestroyExplosion, transform.position, transform.rotation);
                GameObject.Find("Flash").GetComponent<ParticleSystem>().Play();
                soundManager.LargeAsteroidDestroyed();
                scoreManager.IncrementScore(scoreValue);
                Destroy(gameObject);
                Debug.Log("Target Destroyed!");
            }

            if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "HazardHP" || gameObject.tag == "HazardSP")
            {
                soundManager.LargeAsteroidHit();
            }
            else if (enemyHitPoints <= 0)
            {
                Instantiate(onDestroyExplosion, transform.position, transform.rotation);
                GameObject.Find("Flash").GetComponent<ParticleSystem>().Play();
                soundManager.LargeAsteroidDestroyed();
                scoreManager.IncrementScore(scoreValue);
                Instantiate(powerUpDrop, powerUpSpawn.position, powerUpSpawn.localRotation);
                Destroy(gameObject);
                Debug.Log("Target Destroyed!");
            }
        }
    }
}


            //if (enemyHitPoints <= 0)
            //{
            //    if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "EnemyShip")
            //    {
            //        Instantiate(onDestroyExplosion, transform.position, transform.rotation);
            //        GameObject.Find("Flash").GetComponent<ParticleSystem>().Play();
            //        soundManager.EnemyShipDestroyed();
            //    }
            //    if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Hazard" || 
            //        gameObject.tag == "HazardHP" || gameObject.tag == "HazardSP")
            //    {
            //        Instantiate(onDestroyExplosion, transform.position, transform.rotation);
            //        GameObject.Find("Flash").GetComponent<ParticleSystem>().Play();
            //        soundManager.LargeAsteroidDestroyed();
            //    }

//Debug.Log("Target Destroyed!");
// Add score value of destroyed enemy to score variable in ScoreManager script and destroy player projectile and enemy/hazard
//scoreManager.IncrementScore(scoreValue);
//Destroy(other.gameObject);
//    if (gameObject.tag == "HazardHP" || gameObject.tag == "HazardSP")
//    {
//        // Spawn power-up drops at enemies last position upon destruction
//        Instantiate(powerUpDrop, powerUpSpawn.position, powerUpSpawn.localRotation);
//    }
//    //Destroy(gameObject);
//}
//else if (other.gameObject.tag == "Player" && enemyHitPoints <= 1)
//{
//    Debug.Log("Head On Collision!");
//    Instantiate(onDestroyExplosion, transform.position, transform.rotation);
//    GameObject.Find("Flash").GetComponent<ParticleSystem>().Play();
//    if (damageMultiplier != null)
//    {
//        enemyHitPoints -= damageMultiplier.damageValueMultiplier;
//    }
//    Destroy(gameObject);
//}
//}

// Enemy friendly fire check
//if (other.gameObject.tag == "EnemyProjectile")
//{
//    Debug.Log("Collateral Damage!");
//    Destroy(other.gameObject);
//    enemyHitPoints -= collateralDamage;

//    if (other.gameObject.tag == "EnemyProjectile")
//    {
//        soundManager.EnemyShipEngaged();
//    }
//    if (other.gameObject.tag == "EnemyProjectile" && gameObject.tag == "Hazard" || gameObject.tag == "HazardHP" || gameObject.tag == "HazardSP")
//    {
//        soundManager.LargeAsteroidHit();
//    }

//    if (enemyHitPoints <= 0)
//    {
//        if (other.gameObject.tag == "EnemyProjectile")
//        {
//            Instantiate(onDestroyExplosion, transform.position, transform.rotation);
//            GameObject.Find("Flash").GetComponent<ParticleSystem>().Play();
//            soundManager.EnemyShipDestroyed();
//        }
//        if (other.gameObject.tag == "EnemyProjectile" && gameObject.tag == "HazardHP" || gameObject.tag == "HazardSP" || gameObject.tag == "Hazard")
//        {
//            Instantiate(onDestroyExplosion, transform.position, transform.rotation);
//            GameObject.Find("Flash").GetComponent<ParticleSystem>().Play();
//            soundManager.LargeAsteroidDestroyed();
//        }

//        Debug.Log("Object Destroyed!");
//        Destroy(gameObject);
//    }
//}
//}
//}
