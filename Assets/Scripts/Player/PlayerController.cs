using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float xRange = 15.4f;
    [SerializeField] float yRange = 9.3f;
    private PlayerWeaponsController playerWeapons;
    private Rigidbody playerRigidBody;
    private float horizontalInput;
    private float verticalInput;
    public float playerSpeed;
    public float playerSpeedCap = 25;
    public int speedReset = 10;
    public bool canEngage;

    // Start is called before the first frame update
    void Start()
    {
        playerWeapons = FindObjectOfType<PlayerWeaponsController>();
        playerRigidBody = GetComponent<Rigidbody>();
        playerSpeed = 10;
    }

    void Update()
    {
        if (canEngage == true)
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

        // Player input movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.back * horizontalInput * Time.deltaTime * playerSpeed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * playerSpeed);
    }

    // Update player speed method
    public void UpdatePlayerSpeed(float speedBoost)
    {
        playerSpeed += speedBoost;
    }
}