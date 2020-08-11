using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEmissionBlink : MonoBehaviour
{
    [SerializeField] Material material;
    private float time = 0f;
    private bool emitting = false;

    void Awake()
    {
        material.DisableKeyword("_EMISSION");
    }

    void Update()
    {
        if (time >= 0.5f)
        {
            emitting = !emitting;
            if (emitting)
                material.EnableKeyword("_EMISSION");
            else
                material.DisableKeyword("_EMISSION");
            time = 0f;
        }

        time += Time.deltaTime;
    }
}
