using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.back, 5);
        //transform.Rotate(Vector3.back, 10);

        //transform.position = transform.position + new Vector3(1f, 0f, 0);

        //transform.position = transform.position + new Vector3(1f, -1f, 0);

        //transform.position = transform.position + new Vector3(1f, 1f, 0);

        //transform.position = transform.position + Vector3.zero;



        //transform.position = transform.position + new Vector3(1f, 0f, 0);

        //transform.position = transform.position + new Vector3(1f, -1f, 0);

        //transform.position = transform.position + new Vector3(-1f, -1f, 0);

        //transform.position = transform.position - Vector3.one;

        transform.Rotate(moveVector * -1);
    }
}
