using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialTips;  // << Array to store on-screen tips
    [SerializeField] GameObject tutorialSpawnManager;
    [SerializeField] GameObject onScreenProximityWarning;
    [SerializeField] GameObject displayPanel;
    private PlayerWeaponsController playerWeapons;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private PlayerController playerController;
    private GameManager gameOver;
    private DetectPlayerCollisions playerHitPoints;
    private LevelTransition levelTransition;
    private int tutorialTipsIndex;
    private bool hazardHpDestroyed;
    private bool dangerWarning;
    private bool isPaused;
    // Tutorial tips variables start
    private int HowToPlay = 0;
    private int HowToMove = 1;
    private int HowToShot = 2;
    private int EngageEnemy = 3;
    private int PowerUps = 4;
    private int RecoverHealth = 5;
    private int Exit = 6;
    // Tutorial tips variables end
    private int minScoretoContinue = 250; // TO DO set new condition when power up is discovered in addition of min score
    public bool wasEnemyEngaged;

    // Start is called before the first frame update
    void Start()
    {        // Set tutorial references and variables on start
        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
        playerController = FindObjectOfType<PlayerController>();
        gameOver = FindObjectOfType<GameManager>();
        playerHitPoints = FindObjectOfType<DetectPlayerCollisions>();
        scoreManager = FindObjectOfType<ScoreManager>();
        levelTransition = FindObjectOfType<LevelTransition>();
        playerWeapons = FindObjectOfType<PlayerWeaponsController>();
        playerController.canEngage = false;
        playerController.canMove = false;
        hazardHpDestroyed = false;
        dangerWarning = false;
        wasEnemyEngaged = false;
        displayPanel.gameObject.SetActive(false);
        StartCoroutine(timePauseHalfNoIdex());
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused == true) // << Coroutine pause condition
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
            StartCoroutine(LetsBegin());
        }

        // Display HOW TO MOVE tip - if player moves, move onto how to fire << #1
        else if (tutorialTipsIndex == HowToMove)
        {
            StartCoroutine(Movement());
        }

        // Display HOW TO SHOOT tip - if player fires, move onto engage and evade << #2
        else if (tutorialTipsIndex == HowToShot)
        {
            dangerWarning = true;
            StartCoroutine(HowToShoot());
        }

        // Display ENGAGE & EVADE to stay alive tip - if player is engaged, move onto power up tip << #3
        else if (tutorialTipsIndex == EngageEnemy)
        {
            StartCoroutine(ProximityWarning());
            dangerWarning = false;
            if (scoreManager.score > minScoretoContinue) // TO DO set new condition when power up is discovered in addition of min score
            {
                StartCoroutine(timePause());
            }
        }

        // Display ENEMIES DROP POWER UPS tip << #4
        else if (tutorialTipsIndex == PowerUps)
        {
            if (wasEnemyEngaged == true) // <<< Create custom enemy spawning point to trigger this at this time instead of at random
            {
                displayPanel.gameObject.SetActive(true);
                StartCoroutine(timePauseHalfNoIdex());
                tutorialTipsIndex++;
            }
        }

        // PICK UP HEALTH tip << #5
        else if (tutorialTipsIndex == RecoverHealth)
        {
            //if (playerHitPoints.playerCurrentHitPoints == playerHitPoints.playerMaxHitPoints)
            //{
            //    //StopCoroutine(timePauseLong());
            //    //tutorialTipsIndex++;
            //}
        }

        // EXIT - move onto exit << #6 TODO replace with first large ship encounter then exit
        else if (tutorialTipsIndex == Exit)
        {
            //if (playerHitPoints.playerCurrentHitPoints == playerHitPoints.playerMaxHitPoints)
            //{
            //    displayPanel.gameObject.SetActive(false);
            //    //StopCoroutine(timePause());
            //    //levelTransition.FadeToNextLevel(); // TO DO - Add hyper speed animation 
            //}
        }
    }

    IEnumerator ProximityWarning()
    {
        while (dangerWarning == true)
        {
            yield return new WaitForSeconds(4.0f);
            displayPanel.gameObject.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            onScreenProximityWarning.SetActive(true);
            soundManager.ProximityWarning();
            tutorialSpawnManager.SetActive(true);
            yield return new WaitForSeconds(4.5f);
            onScreenProximityWarning.SetActive(false);
        }
    }

    //IEnumerator timePauseLong()
    //{
    //    isPaused = true;
    //    yield return new WaitForSeconds(5.0f);
    //    isPaused = false;
    //}

    // Pauses start
    IEnumerator timePause()
    {
        isPaused = true;
        yield return new WaitForSeconds(2.85f);
        isPaused = false;
        tutorialTipsIndex++;
    }

    IEnumerator timePauseHalfNoIdex()
    {
        isPaused = true;
        yield return new WaitForSeconds(1.5f);
        isPaused = false;
    }
    // Pauses end


    // Timed Actions
    IEnumerator LetsBegin()
    {
        displayPanel.gameObject.SetActive(true);
        isPaused = true;
        yield return new WaitForSeconds(2.25f);
        isPaused = false;
        tutorialTipsIndex++;
    }

    IEnumerator Movement()
    {
        isPaused = true;
        yield return new WaitForSeconds(0.5f);
        playerController.canMove = true;
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            yield return new WaitForSeconds(3.5f);
            tutorialTipsIndex++;
        }
        isPaused = false;
    }

    IEnumerator HowToShoot()
    {
        isPaused = true;
        yield return new WaitForSeconds(0.75f);
        playerController.canEngage = true;
        if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0) ||
        Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            yield return new WaitForSeconds(2.5f);
            tutorialTipsIndex++;
        }
        isPaused = false;
    }
}


