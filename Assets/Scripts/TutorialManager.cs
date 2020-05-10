using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialSpawner;
    [SerializeField] GameObject[] tutorialTips;  // << Array to store on-screen tips
    private int tutorialTipsIndex;
    private PlayerController playerController;
    private SpeedPowerUp speedPowerUp;
    private HealthPowerUp healthPowerUp;
    public float waitTime;
    public bool isTutorial;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerController.fireAllowed = false;
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
            isTutorial = true;
            // How to move 
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
                Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || 
                Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                tutorialTipsIndex ++;
            }
            if (tutorialTipsIndex == 1)
            {
                // How to shot 
                playerController.fireAllowed = true;
                if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
                {                    
                    tutorialTipsIndex++;
                }
            }
            if (tutorialTipsIndex == 2)
            {
                // Pick Up Health 
                //if (healthPowerUp.hasHealth == true)                     
                {
                    tutorialTipsIndex ++;
                }

            }
            if (tutorialTipsIndex == 3)
            {
                // Pick Up Speed 
               // if (speedPowerUp.hasSpeed == true)
                {
                    tutorialTipsIndex ++;
                }

            }
            if (tutorialTipsIndex == 4)
            {
                if (waitTime <= 0)
                {
                    // Destroy enemy!
                    tutorialSpawner.SetActive(true);
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        } 
    }
}
