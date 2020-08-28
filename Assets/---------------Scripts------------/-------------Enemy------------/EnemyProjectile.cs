using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // Enemy Projectile properties and VFX
    [SerializeField] float speedLv01;
    [SerializeField] bool homingProjectile;
    [SerializeField] GameObject impactExplosion;
    private Vector3 target;
    private Rigidbody enemyProjectileRigidBody;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the game objects rigid bodies to apply movement
        enemyProjectileRigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (homingProjectile == true && player != null)
        {
            // Homing projectile
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyProjectileRigidBody.AddForce(lookDirection * speedLv01);
        }
        if (homingProjectile == false && player != null)
        {
            // Regular projectile
            enemyProjectileRigidBody.velocity = -transform.forward * speedLv01;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
