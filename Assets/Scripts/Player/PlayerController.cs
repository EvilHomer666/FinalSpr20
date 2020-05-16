﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Movement variables
    [SerializeField] Transform cannonSpawn;
    [SerializeField] float xRange = 15.4f;
    [SerializeField] float yRange = 9.3f;
    public float horizontalInput;
    public float verticalInput;
    private SoundManager soundManager;
    //private Scene activeScene;
    //private string sceneName;
    public float playerSpeed;
    public float playerSpeedCap = 25;
    public int speedReset = 10;
    // For use with tutorial
    public bool canEngage;

    // public bool polarityModifier; // << TO DO Add player ability to use enemy fire against them

    // Weapons array
    public Transform[] cannons;

    // Start is called before the first frame update
    void Start()
    {
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        playerSpeed = 10;
        canEngage = true;
        // Tutorial scene check
        //activeScene = SceneManager.GetActiveScene();
        //CanEngage();

        //  polarityModifier = false; // << TO DO Add player ability to use enemy fire against them
    }

    // Update is called once per frame
    void Update()
    {
        // Check for horizontal & vertical player movement boundaries
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

        if (canEngage == true)
        {
            // Projectile launch condition with for each element to read array
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                foreach (var projectile in cannons)
                {
                    Instantiate(projectile, cannonSpawn.position, cannonSpawn.rotation);
                }
                soundManager.PlayerFireLaserLv1();
            }
        }

    }

    // Update player speed method
    public void UpdatePlayerSpeed(float speedBoost)
    {
        playerSpeed += speedBoost;
    }

    //// Tutorial scene check
    //public void CanEngage()
    //{
    //    sceneName = activeScene.name;
    //    if (sceneName == "Lev00")
    //    {
    //        canEngage = false;
    //    }
    //    if (sceneName != "Lev00")
    //    {
    //        canEngage = true;
    //    }
    //}
}
