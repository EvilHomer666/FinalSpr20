using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject credits;
    [SerializeField] Text optionStart;
    [SerializeField] Text optionTutorial;
    [SerializeField] Text optionCredits;
    [SerializeField] Text optionExit;
    private int numberOfOptions = 4;
    private int selectedOption;


    public void StartGame()
    {
        //SceneManager.LoadScene("Lev01");
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

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
