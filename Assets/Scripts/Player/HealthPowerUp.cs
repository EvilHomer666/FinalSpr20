using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    [SerializeField] int healthValue;
    [SerializeField] float powerUpLocalSpeed;
    [SerializeField] int scoreValue;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private DetectPlayerCollisions playerCollisions;
    public LifeBar lifeBar;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to GameManager script - NOTE TO SELF: REMEMBER HOW TO DO THIS USING GameObject WHEN 
        // LOOKING IN SCRIPTS BUT NOT IN THE SAME GAME OBJECT!!!!
        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();

        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        playerCollisions = FindObjectOfType<DetectPlayerCollisions>();

        lifeBar = FindObjectOfType<LifeBar>();
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
        if (other.gameObject.tag == "Player" && playerCollisions.playerCurrentHitPoints < playerCollisions.playerMaxHitPoints)
        {
            playerCollisions.playerCurrentHitPoints += healthValue;
            lifeBar.SetLife(playerCollisions.playerCurrentHitPoints);
            soundManager.PlayerShieldUp();
            scoreManager.IncrementScore(scoreValue);
            Destroy(gameObject);
            Debug.Log("Power Up!");
        }

        if (other.gameObject.tag == "Player" && playerCollisions.playerCurrentHitPoints == playerCollisions.playerMaxHitPoints)
        {
            soundManager.PlayerCollectedPowerUp();
            scoreManager.IncrementScore(scoreValue);
            Destroy(gameObject);
            Debug.Log("Pick Up!");
        }
    }
}
