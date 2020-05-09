using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] GameObject impactExplosion;

    // Projectile speed
    public float speedLv01 = 40;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speedLv01);
    }

    // On trigger enter function over-ride - Play impact FX when enemy is hit
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("EnemyShip") || other.CompareTag ("Hazard") || other.CompareTag ("HazardHP") || other.CompareTag ("HazardSP"))
        {
            ImpactExplosion();
        }
    }

    private void ImpactExplosion()
    {
        //Instantiate(impactExplosion, impactSpawn.position, impactSpawn.rotation);
        Instantiate(impactExplosion, transform.position, transform.rotation);
    }
}
