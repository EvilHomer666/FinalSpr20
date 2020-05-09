using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawner : MonoBehaviour
{
    [SerializeField] GameObject asteroid;
    [SerializeField] GameObject enemyShip;
    [SerializeField] GameObject healthPickup;
    [SerializeField] GameObject speedPickup;
    private float timeBetween;
    public float startTimeBetween;
    public int numberOfInstances;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimeBetween <= 0 && numberOfInstances > 0)
        {
            Instantiate(asteroid, transform.position, Quaternion.identity);
            timeBetween = startTimeBetween;
            numberOfInstances--;
        }
        else
        {
            timeBetween -= Time.deltaTime;
        }
    }
}
