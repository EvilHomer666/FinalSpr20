using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponsController : MonoBehaviour
{
    [SerializeField] GameObject playerProjectileLv1;
    [SerializeField] GameObject playerProjectileLv2;
    private SoundManager soundManager;
    private FireRateBar fireRate;
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
        fireRate = FindObjectOfType<FireRateBar>();
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
        if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            foreach (var projectile in cannonsLv0)
            {
                Instantiate(playerProjectileLv1, projectile.position, projectile.rotation);
            }
            soundManager.PlayerFireLaserLv1();
        }

        // POW fire condition
        //if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        //{

        //    foreach (var projectile in cannonsLv1)
        //    {
        //        Instantiate(playerProjectileLv1, projectile.position, projectile.rotation);
        //    }
        //    soundManager.PlayerFireLaserLv1();
        //}
    }

    // Update player's rate of fire
    public void UpdatePlayerRateOfFire(float rateOfFireBoost)
    {
        cooldownTime -= rateOfFireBoost;
        fireRate.updateLaserLvBar();
    }
}

