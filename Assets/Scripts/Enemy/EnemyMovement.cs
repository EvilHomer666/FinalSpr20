﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Enemy speed
    [SerializeField] float enemySpeed;
    [SerializeField] GameObject engine;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * enemySpeed);
        //GetComponent<ParticleSystem>().Play(engine);


    }
}
