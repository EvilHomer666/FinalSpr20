using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceLoop : MonoBehaviour
{
    private AudioSource kittenPurr;
    private GameManager gameOver;

    void Start()
    {
        //Fetch the AudioSource component of the GameObject (make sure there is one in the Inspector)
        kittenPurr = GetComponent<AudioSource>();
        gameOver = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gameOver.gameOver == true)
        {
            kittenPurr.Stop();
        }
    }
}
