using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DetectPlayerCollisions : MonoBehaviour
{
    [SerializeField] GameObject playerExplosion;
    private int enginesLv2 = 2;
    private int enginesLv3 = 3;
    private int enginesLv4 = 4;
    private int damageValue = 1;
    private GameManager gameManager;
    private SoundManager soundManager;
    private PlayerController playerController;
    private ShieldAnimation shieldAnimation;
    private PlayerShieldCanvas shieldCanvas;
    private SpeedBar speedBar;
    private Scene activeScene;
    private string sceneName;
    //private int tutorialHealthHandiCap = 9;
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

        // Speed reset at 90% damage
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
        // Enemies and hazard damage check
        if (other.gameObject.tag == "EnemyShip" || other.gameObject.tag == "EnemyProjectile" || 
            other.gameObject.tag == "Hazard" || other.gameObject.tag == "HazardSP" || other.gameObject.tag == "HazardHP")
        {
            Debug.Log("Collision!");
            shieldAnimation.shieldHit = true;
            playerCurrentHitPoints -= damageValue;
            shieldAnimation.PlayShieldAnimation();
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
            if (playerCurrentHitPoints < playerMaxHitPoints || gameManager.gameOver != true)
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

