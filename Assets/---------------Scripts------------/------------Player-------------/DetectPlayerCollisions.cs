﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DetectPlayerCollisions : MonoBehaviour
{
    [SerializeField] GameObject playerExplosion;
    [SerializeField] int directCollisionDamageValue = 10;
    [SerializeField] int enemyProjectileCollisionDamageValue = 2;
    private int enginesLv2 = 2;
    private int enginesLv3 = 3;
    private int enginesLv4 = 4;
    private GameManager gameManager;
    private SoundManager soundManager;
    private PlayerController playerController;
    private ShieldAnimation shieldAnimation;
    private PlayerShieldCanvas shieldCanvas;
    private DetectCollisions enemyDamage;
    private SpeedBar speedBar;
    private Scene activeScene;
    private string sceneName;
    //private int tutorialHealthHandiCap = 9;
    private float lowShieldThreshold = 1.5f;
    public int enginesLv1 = 1;
    public int playerMaxHitPoints;
    public float playerCurrentHitPoints;
    public LifeBar lifeBar;

    // private PlayerController polarityModifierSwitch; // << TO DO to be implemented with player's ability to use enemy fire against them

    // Start is called before the first frame update
    void Start()
    {
        // Initialize references
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        enemyDamage = GetComponent<DetectCollisions>();
        lifeBar = FindObjectOfType<LifeBar>();
        playerController = FindObjectOfType<PlayerController>();
        speedBar = FindObjectOfType<SpeedBar>();
        activeScene = SceneManager.GetActiveScene();
        shieldCanvas = FindObjectOfType<PlayerShieldCanvas>();
        shieldAnimation = FindObjectOfType<ShieldAnimation>();
        // Initialize Life-Hit points and check for tutorial mode
        playerCurrentHitPoints = playerMaxHitPoints;
        lifeBar.SetMaxLife(playerCurrentHitPoints);
        //TutorialModeCheck();
        StartCoroutine(RegenerateHP());

        // polarityModifierSwitch = FindObjectOfType<PlayerController>(); // << TO DO to be implemented with player's ability to use return enemy fire
    }

    // Update is called once per frame
    void Update()
    {

        // Speed reset at 80% damage
        if (playerCurrentHitPoints <= 2)
        {
            playerController.playerSpeed = playerController.speedReset;
        }

        // Player Game Over check
        if (playerCurrentHitPoints <= -1)
        {
            // Instantiate VFX on player death - second line plays sub-particle element in parent
            Instantiate(playerExplosion, transform.position, transform.rotation);
            GameObject.Find("ParticleBurst").GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            gameManager.GameOver();
        }    
    }

    // On trigger enter function to detect collisions with enemy/hazard and take damage
    private void OnTriggerEnter(Collider other)
    {
        // Enemies and hazard check to apply damage to player
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Hazard")
        {
            Debug.Log("Collision!");
            shieldAnimation.shieldHit = true;
            playerCurrentHitPoints -= directCollisionDamageValue;
            shieldAnimation.PlayShieldAnimation();
            lifeBar.SetLife(playerCurrentHitPoints);            
            Destroy(other.gameObject);
            soundManager.PlayerShieldDamage();
        }

        // EnemyProjectile check to apply damage to player
        if (other.gameObject.tag == "EnemyProjectile")
        {
            Debug.Log("Collision!");
            shieldAnimation.shieldHit = true;
            playerCurrentHitPoints -= enemyProjectileCollisionDamageValue;
            shieldAnimation.PlayShieldAnimation();
            lifeBar.SetLife(playerCurrentHitPoints);
            //Destroy(other.gameObject);
            soundManager.PlayerShieldDamage();
        }

        if (playerCurrentHitPoints <= lowShieldThreshold)
        {
            soundManager.PlayerDangerWarning();
        }

        // Check to never let player have more than allowed hit points 
        if (playerCurrentHitPoints > playerMaxHitPoints)
        {
            playerCurrentHitPoints = playerMaxHitPoints;
        }
    }

    // Health regeneration over time
    IEnumerator RegenerateHP()
    {
        while (true)
        {
            if (playerCurrentHitPoints < playerMaxHitPoints && gameManager.gameOver != true)
            {
                shieldCanvas.displayUI = true;
                playerCurrentHitPoints += 0.10f;
                lifeBar.SetLife(playerCurrentHitPoints);
                yield return new WaitForSeconds(0.25f);
            }
            else
            {
                shieldCanvas.displayUI = false;
                yield return null;
            }
        }
    }

    // Tutorial scene check
    //private void TutorialModeCheck()
    //{
    //    sceneName = activeScene.name;
    //    if (sceneName == "Lev00")
    //    {
    //        playerCurrentHitPoints -= tutorialHealthHandiCap;
    //        lifeBar.SetLife(playerCurrentHitPoints);
    //    }
    //}
}

