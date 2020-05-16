using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialTips;  // << Array to store on-screen tips
    private PlayerController playerController;
    private DetectPlayerCollisions playerHitPoints;
    private int tutorialTipsIndex;
    private bool enemyEngaged;

    // Start is called before the first frame update
    void Start()
    {
        // Set tutorial variables
        playerController = FindObjectOfType<PlayerController>();
        playerHitPoints = FindObjectOfType<DetectPlayerCollisions>();        
        playerController.canEngage = false;
        playerController.hasSpeed = true;
        enemyEngaged = false;

        if(playerController.hasSpeed == true)
        {
            playerController.playerSpeed = 20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // For loop to switch between tutorials
        for (int i = 0; i < tutorialTips.Length; i++)
        {
            if (i == tutorialTipsIndex)
            {
                tutorialTips[i].SetActive(true);
            }
            else
            {
                tutorialTips[i].SetActive(false);
            }
        }

        if (tutorialTipsIndex == 0)
        {
            // Display how to move tip
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
                Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.JoystickButton10) || Input.GetKeyDown(KeyCode.JoystickButton11)) // << Buggy!! O_o?
            {
                tutorialTipsIndex++;
                playerController.canEngage = true;
            }
            else if (tutorialTipsIndex == 1)
            {

                if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    // Display how to shot
                    //if ()
                    //{
                        
                    //}
                    //tutorialTipsIndex++;
                }
            }
            //else if (tutorialTipsIndex == 2)
            //{
            //    if (waitTime <= 0)
            //    {
            //        // Display how to engage enemy 
            //        tutorialSpawner.SetActive(true);
            //        tutorialTipsIndex++;
            //    }
            //    else
            //    {
            //        waitTime -= Time.deltaTime;
            //    }
            //}
            else if (tutorialTipsIndex == 2)
            {
                // Pick Up Health and exit
                if (playerHitPoints.playerCurrentHitPoints == playerHitPoints.playerMaxHitPoints)
                {
                    // TO DO flash skip prompt
                }
            }
        }
    }
}

