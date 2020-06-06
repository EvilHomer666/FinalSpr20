using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialTips;  // << Array to store on-screen tips
    [SerializeField] GameObject tutorialSpawnManager;
    [SerializeField] GameObject onScreenProximityWarning;
    private PlayerWeaponsController playerWeapons;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private PlayerController playerController;
    private DetectPlayerCollisions playerHitPoints;
    private DetectCollisions enemyEngaged;
    private BlinkingText blinkingText;
    private LevelTransition levelTransition;
    private int tutorialTipsIndex;
    private bool hazardHpDestroyed;
    private bool dangerWarning;
    private bool tutorialPause;
    private bool timerPause;
    private float time = 0.0f;
    // Tutorial tips variables start
    private int HowToMove = 0;
    private int HowToShot = 1;
    private int EngageEnemy = 2;
    private int PowerUps = 3;
    private int RecoverHealth = 4;
    private int Exit = 5;
    // Tutorial tips variables end
    private int minScoretoContinue = 50;
    public bool wasEnemyEngaged;



    // Start is called before the first frame update
    void Start()
    {        // Set tutorial references and variables on start
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        playerController = FindObjectOfType<PlayerController>();
        playerHitPoints = FindObjectOfType<DetectPlayerCollisions>();
        scoreManager = FindObjectOfType<ScoreManager>();
        enemyEngaged = FindObjectOfType<DetectCollisions>();
        blinkingText = FindObjectOfType<BlinkingText>();
        levelTransition = FindObjectOfType<LevelTransition>();
        playerWeapons = FindObjectOfType<PlayerWeaponsController>();
        tutorialTipsIndex = 0;
        hazardHpDestroyed = false;
        dangerWarning = false;
        wasEnemyEngaged = false; // << change to min number of enemies destroyed
        timerPause = false;
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

        // Start tutorial tips here
        // Display HOW TO MOVE tip - if player moves, move onto how to fire
        if (tutorialTipsIndex == HowToMove)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
                Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                timerPause = true;
                StartCoroutine(timePause());
            }
        }

        // Display HOW TO SHOOT tip - if player fires, move onto engage and evade
        else if (tutorialTipsIndex == HowToShot)
        {            
            if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                playerWeapons.ProjectileLaunchCondition();
                playerController.canEngage = true;
                dangerWarning = true;
                StartCoroutine(ProximityWarning());

                timerPause = true;
                StartCoroutine(timePause());
            }
        }

        // Display ENGAGE & EVADE to stay alive tip - if player is engaged, move onto power up tip
        else if (tutorialTipsIndex == EngageEnemy)
        {
            dangerWarning = false;
            StopCoroutine(ProximityWarning());

            if (scoreManager.score > minScoretoContinue)
            {
                timerPause = true;
                StartCoroutine(timePause());
            }
        }

        // Display ENEMIES DROP POWER UPS tip
        else if (tutorialTipsIndex == PowerUps)
        {
            if (wasEnemyEngaged == true)
            {
                timerPause = true;
                StartCoroutine(timePause());
            }
        }

        // PICK UP HEALTH tip - if player gets power up and regains health, move onto exit
        else if (tutorialTipsIndex == RecoverHealth)
        {
            if (playerHitPoints.playerCurrentHitPoints == playerHitPoints.playerMaxHitPoints)
            {
                timerPause = true;
                StartCoroutine(timePause());
            }
        }
        else if (tutorialTipsIndex == Exit)
        {
            if (wasEnemyEngaged == true)
            {
                Debug.Log("EXIT NOW!");
                StopCoroutine(timePause());
                levelTransition.FadeToNextLevel(); // TO DO Add hyper speed animation 
            }
        }
    }

    IEnumerator ProximityWarning()
    {
        while (dangerWarning == true)
        {
            yield return new WaitForSeconds(3.0f);
            onScreenProximityWarning.SetActive(true);
            soundManager.ProximityWarning();
            tutorialSpawnManager.SetActive(true);
            yield return new WaitForSeconds(3.75f);
            onScreenProximityWarning.SetActive(false);
        }
    }

    IEnumerator timePause()
    {
        if (timerPause == true)
        {
            yield return new WaitForSeconds(3.0f);
            NextTip();
        }
    }

    private void NextTip()
    {
        tutorialTipsIndex++;
        timerPause = false;
    }
}


