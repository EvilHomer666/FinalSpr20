using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireRateBar : MonoBehaviour
{
    //[SerializeField] Image[] lasers;
    //[SerializeField] Sprite currentLaserLevel;
    //[SerializeField] Sprite emptyLaserLevel;
    [SerializeField] Image fireRateLv0;
    [SerializeField] Image fireRateLv1;
    [SerializeField] Image fireRateLv2;
    [SerializeField] Image fireRateLv3;
    private Color activeLaser;
    private PlayerWeaponsController playerWeaponsController;
    private SoundManager soundManager;

    // Weapon Level power ups have a 0.05 boost that is subtracted from the players fire rate. 
    // The lower the fire rate, the faster the player will shot.
    public int numberOfLaserLevels = 3; // Total number of laser levels - not counting default

    // Start is called before the first frame update
    void Start()
    {
        playerWeaponsController = GetComponent<PlayerWeaponsController>();
        soundManager = GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        updateLaserLvBar();
    }

    // Method to update the laser bar UI, NOT the player's laser fire rate
    public void updateLaserLvBar()
    {
        if (playerWeaponsController.cooldownTime == 0.2f)
        {
            fireRateLv0.color = new Color(206, 207, 231, 250);
            fireRateLv1.color = new Color(206, 207, 231, 100);
            fireRateLv2.color = new Color(206, 207, 231, 100);
            fireRateLv3.color = new Color(206, 207, 231, 100);
        }
        if (playerWeaponsController.cooldownTime == 0.15f)
        {
            fireRateLv0.color = new Color(206, 207, 231, 100);
            fireRateLv1.color = new Color(206, 207, 231, 250);
            fireRateLv2.color = new Color(206, 207, 231, 100);
            fireRateLv3.color = new Color(206, 207, 231, 100);
        }
        if (playerWeaponsController.cooldownTime == 0.1f)
        {
            fireRateLv0.color = new Color(206, 207, 231, 100);
            fireRateLv1.color = new Color(206, 207, 231, 100);
            fireRateLv2.color = new Color(206, 207, 231, 250);
            fireRateLv3.color = new Color(206, 207, 231, 100);
        }
        if (playerWeaponsController.cooldownTime == 0.075f)
        {
            fireRateLv0.color = new Color(206, 207, 231, 100);
            fireRateLv1.color = new Color(206, 207, 231, 100);
            fireRateLv2.color = new Color(206, 207, 231, 100);
            fireRateLv3.color = new Color(206, 207, 231, 250);
        }
    }
}
