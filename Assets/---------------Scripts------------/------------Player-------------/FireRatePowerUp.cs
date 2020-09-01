using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireRatePowerUp : MonoBehaviour
{
    [SerializeField] float fireRateValue;
    [SerializeField] float powerUpLocalSpeed;
    [SerializeField] int scoreValue;
    private int gatlingDemonBonus = 7;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private DetectPlayerCollisions playerCollisions;
    private PlayerWeaponsController playerWeapons;
    private FireRateBar weaponLvBar;
    private Renderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        playerCollisions = FindObjectOfType<DetectPlayerCollisions>();
        playerWeapons = FindObjectOfType<PlayerWeaponsController>();
        //lifeBar = FindObjectOfType<LifeBar>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move power-up to the left
        transform.Translate(Vector3.left * Time.deltaTime * powerUpLocalSpeed);
    }

    // On trigger enter function over-ride - Destroy power up on collision player NOTE TO SELF: None of this will work without colliders set to trigger and rigid bodies.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playerWeapons.cooldownTime > playerWeapons.playerFireRateCap)
        {
            playerWeapons.UpdatePlayerRateOfFire(fireRateValue);
            soundManager.PlayerShieldUp(); // TO DO update to burst engine sound (3 levels using if statements and checking speed bar state)
            scoreManager.IncrementScore(scoreValue);
            Destroy(gameObject);
            Debug.Log("Weapon Upgrade!");
        }

        if (other.gameObject.tag == "Player" && playerWeapons.cooldownTime == playerWeapons.playerFireRateCap)
        {
            soundManager.PlayerCollectedPowerUp();
            scoreManager.IncrementScore(scoreValue * gatlingDemonBonus);
            Destroy(gameObject);
            Debug.Log("Pick Up!");
        }
    }
}