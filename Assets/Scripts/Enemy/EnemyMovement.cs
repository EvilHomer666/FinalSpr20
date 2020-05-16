﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Enemy speed
    [SerializeField] GameObject engine;
    [SerializeField] GameObject extraFx;
    [SerializeField] float enemySpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * enemySpeed);
    }
}
