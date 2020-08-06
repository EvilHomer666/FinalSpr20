using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleScreenMenu : MonoBehaviour
{    
    [SerializeField] GameObject fadeOutEffect;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject credits;
    private Animator quitFadeOutAnimator;
    private EventSystem eventSystem;
    private bool isRunning = false;

    // Using a variable to store the value of the first selection of the menu to make it reappear when switching between options
    void Start()
    {
        fadeOutEffect.SetActive(false);
    }

    // Custom methods to show credits, main menu, start & quit game
    public void ShowCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

    // Coroutine inside wrapper so that it can run from the OnClick event in the button inspector settings
    public void QuitGameCoroutineWrapper()
    {
        if (isRunning == false)
        {
            StartCoroutine(TimePause());
        }
    }
    private IEnumerator TimePause()
    {
        isRunning = true;
        // Do your stuff over multiple frames
        yield return new WaitForSeconds(2.0f);
        yield return null;
        isRunning = false;
        QuitGame();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Set active fadeout game objects on click
    public void EnableFadeOut()
    {
        fadeOutEffect.SetActive(true);
    }

    public void FadeOut()
    {
        quitFadeOutAnimator.SetTrigger("FadeOutAndQuit");
    }
}
