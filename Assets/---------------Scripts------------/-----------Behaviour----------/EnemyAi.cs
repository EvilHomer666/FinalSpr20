using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    // The worst most fake Ai maneuver - using Vector2 to simplify
    [SerializeField] Vector3 evadeWait; 
    [SerializeField] Vector2 evadeWindow; 
    [SerializeField] Vector2 evadeDelay; 
    [SerializeField] float xboundary, yboundary;
    [SerializeField] float anticipation; // Wait time before enemy action
    [SerializeField] float evade; // Window of time in which enemy performs maneuver
    private Rigidbody enemyRigidBody;
    private float currentSpeed;
    private float newPlayerTarget;
    private float targetReset = 0;


    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
        currentSpeed = enemyRigidBody.velocity.x;
        // Begin evasive maneuver
        StartCoroutine(Evade());
    }

    // Evade method
    IEnumerator Evade()
    {
        // Wait time before enemy action
        yield return new WaitForSeconds(Random.Range(evadeWait.x, evadeWait.z));

        while (true)
        {
            newPlayerTarget = Random.Range(1, evade) * -Mathf.Sign(transform.position.y);
            yield return new WaitForSeconds(Random.Range(evadeWindow.x, evadeWindow.y));
            newPlayerTarget = targetReset;
            yield return new WaitForSeconds(Random.Range(evadeDelay.x, evadeDelay.y));
        }
    }

    // Maneuver physics logic
    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(enemyRigidBody.velocity.y, newPlayerTarget, Time.deltaTime * anticipation);
        enemyRigidBody.velocity = new Vector3(0.0f, newManeuver, currentSpeed);
        enemyRigidBody.position = new Vector3(0.0f, Mathf.Clamp(enemyRigidBody.position.y, -yboundary, yboundary), Mathf.Clamp(enemyRigidBody.position.x, -xboundary, xboundary));
    }
}
