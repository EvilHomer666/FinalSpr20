using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyFireOutOfBound : MonoBehaviour
{
    // Custom method to destroy enemy fire without destroying enemies too close to boundary
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EnemyProjectile")
        {
            Destroy(other.gameObject);
        }
    }
}
