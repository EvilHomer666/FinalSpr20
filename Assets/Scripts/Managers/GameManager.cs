using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // UI
    [SerializeField] Text gameOverText;
    [SerializeField] Text tryAgainText;
    [SerializeField] float pauseDelay;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Set UI defaults
        gameOver = false;
        gameOverText.text = "";
        tryAgainText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // Game Over and Continue checks

        if(gameOver == true)
        {
            // Condition to try again
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
               Time.timeScale = 1;
            }

            // Condition to quit game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
               Time.timeScale = 1;
                // SceneManager.LoadScene(SceneManager.GetSceneByName("HighScores")); TO DO << load scores screen after game over and quit
            }
        }
    }

    public void GameOver()
    {
        // Game Over condition            
        gameOverText.text = "Game Over";
        tryAgainText.text = "Press 'R' Key to Try Again or Esc to Quit";
        StartCoroutine(PauseTime());
    }

    // Custom coroutine (THESE THINGS ARE AWESOME!!!!) method to allow player SFX to finish before pausing for game over screen. Will expand in future builds.
    IEnumerator PauseTime()
    {
        yield return new WaitForSeconds(pauseDelay);
        gameOver = true;
        Debug.Log("Game Over!");
       Time.timeScale = 0;
    }
}
