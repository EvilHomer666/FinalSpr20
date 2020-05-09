using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField] float speedBoostValue;
    [SerializeField] float powerUpLocalSpeed;
    [SerializeField] int scoreValue;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private PlayerController playerControllerSpeedBoost;
    private DetectPlayerCollisions playerCollisions;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to GameManager script - NOTE TO SELF: REMEMBER HOW TO DO THIS USING GameObject WHEN 
        // LOOKING IN SCRIPTS BUT NOT IN THE SAME GAME OBJECT!!!!
        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();

        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        playerControllerSpeedBoost = FindObjectOfType<PlayerController>();

        playerCollisions = FindObjectOfType<DetectPlayerCollisions>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move power-up to the left
        transform.Translate(Vector3.left * Time.deltaTime * powerUpLocalSpeed);
    }

    // On trigger enter function over-ride - Destroy power up on collision player NOTE TO SELF: None of this will work without colliders set to trigger - must revise, it's buggy.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playerControllerSpeedBoost.playerSpeed < playerControllerSpeedBoost.playerSpeedCap)
        {
            playerControllerSpeedBoost.UpdatePlayerSpeed(speedBoostValue);
            soundManager.PlayerSpeedBoost();
            scoreManager.IncrementScore(scoreValue);
            Destroy(gameObject);
            Debug.Log("Speed Up!");
        }

        else if (other.gameObject.tag == "Player" && playerControllerSpeedBoost.playerSpeed == playerControllerSpeedBoost.playerSpeedCap ||
            playerCollisions.playerCurrentHitPoints == playerCollisions.enginesLv1)
        {
            soundManager.PlayerCollectedPowerUp();
            scoreManager.IncrementScore(scoreValue);
            Destroy(gameObject);
            Debug.Log("Pick Up!");
        }
    }
}
