using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DetectPlayerCollisions : MonoBehaviour
{
    [SerializeField] GameObject playerExplosion;
    private float damageValue = 1;
    private GameManager gameManager;
    private SoundManager soundManager;
    private PlayerController playerControllerSpeedReset;
    private PlayerShieldCanvas shieldCanvas;
    private ShieldActivity shieldDamage;
    private SpeedPowerUp speedPowerUp;
    private Scene activeScene;
    private string sceneName;
    private int playerSpeedLevel;
    public float enginesLv1 = 1;
    public float playerMaxHitPoints;
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
        lifeBar = FindObjectOfType<LifeBar>();
        playerControllerSpeedReset = FindObjectOfType<PlayerController>();
        speedPowerUp = FindObjectOfType<SpeedPowerUp>();
        activeScene = SceneManager.GetActiveScene();
        shieldCanvas = FindObjectOfType<PlayerShieldCanvas>();
        shieldDamage = FindObjectOfType<ShieldActivity>();

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
        // Particle system/engine health & speed mechanic
        while(gameManager.gameOver != true)
        {
            if (playerCurrentHitPoints <= 10.0f)
            {
                playerControllerSpeedReset.playerSpeed = playerControllerSpeedReset.speedReset;
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
            break;
        }       
    }

    // On trigger enter function to detect collisions with enemy/hazard and take damage
    private void OnTriggerEnter(Collider other)
    {
        // Enemies and hazard damage check
        if (other.gameObject.tag == "EnemyShip" || other.gameObject.tag == "EnemyProjectile" || 
            other.gameObject.tag == "Hazard" || other.gameObject.tag == "HazardSP" || other.gameObject.tag == "HazardHP")
        {
            Debug.Log("Collision!");
            shieldDamage.shieldIsActive = true;
            playerCurrentHitPoints -= damageValue;
            lifeBar.SetLife(playerCurrentHitPoints);
            shieldCanvas.shieldUpdate();
            Destroy(other.gameObject);
            soundManager.PlayerShieldDamage();

            if (playerCurrentHitPoints <= damageValue)
            {
                soundManager.PlayerDangerWarning();
            }
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
            if (playerCurrentHitPoints < 10)
            {
                playerCurrentHitPoints += 0.10f;
                lifeBar.SetLife(playerCurrentHitPoints);
                yield return new WaitForSeconds(0.25f);
            }
            else
            {
                yield return null;
            }
        }
    }
}

