using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    // Enemy speed
    [SerializeField] float orbitSpeed;
    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = -transform.right * orbitSpeed;
    }
}
