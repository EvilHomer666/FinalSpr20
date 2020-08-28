using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    [SerializeField] Image[] speeds;
    [SerializeField] Sprite fullSpeedLevel;
    [SerializeField] Sprite emptySpeedLevel;
    private PlayerController playerController;
    private DetectPlayerCollisions playerCollisions;
    private SoundManager soundManager;
    private int speedLv0 = 0; // >> 10 speed
    private int speedLv1 = 1; // >> 15 speed
    private int speedLv2 = 2; // >> 20 speed
    private int speedLv3 = 3; // >> 25 speed
    public int speedLv; // Variable that displays current speed level - to be accessed by player controller script
                        /* Base speed is 10, can be upgraded to 25*/
    public int numberOfSpeeds = 4; // Total number of speed levels

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        soundManager = GetComponent<SoundManager>();
        playerCollisions = GetComponent<DetectPlayerCollisions>();
    }

    // Update is called once per frame
    void Update()
    {
        updateSpeedBar();

        for (int i = 0; i < speeds.Length; i++)
        {
            if(i < speedLv)
            {
                speeds[i].sprite = fullSpeedLevel;
            }
            else
            {
                speeds[i].sprite = emptySpeedLevel;
            }

            if (i < numberOfSpeeds)
            {
                speeds[i].enabled = true;
            }
            else
            {
                speeds[i].enabled = false;           
            }
        }

        if(speedLv > numberOfSpeeds)
        {
            speedLv = numberOfSpeeds;
        }
    }

    // Method to update the speed bar UI, NOT the player's actual speed
    public void updateSpeedBar()
    {
        if (playerController.playerSpeed == 10)
        {
            speedLv = speedLv0;            
            GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Play();
        }
        if (playerController.playerSpeed == 15)
        {
            speedLv = speedLv1;
            soundManager.EnginesLv1();
            GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Play();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
        }
        if (playerController.playerSpeed == 20)
        {
            speedLv = speedLv2;
            soundManager.EnginesLv2();
            GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Play();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
        }
        if (playerController.playerSpeed == 25)
        {
            speedLv = speedLv3;
            soundManager.EnginesLv3();
            GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Play();
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
        }
    }
}
