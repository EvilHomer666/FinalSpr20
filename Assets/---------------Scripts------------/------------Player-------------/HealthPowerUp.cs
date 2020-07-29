using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPowerUp : MonoBehaviour
{
    [SerializeField] int healthValue;
    [SerializeField] float powerUpLocalSpeed;
    [SerializeField] int scoreValue;
    private PlayerShieldCanvas shieldCanvas;
    private int survivorBonus = 7;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private DetectPlayerCollisions playerCollisions;
    private LifeBar lifeBar;
    private Renderer lineRenderer;

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
        shieldCanvas = FindObjectOfType<PlayerShieldCanvas>();
        lifeBar = FindObjectOfType<LifeBar>();
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
        if (other.gameObject.tag == "Player" && playerCollisions.playerCurrentHitPoints < playerCollisions.playerMaxHitPoints)
        {
            playerCollisions.playerCurrentHitPoints += healthValue;
            lifeBar.SetLife(playerCollisions.playerCurrentHitPoints);
            shieldCanvas.shieldUpdate();
            soundManager.PlayerShieldUp();
            scoreManager.IncrementScore(scoreValue);
            Destroy(gameObject);
            Debug.Log("Power Up!");
        }

        if (other.gameObject.tag == "Player" && playerCollisions.playerCurrentHitPoints == playerCollisions.playerMaxHitPoints)
        {
            soundManager.PlayerCollectedPowerUp();
            scoreManager.IncrementScore(scoreValue * survivorBonus);
            shieldCanvas.shieldUpdate();
            Destroy(gameObject);
            Debug.Log("Pick Up!");
        }
    }
}
