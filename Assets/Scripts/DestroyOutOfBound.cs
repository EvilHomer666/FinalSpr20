using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{ 
    // Custom method to destroy!!!!!
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
