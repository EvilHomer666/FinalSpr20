using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    // Player projectile properties and VFX
    [SerializeField] GameObject impactExplosion;
    [SerializeField] float laserSpeed;
    [SerializeField] bool isRearCannnon;
    private Rigidbody playerProjectileRigidBody;
    public float damageValueMultiplier; // << To be used in enemy detect collisions script to apply damage from player projectile
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    private void Update()
    {
        if (isRearCannnon == true && player != null)
        {
            // Rear cannon projectiles
            transform.Translate(Vector3.left * Time.deltaTime * laserSpeed);
        }
        if (isRearCannnon == false && player != null)
        {
            // Standard twin lasers 
            transform.Translate(Vector3.right * Time.deltaTime * laserSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyShip" || other.gameObject.tag == "Hazard")
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
