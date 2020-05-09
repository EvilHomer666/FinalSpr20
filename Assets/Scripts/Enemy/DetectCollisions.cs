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
    private ProjectileImpact damageMultiplier;
    private ScoreManager scoreManager;
    private SoundManager soundManager;

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
        if (other.gameObject.tag == "PlayerProjectile")
        {
            Debug.Log("Target Hit!");
            Destroy(other.gameObject);
            enemyHitPoints -= damageMultiplier.damageValueMultiplier;


            if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "EnemyShip")
            {
                soundManager.EnemyShipEngaged();
            }
            if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Hazard" || gameObject.tag == "HazardHP" || gameObject.tag == "HazardSP")
            {
                soundManager.LargeAsteroidHit();
            }

            if (enemyHitPoints <= 0)
            {
                if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "EnemyShip")
                {
                    soundManager.EnemyShipDestroyed();
                }
                if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Hazard" || gameObject.tag == "HazardHP" || gameObject.tag == "HazardSP")
                {
                    soundManager.LargeAsteroidDestroyed();
                }

                Debug.Log("Target Destroyed!");
                // Add score value of destroyed enemy to score variable in ScoreManager script and destroy player projectile and enemy/hazard
                scoreManager.IncrementScore(scoreValue);
                //Destroy(other.gameObject);
                if (gameObject.tag == "HazardHP" || gameObject.tag == "HazardSP")
                {
                    // Spawn power-up drops at enemies last position upon destruction
                    Instantiate(powerUpDrop, powerUpSpawn.position, powerUpSpawn.localRotation);
                }
                Destroy(gameObject);
            }
        }
    }
}
