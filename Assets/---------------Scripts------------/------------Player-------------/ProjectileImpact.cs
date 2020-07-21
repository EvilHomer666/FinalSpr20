using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileImpact : MonoBehaviour
{
    // Projectile properties
    [SerializeField] GameObject impactExplosion;
    [SerializeField] float speedLv01;
    [SerializeField] bool isSpread;
    [SerializeField] bool isHoming;
    public float damageValueMultiplier; // << To be used in enemy detect collisions script to apply damage from projectile

    // Update is called once per frame
    private void Update()
    {
        // Standard laser 
        transform.Translate(Vector3.right * Time.deltaTime * speedLv01);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyShip" || other.gameObject.tag == "Hazard" || 
            other.gameObject.tag == "HazardHP" || other.gameObject.tag == "HazardSP")
        {
            ImpactHit();
        }
    }
    private void ImpactHit()
    {
        // Instantiate VFX on projectile destruction
        Instantiate(impactExplosion, transform.position, transform.rotation);
    }
}
