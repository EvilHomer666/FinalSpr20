using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    // Projectile speed
    [SerializeField] float speedLv01;

    // Update is called once per frame
    void Update()
    {
        // Standard laser 
        transform.Translate(Vector3.right * Time.deltaTime * speedLv01);
    }
}
