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
    private LevelTransition levelTransition;
    private int tutorialTipsIndex;
    private bool hazardHpDestroyed;
    private bool dangerWarning;
    private bool isPaused;
    // Tutorial tips variables start (7) total
    private int HowToPlay = 0;
    private int HowToMove = 1;
    private int HowToShot = 2;
    private int EngageEnemy = 3;
    private int PowerUps = 4;
    private int RecoverHealth = 5;
    private int Exit = 6;
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
        levelTransition = FindObjectOfType<LevelTransition>();
        playerWeapons = FindObjectOfType<PlayerWeaponsController>();
        playerController.canEngage = false;
        playerController.canMove = false;
        hazardHpDestroyed = false;
        dangerWarning = false;
        wasEnemyEngaged = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused == true) // << Coroutine condition
        {
            return;
        }

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

        // Display HOW TO PLAY prompt - auto switch on timer << #0
        if (tutorialTipsIndex == HowToPlay)
        {
            StartCoroutine(timePause());
            tutorialTipsIndex++;
        }

        // Display HOW TO MOVE tip - if player moves, move onto how to fire << #1
        else if (tutorialTipsIndex == HowToMove)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
                Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                playerController.canMove = true;
                StartCoroutine(timePause());
                tutorialTipsIndex++;
            }
        }

        // Display HOW TO SHOOT tip - if player fires, move onto engage and evade << #2
        else if (tutorialTipsIndex == HowToShot)
        {
            if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0) ||
                Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                playerController.canEngage = true;
                //playerWeapons.ProjectileLaunchCondition();
                dangerWarning = true;
                StartCoroutine(ProximityWarning());
                StartCoroutine(timePause());
                tutorialTipsIndex++;
            }
        }

        // Display ENGAGE & EVADE to stay alive tip - if player is engaged, move onto power up tip << #3
        else if (tutorialTipsIndex == EngageEnemy)
        {
            dangerWarning = false;
            StopCoroutine(ProximityWarning());

            if (scoreManager.score > minScoretoContinue)
            {
                StartCoroutine(timePause());
                tutorialTipsIndex++;
            }
        }

        // Display ENEMIES DROP POWER UPS tip << #4
        else if (tutorialTipsIndex == PowerUps)
        {
            if (wasEnemyEngaged == true)
            {
                StartCoroutine(timePause());
                tutorialTipsIndex++;
            }
        }

        // PICK UP HEALTH tip - if player gets power up and regains health, move onto exit << #5
        else if (tutorialTipsIndex == RecoverHealth)
        {
            if (playerHitPoints.playerCurrentHitPoints == playerHitPoints.playerMaxHitPoints)
            {
                StartCoroutine(timePause());
                StopCoroutine(timePause());
                //levelTransition.FadeToNextLevel(); // TO DO - Add hyper speed animation 
            }
        }       
    }

    IEnumerator ProximityWarning()
    {
        while (dangerWarning == true)
        {
            yield return new WaitForSeconds(6.0f);
            onScreenProximityWarning.SetActive(true);
            soundManager.ProximityWarning();
            tutorialSpawnManager.SetActive(true);
            yield return new WaitForSeconds(4.5f);
            onScreenProximityWarning.SetActive(false);
        }
    }

    IEnumerator timePause()
    {       
            isPaused = true;
            yield return new WaitForSeconds(3.5f);
            isPaused = false;
    }
}


