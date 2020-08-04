using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] Animator transitionAnimator;
    private TitleScreenMenu mainMenu;
    private int levelToLoad;
    private string sceneName;

    private void Start()
    {
        mainMenu = FindObjectOfType<TitleScreenMenu>();
    }

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
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1); // << Fade to HOW TO PLAY (01) if on Main Menu
        }
    }

    // Method to manually Fade out on trigger from main menu using button
    public void ManualFadeOut()
    {
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 2); // << Fade to START (02) if on Main Menu
        }
    }
}
