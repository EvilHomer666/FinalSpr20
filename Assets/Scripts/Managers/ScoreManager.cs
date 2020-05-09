using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text timerText;
    private float time;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        // Set score defaults
        score = 0;
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        // Update timer in real time to text
        time += Time.deltaTime;
        timerText.text = $"Time: {time.ToString("n2")}";
    }

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
}
