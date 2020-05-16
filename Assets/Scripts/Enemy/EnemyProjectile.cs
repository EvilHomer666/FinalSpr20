using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // Projectile variables
    [SerializeField] float speedLv01;
    [SerializeField] bool homingProjectile;
    private Vector3 target;
    private Rigidbody enemyProjectileRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the game objects rigid bodies to apply movement
        enemyProjectileRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (homingProjectile == true && player != null)
        {
            // Homing projectile
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyProjectileRb.AddForce(lookDirection * speedLv01);
        }
        if (homingProjectile == false && player != null)
        {
            // Regular projectile
            enemyProjectileRb.velocity = -transform.forward * speedLv01;
        }
    }
}
