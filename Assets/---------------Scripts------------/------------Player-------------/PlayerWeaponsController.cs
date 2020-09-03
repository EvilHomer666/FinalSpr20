using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponsController : MonoBehaviour
{
    [SerializeField] GameObject playerProjectileLv0;
    [SerializeField] GameObject playerProjectileLv1;
    [SerializeField] GameObject playerProjectileLv2;
    [SerializeField] GameObject playerProjectileLv3;
    private FireRateBar fireRateBar;
    private SoundManager soundManager;
    private bool canFire;
    public float playerFireRateCap;
    public float cooldownTime; // Controls the rate of fire => the smaller, the faster >> Default is 0.2f

    // Cannon arrays - contain game object from where to instantiate the different laser type levels
    public Transform[] cannonsLv0; 
    public Transform[] cannonsLv1;
    public Transform[] cannonsLv2;
    public Transform[] cannonsLv3;

    // public bool polarityModifier; // << TO DO Add player ability to use enemy fire 


    // Start is called before the first frame update
    void Start()
    {
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        fireRateBar = GetComponent<FireRateBar>();

        canFire = true;

        //  polarityModifier = false; // << TO DO Add player ability to use enemy fire against them
    }

    private void Update()
    {
        // Check to never let player have more than allowed fire rate
        if (cooldownTime < playerFireRateCap)
        {
            cooldownTime = playerFireRateCap;
        }
    }

    public void ProjectileLaunchCondition()
    {
        if (canFire == true)
        {
            StartCoroutine(Fire());
        }
    }

    // Fire rate condition
    IEnumerator Fire()
    {
        FireCondition();
        canFire = false;
        yield return new WaitForSeconds(cooldownTime);
        canFire = true;
    }

    private void FireCondition()
    {
        //Projectile launch condition with for each element to read array - Lv 00 - Twin laser default
        if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space))
        {
            if(fireRateBar.laserLv == 0)
            {
                foreach (var projectile in cannonsLv0)
                {
                    Instantiate(playerProjectileLv0, projectile.position, projectile.rotation);
                }
            }
            if (fireRateBar.laserLv == 1)
            {
                foreach (var projectile in cannonsLv0)
                {
                    Instantiate(playerProjectileLv0, projectile.position, projectile.rotation);
                }

                foreach (var projectile in cannonsLv1)
                {
                    Instantiate(playerProjectileLv1, projectile.position, projectile.rotation);
                }
            }
            if (fireRateBar.laserLv == 2)
            {
                foreach (var projectile in cannonsLv0)
                {
                    Instantiate(playerProjectileLv0, projectile.position, projectile.rotation);
                }

                foreach (var projectile in cannonsLv1)
                {
                    Instantiate(playerProjectileLv1, projectile.position, projectile.rotation);
                }

                foreach (var projectile in cannonsLv2)
                {
                    Instantiate(playerProjectileLv2, projectile.position, projectile.rotation);
                }
            }
            if (fireRateBar.laserLv == 3)
            {
                foreach (var projectile in cannonsLv0)
                {
                    Instantiate(playerProjectileLv0, projectile.position, projectile.rotation);
                }

                foreach (var projectile in cannonsLv1)
                {
                    Instantiate(playerProjectileLv1, projectile.position, projectile.rotation);
                }

                foreach (var projectile in cannonsLv2)
                {
                    Instantiate(playerProjectileLv2, projectile.position, projectile.rotation);
                }

                foreach (var projectile in cannonsLv3)
                {
                    Instantiate(playerProjectileLv3, projectile.position, projectile.rotation);
                }
            }
            soundManager.PlayerFireLaserLv1();
        }
    }

    // Update player's weapons rate of fire
    public void UpdatePlayerRateOfFire(float rateOfFireBoost)
    {
        cooldownTime -= rateOfFireBoost;
    }
}

