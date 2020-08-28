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
    [SerializeField] GameObject powerUpDrop;
    [SerializeField] GameObject onDestroyExplosion;
    [SerializeField] GameObject impactExplosion;
    private PlayerProjectile damageMultiplier;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private TutorialManager tutorialCheck;
    private Scene activeScene;
    private float minimumDamage = 1f;
    private string sceneName;
    private bool thereCanBeOnlyOne;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to GameManager script
        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();

        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        tutorialCheck = FindObjectOfType<TutorialManager>();

        damageMultiplier = FindObjectOfType<PlayerProjectile>();

        activeScene = SceneManager.GetActiveScene();

        thereCanBeOnlyOne = true;

    }

    // On trigger enter function over-ride - Destroy target and projectile on collision
    private void OnTriggerEnter(Collider other)
    {
        // Player fire check to apply damage to enemy object
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

            if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Enemy")
            {
                soundManager.EnemyShipEngaged();
            }

            if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Hazard")
            {
                soundManager.MineHit();
            }

            if (enemyHitPoints <= 0)
            {
                if (holdsPowerUp == true && thereCanBeOnlyOne == true)
                {
                    Instantiate(powerUpDrop, powerUpSpawn.position, powerUpSpawn.localRotation);
                    thereCanBeOnlyOne = false;
                }
                if (gameObject.tag == "Enemy")
                {
                    soundManager.EnemyShipDestroyed();
                }
                if (gameObject.tag == "Hazard")
                {
                    soundManager.MineDestroyed();
                }
                Instantiate(onDestroyExplosion, transform.position, transform.rotation);
                GameObject.Find("Flash").GetComponent<ParticleSystem>().Play();
                scoreManager.IncrementScore(scoreValue);
                Destroy(gameObject);
                Debug.Log("Target Destroyed!");
            }
        }

        //// Player collision check
        //if (other.gameObject.tag == "Player")
        //{
        //    Debug.Log("Collision!");
        //    if (damageMultiplier != null)
        //    {
        //        enemyHitPoints -= damageMultiplier.damageValueMultiplier;
        //    }
        //    else
        //    {
        //        enemyHitPoints -= minimumDamage;
        //    }

        //    if (other.gameObject.tag == "Player" && gameObject.tag == "Enemy")
        //    {
        //        soundManager.PlayerShieldDamage();
        //    }

        //    if (other.gameObject.tag == "Player" && gameObject.tag == "Hazard")
        //    {
        //        soundManager.PlayerShieldDamage();
        //    }

        //    if (enemyHitPoints <= 0)
        //    {
        //        if (gameObject.tag == "Enemy")
        //        {
        //            soundManager.EnemyShipDestroyed();
        //        }
        //        if (gameObject.tag == "Hazard")
        //        {
        //            soundManager.MineDestroyed();
        //        }
        //        Instantiate(onDestroyExplosion, transform.position, transform.rotation);
        //        GameObject.Find("Flash").GetComponent<ParticleSystem>().Play();
        //        Destroy(gameObject);
        //        Debug.Log("Collision Damage!");
        //    }
        //}
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

