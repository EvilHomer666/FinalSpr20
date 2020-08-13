using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] int scoreValue;
    [SerializeField] float enemyHitPoints;
    [SerializeField] bool holdsPowerUp;
    [SerializeField] Transform powerUpSpawn;
    [SerializeField] GameObject onDestroyExplosion;
    [SerializeField] GameObject impactExplosion;
    private ProjectileImpact damageMultiplier;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private TutorialManager tutorialCheck;
    private Scene activeScene;
    private float minimumDamage = 1f;
    private float collateralDamage = 0.5f;
    private string sceneName;
    public float damageValue;

    // Spawn manager array for power up prefabs
    public GameObject[] powerUpPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to GameManager script
        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();

        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        tutorialCheck = FindObjectOfType<TutorialManager>();

        damageMultiplier = FindObjectOfType<ProjectileImpact>();
        activeScene = SceneManager.GetActiveScene();

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

            if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Hazard" || gameObject.tag == "HazardHP" || gameObject.tag == "HazardSP")
            {
                soundManager.LargeAsteroidHit();                    
            }

            if (enemyHitPoints <= 0)
            {
                Instantiate(onDestroyExplosion, transform.position, transform.rotation);
                GameObject.Find("Flash").GetComponent<ParticleSystem>().Play();
                if (gameObject.tag == "EnemyShip")
                {
                    soundManager.EnemyShipDestroyed();
                }
                if (gameObject.tag == "Hazard" || gameObject.tag == "HazardHP" || gameObject.tag == "HazardSP")
                {
                    soundManager.LargeAsteroidDestroyed();
                }
                if (holdsPowerUp == true)
                {
                    TutorialModeCheck();
                    int powerUpIndex = Random.Range(0, powerUpPrefabs.Length);
                    Instantiate(powerUpPrefabs[powerUpIndex], powerUpSpawn.position, powerUpPrefabs[powerUpIndex].transform.rotation);

                }
                scoreManager.IncrementScore(scoreValue);
                Destroy(gameObject);
                Debug.Log("Target Destroyed!");
            }
        }
        


        // Enemy friendly fire
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
                Destroy(gameObject);
                Debug.Log("Enemy Destroyed!");
            }
        }
    }
    // Tutorial scene check
    private void TutorialModeCheck()
    {
        sceneName = activeScene.name;
        if (sceneName == "Lev00")
        {
            tutorialCheck.wasEnemyEngaged = true;
        }
    }
}

