using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeProjectile : MonoBehaviour
{
    [SerializeField] Transform chargeSpawn;
    [SerializeField] GameObject chargeProjectile; // <<
    private float chargeTime = 0;
    private float chargeRate = 2.0f;
    private float fireRate;
    private float nextFire;

    IEnumerator ChargingProjectile()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            // TO Do add charging sound
            yield return new WaitForSeconds(3.0f);
            chargeTime += chargeRate;
        }

        if(Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) && Time.time > 2.0f)
        {
            Instantiate(chargeProjectile, chargeSpawn.transform.position, chargeSpawn.transform.rotation);
            // TO Do add charge shot sound
            chargeTime = 0;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) && Time.time < 2.0f)
        {
            chargeTime = 0;
        }
    }
}
