using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject credits;
    [SerializeField] Text optionStart;
    [SerializeField] Text optionTutorial;
    [SerializeField] Text optionCredits;
    [SerializeField] Text optionExit;
    private LevelTransition levelTransition;
    private int numberOfOptions = 4;
    private int selectedOption;

    void Start()
    {
        levelTransition = FindObjectOfType<LevelTransition>();
        selectedOption = 1;
        optionStart.color = new Color32(255, 255, 255, 255);
        optionTutorial.color = new Color32(133, 146, 158, 225);
        optionCredits.color = new Color32(133, 146, 158, 225);
        optionExit.color = new Color32(133, 146, 158, 225);
    }

    void Update()
    {
        // Navigating menu from top to bottom
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            selectedOption += 1;
            if (selectedOption > numberOfOptions) // Go back to first option if at end of list
            {
                selectedOption = 1;
            }

            optionStart.color = new Color32(133, 146, 158, 225);
            optionTutorial.color = new Color32(133, 146, 158, 225);
            optionCredits.color = new Color32(133, 146, 158, 225);
            optionExit.color = new Color32(133, 146, 158, 225);

            switch (selectedOption)
            {
                case 1:
                    optionStart.color = new Color32(255, 255, 255, 255);
                    break;
                case 2:
                    optionTutorial.color = new Color32(255, 255, 255, 255);
                    break;
                case 3:
                    optionCredits.color = new Color32(255, 255, 255, 255);
                    break;
                case 4:
                    optionExit.color = new Color32(255, 255, 255, 255);
                    break;
            }
        }

        // Navigating menu from bottom to top
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            selectedOption -= 1;
            if (selectedOption < 1) // Go back to first option if at end of list
            {
                selectedOption = numberOfOptions;
            }

            optionStart.color = new Color32(133, 146, 158, 225);
            optionTutorial.color = new Color32(133, 146, 158, 225);
            optionCredits.color = new Color32(133, 146, 158, 225);
            optionExit.color = new Color32(133, 146, 158, 225);

            switch (selectedOption)
            {
                case 1:
                    optionStart.color = new Color32(255, 255, 255, 255);
                    break;
                case 2:
                    optionTutorial.color = new Color32(255, 255, 255, 255);
                    break;
                case 3:
                    optionCredits.color = new Color32(255, 255, 255, 255);
                    break;
                case 4:
                    optionExit.color = new Color32(255, 255, 255, 255);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Chose:" + selectedOption);

            switch (selectedOption)
            {
                case 1:
                    levelTransition.ManualFadeOut();
                    break;
                case 2:
                    levelTransition.FadeToNextLevel();
                    break;
                case 3:
                    ShowCredits();
                    break;
                case 4:
                    QuitGame();
                    break;
            }
        }
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

