﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private int levelToLoad;
    public Animator transitionAnimator;

    /* Custom functions to fade in and out between levels -
       Method to run the Fade in animation on level start */
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        transitionAnimator.SetTrigger("FadeOut");
    }

    // Method to load the next scene on FadeOut animation event finish
    public void OnFadeFinish()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    // Method to add index to level queue
    public void FadeToNextLevel()
    {
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Method to manually Fade out on trigger from main menu using button event - continue
    public void ManualFadeOut()
    {
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}