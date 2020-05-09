using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinEffect : MonoBehaviour
{
    [SerializeField] int spinSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, Random.Range(20.0f, 60.0f) * spinSpeed * Time.deltaTime);
    }
}
