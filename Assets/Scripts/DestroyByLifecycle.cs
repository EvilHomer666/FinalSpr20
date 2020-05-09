using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByLifecycle : MonoBehaviour
{
    [SerializeField] float lifecycle;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifecycle);
    }
}
