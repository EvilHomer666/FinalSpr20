using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] GameObject centerOfGravity; // Object around which secondary object will move around
    [SerializeField] float rotationSpeed;
    [SerializeField] bool forward;

    // Update is called once per frame
    void Update()
    {
        if (forward == true)
        {
            OrbitAroundUp();
        }
        else
        {
            OrbitAroundDown();
        }
    }
    void OrbitAroundUp()
    {
        transform.RotateAround(centerOfGravity.transform.position, -Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    void OrbitAroundDown()
    {
        transform.RotateAround(centerOfGravity.transform.position, -Vector3.right, rotationSpeed * Time.deltaTime);
    }

}
