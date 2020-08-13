using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    [SerializeField] Image[] speeds;
    [SerializeField] Sprite fullSpeedLevel;
    [SerializeField] Sprite emptySpeedLevel;
    private PlayerController speedValue;
    private int speedLv0 = 0; // >> 10 speed
    private int speedLv1 = 1; // >> 15 speed
    private int speedLv2 = 2; // >> 20 speed
    private int speedLv3 = 3; // >> 25 speed
    public int numberOfSpeeds = 4; // Total number of speed levels
    public int speedLv; // Variable that displays current speed level - to be accessed by player controller script
    /* Base speed is 10, can be upgraded to 25
     * in 5 point increments. Tutorial starts at 15 with base speed as fall back.
     */

    // Start is called before the first frame update
    void Start()
    {
        speedValue = GetComponent<PlayerController>();
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

    // Method to update the speed bar UI and player object particle FX  
    private void updateSpeedBar()
    {
        if (speedValue.playerSpeed <= 10 && speedValue.playerSpeed >= 0) // << Red Sparks
        {
            speedLv = speedLv0; // << Changes the speed level sprite UI
            GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Play();
        }
        if (speedValue.playerSpeed <= 15 && speedValue.playerSpeed >= 11)  // << Red flame
        {
            speedLv = speedLv1; // << Changes the speed level sprite UI
            GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Play();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
        }
        if (speedValue.playerSpeed <= 20 && speedValue.playerSpeed >= 16)  // << Green flame
        {
            speedLv = speedLv2; // << Changes the speed level sprite UI
            GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Play();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
        }
        if (speedValue.playerSpeed <= 25 && speedValue.playerSpeed >= 21) // << Blur flame
        {
            speedLv = speedLv3; // << Changes the speed level sprite UI
            GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Play();
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
        }
    }
}
