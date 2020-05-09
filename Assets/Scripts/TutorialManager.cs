using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorialTips;
    public GameObject tutorialSpawner;
    private int tutorialTipsIndex;
    public float waitTime = 2.0f;
    public PlayerController player;


    // Start is called before the first frame update
    void Start()
    {
        player.fireAllowed = false;
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
            // How to move  and avoid enemies/hazards 
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
                Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || 
                Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                tutorialTipsIndex ++;
            }
            else if (tutorialTipsIndex == 1)
            {
                // How to shot
                player.fireAllowed = false;
                if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    tutorialTipsIndex ++;
                }
            }
            else if (tutorialTipsIndex == 2)
            {
                // Pick Up Health

            }
            else if (tutorialTipsIndex == 3)
            {
                // Pick Up Speed

            }
            else if (tutorialTipsIndex == 4)
            {
                if (waitTime <= 0)
                {
                    // Continue
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
