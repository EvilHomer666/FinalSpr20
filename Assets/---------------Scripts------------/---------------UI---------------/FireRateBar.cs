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
    private PlayerWeaponsController playerWeaponsController;
    private SoundManager soundManager;
    private float laserLvCap = 3.0f;
    public float laserLv;
    // Weapon Level power ups have a 0.05 boost that is subtracted from the players fire rate. 
    // The lower the fire rate, the faster the player will fire.
    public int numberOfLaserLevels = 3; // Total number of laser levels - not counting default

    // Start is called before the first frame update
    void Start()
    {
        playerWeaponsController = GetComponent<PlayerWeaponsController>();
        soundManager = GetComponent<SoundManager>();
        laserLv = 0;
    }

    void Update()
    {
        // Update laser level in the UI
        updateLaserLvBar();
    }

    // Method to update the laser bar UI, NOT the player's laser fire rate
    public void updateLaserLvBar()
    {
        if (laserLv == 0)
        {
            fireRateLv0.SetActive(true);
            fireRateLv1.SetActive(false);
            fireRateLv2.SetActive(false);
            fireRateLv3.SetActive(false);
        }
        if (laserLv == 1)
        {
            fireRateLv0.SetActive(false);
            fireRateLv1.SetActive(true);
            fireRateLv2.SetActive(false);
            fireRateLv3.SetActive(false);
        }
        if (laserLv == 2)
        {
            fireRateLv0.SetActive(false);
            fireRateLv1.SetActive(false);
            fireRateLv2.SetActive(true);
            fireRateLv3.SetActive(false);
        }
        if (laserLv == 3)
        {
            fireRateLv0.SetActive(false);
            fireRateLv1.SetActive(false);
            fireRateLv2.SetActive(false);
            fireRateLv3.SetActive(true);
        }
        if(laserLv > 3)
        {
            laserLv = laserLvCap;
        }
    }
}
