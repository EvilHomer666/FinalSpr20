using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private PlayerWeaponsController playerWeapons;
    private float xRange = 18.5f;
    private float yRange = 9.3f;
    private float horizontalInput;
    private float verticalInput;
    private float tilt = 25.0f;
    public float playerSpeed;
    public float playerSpeedCap = 25;
    public float speedReset = 10;
    public bool canEngage;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        playerWeapons = FindObjectOfType<PlayerWeaponsController>();
        playerSpeed = 10; // << Base speed
    }

    void Update()
    {
        if (canEngage == true && GameObject.FindWithTag("Player") != null)
        {
            playerWeapons.ProjectileLaunchCondition();
        }
    }

    void FixedUpdate()
    {
        // Check for horizontal & vertical player movement boundary
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

        if(canMove == true)
        {
            // Player input movement
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed, Space.World);

            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * verticalInput * Time.deltaTime * playerSpeed, Space.World);

            // Set rotation over x axis
            transform.rotation = Quaternion.Euler(Input.GetAxis("Vertical") * tilt, 0, 0);
        }

        // Check to never let player have more than allowed speed points 
        if (playerSpeed > playerSpeedCap)
        {
            playerSpeed = playerSpeedCap;
        }
    }

    // Update player speed method
    public void UpdatePlayerSpeed(float speedBoost)
    {
        playerSpeed += speedBoost;
    }
}