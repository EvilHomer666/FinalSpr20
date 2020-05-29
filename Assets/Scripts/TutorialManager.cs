using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialTips;  // << Array to store on-screen tips
    [SerializeField] GameObject tutorialSpawnManager;
    [SerializeField] GameObject onScreenProximityWarning;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private PlayerController playerController;
    private DetectPlayerCollisions playerHitPoints;
    private DetectCollisions enemyEngaged;
    private BlinkingText blinkingText;
    private LevelTransition levelTransition;
    private int tutorialTipsIndex;
    private bool hazardHpDestroyed;
    private bool coroutineRunning;
    // Tutorial tips
    private int HowToMove = 0;
    private int HowToShot = 1;
    private int EngageEnemy = 2;
    private int PowerUps = 3;
    private int RecoverHealth = 4;
    private int Exit = 5;
    // Tutorial tips end
    private int minScoretoContinue = 50;
    public bool wasEnemyEngaged;



    // Start is called before the first frame update
    void Start()
    {        // Set tutorial references and variables
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        playerController = FindObjectOfType<PlayerController>();
        playerHitPoints = FindObjectOfType<DetectPlayerCollisions>();
        scoreManager = FindObjectOfType<ScoreManager>();
        enemyEngaged = FindObjectOfType<DetectCollisions>();
        blinkingText = FindObjectOfType<BlinkingText>();
        levelTransition = FindObjectOfType<LevelTransition>();
        playerController.canEngage = false;
        hazardHpDestroyed = false;          
    }

    // Update is called once per frame
    void Update()
    {
        // For loop to switch between tutorial tips
        for (int i = 0; i < tutorialTips.Length; i++)
        {
            if (i == tutorialTipsIndex)
            {
                tutorialTips[i].SetActive(true);
            }
            else
            {
                tutorialTips[i].SetActive(false);
            }
        }

        // Start tutorial tips
        if (tutorialTipsIndex == HowToMove)
        {
            // Display how to move tip - if player moves, move onto how to fire
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
                Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) // << That worked, thanks Michael! ^_^
            {
                soundManager.PlayerInputConfirmed();
                tutorialTipsIndex++;
            }
        }
        else if (tutorialTipsIndex == HowToShot)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Display how to shot tip - if player fires, move onto engage and evade
                playerController.ProjectileLaunchCondition();
                soundManager.PlayerInputConfirmed();
                playerController.canEngage = true;              
                tutorialTipsIndex++;
            }
        }
        else if (tutorialTipsIndex == EngageEnemy)
        {
            coroutineRunning = true;
            StartCoroutine("WaitForSeconds");          

            if (scoreManager.score >= minScoretoContinue)
            {
                // Display engage and evade to stay alive tip - if player is engaged, move onto power up tip
                tutorialTipsIndex++;
            }
        }
        else if (tutorialTipsIndex == PowerUps)
        {
            StopCoroutine("WaitForSeconds");
            if (wasEnemyEngaged == true)
            {
                // Display enemies drop power up tip
                tutorialTipsIndex++;
            }
        }
        else if (tutorialTipsIndex == RecoverHealth)
        {
            // Pick up health tip - if player gets power up and regains health, move onto exit
            if (playerHitPoints.playerCurrentHitPoints == playerHitPoints.playerMaxHitPoints)
            {
                tutorialTipsIndex++;
            }
        }
        else if (tutorialTipsIndex == Exit)
        {
            if (wasEnemyEngaged == true)
            {
                Debug.Log("EXIT NOW!");
                levelTransition.FadeToNextLevel(); // TO DO Add hyper speed animation 
            }
        }
    }

    IEnumerator WaitForSeconds()
    {
        while (coroutineRunning == true)
        {
            yield return new WaitForSeconds(3.0f);
            onScreenProximityWarning.SetActive(true);
            soundManager.ProximityWarning();
            tutorialSpawnManager.SetActive(true);
            yield return new WaitForSeconds(3.77f);
            onScreenProximityWarning.SetActive(false);
            yield return new WaitForSeconds(0.25f);
        }
        coroutineRunning = false;
    }
}


