﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTumble : MonoBehaviour
{
    private float spinSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
