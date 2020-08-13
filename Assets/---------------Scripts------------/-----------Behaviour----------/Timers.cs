using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timers : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] float time;
    private TutorialManager levelCheck;
    private string sceneName;
    private Scene activeScene;
    private LevelTransition levelTransition;

    // Start is called before the first frame update
    void Start()
    {
        levelCheck = FindObjectOfType<TutorialManager>();
        levelTransition = FindObjectOfType<LevelTransition>();
        activeScene = SceneManager.GetActiveScene();
        sceneName = activeScene.name;
    }

    void Update()
    {
        LevelModeCheck();
    }

    private void LevelModeCheck()
    {
        if (sceneName == "Lev00")
        {
            TutorialMode();
        }
        else
        {
            PlayMode();
        }
    }

    private void TutorialMode()
    {
        // Hyper Jump Countdown
        time -= Time.deltaTime;
        timerText.text = $"Time to Hyper Jump: {time.ToString("n2")}";
        if (time <= 1)
        {
            levelTransition.FadeToNextLevel();
        }
    }

    private void PlayMode()
    {
        // Level Timer
        time += Time.deltaTime;
        timerText.text = $"Time: {time.ToString("n2")}";
    }
}
