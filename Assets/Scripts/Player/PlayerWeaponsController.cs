using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponsController : MonoBehaviour
{
    [SerializeField] GameObject playerProjectileLv1;
    [SerializeField] GameObject playerProjectileLv2;
    [SerializeField] float cooldownTime;
    private bool canFire;
    private SoundManager soundManager;
    // Cannons array
    public Transform[] cannons;

    // public bool polarityModifier; // << TO DO Add player ability to use enemy fire 

    // Start is called before the first frame update
    void Start()
    {
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        canFire = true;
    //  polarityModifier = false; // << TO DO Add player ability to use enemy fire against them
}

    public void ProjectileLaunchCondition()
    {
        if (canFire == true)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        FireCondition();
        canFire = false;
        yield return new WaitForSeconds(cooldownTime);
        canFire = true;
    }

    private void FireCondition()
    {
        // Projectile launch condition with for each element to read array
        if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach (var projectile in cannons)
            {
                Instantiate(playerProjectileLv1, projectile.position, projectile.rotation);
            }
            soundManager.PlayerFireLaserLv1();
        }
        //if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) && Time.time > 3.0f)
        //{

        //    {
        //        Instantiate(chargeShot, cannonSpawn.position, cannonSpawn.rotation);
        //    }
        //    soundManager.PlayerFireLaserLv1();
        //}
    }
}
