using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    [SerializeField] GameObject shieldBreak;
    private int damageValue = 1;
    private GameManager gameManager;
    private SoundManager soundManager;
    private int tutorialHandiCap = 2;
    public int shieldMaxHitPoints;
    public int shieldCurrentHitPoints;
    public ShieldBar shieldBar;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize references
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        shieldBar = FindObjectOfType<ShieldBar>();

        // Initialize Life-Hit points and check for tutorial mode
        shieldCurrentHitPoints = shieldMaxHitPoints;
        shieldBar.SetMaxShield(shieldCurrentHitPoints);
    }

    // Update is called once per frame
    void Update()
    {
        // Shield down check
        if (shieldCurrentHitPoints <= 0)
        {
            // Instantiate VFX on shield down - second line of code below plays sub-particle element in parent
            Instantiate(shieldBreak, transform.position, transform.rotation);
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
            shieldCurrentHitPoints -= damageValue;
            shieldBar.SetLife(shieldCurrentHitPoints);
            Destroy(other.gameObject);
            soundManager.PlayerShieldDamage();

            if (shieldCurrentHitPoints <= damageValue)
            {
                soundManager.PlayerDangerWarning();
            }
        }

        // Check to never let player have more than allowed hit points 
        if (shieldCurrentHitPoints > shieldMaxHitPoints)
        {
            shieldCurrentHitPoints = shieldMaxHitPoints;
        }
    }
}
