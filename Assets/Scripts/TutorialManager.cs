using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialTips;  // << Array to store on-screen tips
    [SerializeField] GameObject tutorialSpawnManager;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private PlayerController playerController;
    private DetectPlayerCollisions playerHitPoints;
    private int tutorialTipsIndex;
    private bool enemyEngaged;
    private bool hazardHpDestroyed;
    private int playerTutorialSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {        // Set tutorial variables
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        playerController = FindObjectOfType<PlayerController>();
        playerHitPoints = FindObjectOfType<DetectPlayerCollisions>();
        scoreManager = FindObjectOfType<ScoreManager>();
        playerController.canEngage = false;
        playerController.hasSpeed = true;
        hazardHpDestroyed = false;
        //playerHitPoints.playerCurrentHitPoints = playerHitPoints.playerMaxHitPoints;
        //playerHitPoints.lifeBar.SetMaxLife(playerHitPoints.playerCurrentHitPoints);

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
                soundManager.PlayerInputConfirmed();
                tutorialTipsIndex++;
            }
        }
        else if (tutorialTipsIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Display how to shot tip - enemies will begin to spawn soon after
                soundManager.PlayerInputConfirmed();
                playerController.canEngage = true;
                tutorialSpawnManager.SetActive(true);
                tutorialTipsIndex++;
            }
        }
        else if (tutorialTipsIndex == 2)
        {
            if(scoreManager.score == 700)
            {
                // Display engage and evade to stay alive tip
                soundManager.PlayerInputConfirmed();
                tutorialTipsIndex++;
            }

        }
        else if (tutorialTipsIndex == 3)
        {
            // Pick up health tip
            if (playerHitPoints.playerCurrentHitPoints == playerHitPoints.playerMaxHitPoints)
            {
                // Enable flashing skip prompt
                soundManager.PlayerInputConfirmed();
            }
        }
    }
}


