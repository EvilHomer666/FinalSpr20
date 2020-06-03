using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Enemy speed
    [SerializeField] GameObject engine;
    [SerializeField] GameObject extraFx;
    [SerializeField] float enemySpeed;
    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = -transform.forward * enemySpeed;
    }
}
