using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireRatePowerUp : MonoBehaviour
{
    [SerializeField] float fireRateValue; // Value to adjust fire rate
    [SerializeField] float powerUpLocalSpeed;
    [SerializeField] int scoreValue;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private DetectPlayerCollisions playerCollisions;
    private PlayerWeaponsController playerWeapons;
    private FireRateBar fireRateBar;
    private Renderer lineRenderer;
    private float laserLvValue = 1.0f; // Value to show laserLv on the laser UI
    private int gatlingDemonBonus = 7;


    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        playerCollisions = FindObjectOfType<DetectPlayerCollisions>();
        playerWeapons = FindObjectOfType<PlayerWeaponsController>();
        fireRateBar = FindObjectOfType<FireRateBar>();
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
            fireRateBar.laserLv += laserLvValue;
            soundManager.PlayerShieldUp(); // TO DO update to laser upgrade sound
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