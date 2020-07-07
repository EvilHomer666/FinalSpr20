using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        // Set score defaults and references
        score = 0;
        UpdateScoreText();
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
        scoreText.text = $"{score}";
    }
}
