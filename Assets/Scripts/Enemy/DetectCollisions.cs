using System.Collections;
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
    [SerializeField] GameObject impactExplosion;
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
            if (enemyHitPoints <= 0)
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
            if (enemyHitPoints <= 0)
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
            if (enemyHitPoints <= 0 && holdsPowerUp == true)
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


        // Enemy friendly
        if (other.gameObject.tag == "EnemyProjectile")
        {
            Debug.Log("Collateral damage!");
            Destroy(other.gameObject);
            if (damageMultiplier != null)
            {
                enemyHitPoints -= damageMultiplier.damageValueMultiplier;
            }
            else
            {
                enemyHitPoints -= minimumDamage;
            }

            if (other.gameObject.tag == "EnemyProjectile" && gameObject.tag == "EnemyShip")
            {
                soundManager.EnemyShipEngaged();
            }
            if (enemyHitPoints <= 0)
            {
                Instantiate(onDestroyExplosion, transform.position, transform.rotation);
                GameObject.Find("Flash").GetComponent<ParticleSystem>().Play();
                soundManager.EnemyShipDestroyed();
                Destroy(gameObject);
                Debug.Log("Enemy Destroyed!");

            }

            if (other.gameObject.tag == "EnemyProjectile" && gameObject.tag == "Hazard" || gameObject.tag == "HazardHP" || gameObject.tag == "HazardSP")
            {
                soundManager.LargeAsteroidHit();
            }
            if (enemyHitPoints <= 0)
            {
                Instantiate(onDestroyExplosion, transform.position, transform.rotation);
                GameObject.Find("Flash").GetComponent<ParticleSystem>().Play();
                soundManager.LargeAsteroidDestroyed();
                scoreManager.IncrementScore(scoreValue);
                Destroy(gameObject);
                Debug.Log("Enemy Destroyed!");
            }
        }
    }
}

