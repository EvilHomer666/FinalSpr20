using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField] float speedBoostValue;
    [SerializeField] float powerUpLocalSpeed;
    [SerializeField] int scoreValue;
    private int speedDemonBonus = 5;
    private SpeedBar speedBar;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private PlayerController playerController;
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

        speedBar = FindObjectOfType<SpeedBar>();

        playerController = FindObjectOfType<PlayerController>();

        playerCollisions = FindObjectOfType<DetectPlayerCollisions>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move power-up to the left
        transform.Translate(Vector3.left * Time.deltaTime * powerUpLocalSpeed);
    }

    // On trigger enter function over-ride - Destroy power up on collision player 
    // NOTE TO SELF: None of this will work without colliders set to trigger and rigid bodies attached - must revise, it's buggy.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playerController.playerSpeed < playerController.playerSpeedCap)
        {
            playerController.UpdatePlayerSpeed(speedBoostValue);
            speedBar.updateSpeedBar();
            soundManager.PlayerSpeedBoost();
            scoreManager.IncrementScore(scoreValue);
            Destroy(gameObject);
            Debug.Log("Speed Up!");
        }

        else if (other.gameObject.tag == "Player" && playerController.playerSpeed == playerController.playerSpeedCap)
        {
            soundManager.PlayerCollectedPowerUp();
            scoreManager.IncrementScore(scoreValue * speedDemonBonus);
            Destroy(gameObject);
            Debug.Log("Pick Up!");
        }
    }
}
