using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Enemy speed
    [SerializeField] float enemySpeed;
    [SerializeField] GameObject engines;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * enemySpeed);
    }
}
