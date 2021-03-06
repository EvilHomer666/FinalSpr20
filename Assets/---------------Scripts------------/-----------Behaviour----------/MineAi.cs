﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineAi : MonoBehaviour
{
    [SerializeField] float enemyAcceleration;
    private float detectionDiameter = 13.0f;
    private float distance;
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
        if (distance < detectionDiameter && isActiveAndEnabled && rigidBody != null)
        {
            Vector3 lookDirection = (playerPosition.transform.position - transform.position).normalized;
            rigidBody.AddForce(lookDirection * enemyAcceleration);
        }
    }
}
