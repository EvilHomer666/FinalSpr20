using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineAi : MonoBehaviour
{
    [SerializeField] float enemyAcceleration;
    private float distance;
    // References to player and enemy rigid body
    private GameObject playerPosition;
    private Rigidbody rigidBody;
    private bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to rigid body
        rigidBody = GetComponent<Rigidbody>();
        playerPosition = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        distance = (transform.position.x - playerPosition.transform.position.x);
        if (distance < 16.0f)
        {
            Vector3 lookDirection = (playerPosition.transform.position - transform.position).normalized;
            rigidBody.AddForce(lookDirection * enemyAcceleration);
        }
    }
}
