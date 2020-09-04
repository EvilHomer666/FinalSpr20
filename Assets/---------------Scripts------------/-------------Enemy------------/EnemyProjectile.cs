using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // Enemy Projectile properties and VFX
    [SerializeField] float projectileSpeed;
    [SerializeField] bool homingProjectile;
    [SerializeField] GameObject impactExplosion;
    private Vector3 playerLastPosition;
    private Rigidbody enemyProjectileRigidBody;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the game objects rigid bodies to apply movement
        enemyProjectileRigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        // This condition needs to be set up only at start, otherwise if
        // it's set in update, the game object will continue to track the player every frame
        if (homingProjectile == false && player != null)
        {
            // Regular projectile
            playerLastPosition = (player.transform.position - transform.position).normalized * projectileSpeed;
            enemyProjectileRigidBody.velocity = new Vector3(playerLastPosition.x, playerLastPosition.y);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (homingProjectile == true && player != null)
        {
            // Homing projectile
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyProjectileRigidBody.AddForce(lookDirection * projectileSpeed);
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
