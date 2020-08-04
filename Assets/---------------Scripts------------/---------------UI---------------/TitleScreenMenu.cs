using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleScreenMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject credits;
    private SoundManager soundManager;
    private AudioSource navigationBlip;
    private bool isPaused;

    //private bool isPaused;

    private void Start()
    {
        if (isPaused == true) // << Coroutine condition
        {
            return;
        }

        navigationBlip = FindObjectOfType<AudioSource>();
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
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
        navigationBlip.Play();
    }

    public void QuitGame()
    {
        StartCoroutine(timePause());
    }

    IEnumerator timePause()
    {
        soundManager.QuitBlip();
        isPaused = true;
        yield return new WaitForSeconds(2.0f);
        isPaused = false;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
