using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialTips;  // << Array to store on-screen tips
    [SerializeField] GameObject tutorialSpawnManager;
    private PlayerController playerController;
    private DetectPlayerCollisions playerHitPoints;
    private int tutorialTipsIndex;
    private bool enemyEngaged;
    private bool hazardHpDestroyed;
    public int tutorialPlayerHitPoints = 2;
    private int playerTutorialSpeed = 25;

    // Start is called before the first frame update
    void Start()
    {
        
        // Set tutorial variables
        playerController = FindObjectOfType<PlayerController>();
        playerHitPoints = FindObjectOfType<DetectPlayerCollisions>();
        playerController.canEngage = false;
        playerController.hasSpeed = true;
        hazardHpDestroyed = false;
        playerHitPoints.playerCurrentHitPoints = tutorialPlayerHitPoints;
        playerHitPoints.lifeBar.SetMaxLife(tutorialPlayerHitPoints);

        if(playerController.hasSpeed == true)
        {
            playerController.playerSpeed = playerTutorialSpeed;
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
            // Display how to move tip - if player moves move onto how to fire
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
                Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) // << That worked, thanks Michael! ^_^
            {
                tutorialTipsIndex++;
            }
        }
        else if (tutorialTipsIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Display how to shot tip - enemies will begin to spawn soon after

                playerController.canEngage = true;
                tutorialTipsIndex++;
            }
        }
        else if (tutorialTipsIndex == 2)
        {
            // Display engage and evade to stay alive tip

            tutorialSpawnManager.SetActive(true);
            tutorialTipsIndex++;
        }
        else if (tutorialTipsIndex == 3)
        {
            // Pick up health tip
            if (playerHitPoints)
            {
                // Enable flashing skip prompt
            }
        }
        else if (tutorialTipsIndex == 4)
        {
            // Pick up health tip
            if (playerHitPoints.playerCurrentHitPoints == playerHitPoints.playerMaxHitPoints)
            {
                // Enable flashing skip prompt
            }
        }
    }
}


