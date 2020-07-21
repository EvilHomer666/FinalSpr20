using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SkipTutorial : MonoBehaviour
{
    // Reference to Level transition script
    private LevelTransition levelTransition;

    private void Start()
    {
        // Initialize script
        levelTransition = FindObjectOfType<LevelTransition>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button8) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            levelTransition.FadeToNextLevel();
        }
    }
}
