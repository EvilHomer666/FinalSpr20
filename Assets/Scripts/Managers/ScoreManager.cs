using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text timerText;
    private TutorialManager level02Check;
    private string sceneName;
    private Scene activeScene;
    private LevelTransition levelTransition;
    private float time = 66.6f;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        // Set score defaults and references
        level02Check = FindObjectOfType<TutorialManager>();
        levelTransition = FindObjectOfType<LevelTransition>();
        score = 0;
        UpdateScoreText();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    // Update timer in real time to text
    //    time -= Time.deltaTime;
    //    timerText.text = $"Contact in minus: {time.ToString("n2")}";
    //    if (time <=0)
    //    {
    //        levelTransition.FadeToNextLevel();
    //    }
    //}

    // Add score value and update text
    public void IncrementScore(int updatedScore)
    {
        score += updatedScore;
        UpdateScoreText();
    }

    // Update score text method
    public void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    private void Level02ModeCheck()
    {
        sceneName = activeScene.name;
        if (sceneName == "Lev02")
        {
            levelTransition.LevelLoop();
        }
    }
}
