using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireRateBar : MonoBehaviour
{
    [SerializeField] GameObject fireRateLv0;
    [SerializeField] GameObject fireRateLv1;
    [SerializeField] GameObject fireRateLv2;
    [SerializeField] GameObject fireRateLv3;
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
        updateLaserLvBar();
    }

    // Method to update the laser bar UI, NOT the player's laser fire rate
    public void updateLaserLvBar()
    {
        if (playerWeaponsController.cooldownTime <= 0.2f && playerWeaponsController.cooldownTime > 0.15f)
        {
            fireRateLv0.SetActive(true);
            fireRateLv1.SetActive(false);
            fireRateLv2.SetActive(false);
            fireRateLv3.SetActive(false);
        }
        if (playerWeaponsController.cooldownTime <= 0.15f && playerWeaponsController.cooldownTime > 0.1f)
        {
            fireRateLv0.SetActive(false);
            fireRateLv1.SetActive(true);
            fireRateLv2.SetActive(false);
            fireRateLv3.SetActive(false);
        }
        if (playerWeaponsController.cooldownTime <= 0.1f && playerWeaponsController.cooldownTime > 0.075f)
        {
            fireRateLv0.SetActive(false);
            fireRateLv1.SetActive(false);
            fireRateLv2.SetActive(true);
            fireRateLv3.SetActive(false);
        }
        if (playerWeaponsController.cooldownTime <= 0.075f && playerWeaponsController.cooldownTime > 0.99f)
        {
            fireRateLv0.SetActive(false);
            fireRateLv1.SetActive(false);
            fireRateLv2.SetActive(false);
            fireRateLv3.SetActive(true);
        }
    }
}
