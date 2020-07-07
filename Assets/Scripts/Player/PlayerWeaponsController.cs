using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponsController : MonoBehaviour
{
    [SerializeField] GameObject playerProjectileLv1;
    [SerializeField] GameObject playerProjectileLv2;
    [SerializeField] float cooldownTime;
    private Rigidbody rigidBody;
    private bool canFire;
    private SoundManager soundManager;
    // Cannon arrays
    public Transform[] cannonsFront;
    public Transform[] cannonsLateral;
    
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
        // Projectile launch condition with for each element to read array - Front cannons 
        if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach (var projectile in cannonsFront)
            {
                Instantiate(playerProjectileLv1, projectile.position, projectile.rotation);
            }
            soundManager.PlayerFireLaserLv1();
        }

        // Projectile launch condition with for each element to read array - Lateral cannons 
        if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach (var projectile in cannonsLateral)
            {
                Instantiate(playerProjectileLv2, projectile.position, projectile.rotation);
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
