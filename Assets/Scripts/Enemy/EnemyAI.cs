using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRigidBody;
    private float evadeSpeed = 60f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        StartCoroutine(EvadeAction());
    }

    IEnumerator EvadeAction()
    {
        yield return new WaitForSeconds(1.5f);
        // Calculate player position
        Vector3 playerDirection = (player.transform.position - transform.position).normalized;
        // Move towards player
        enemyRigidBody.MovePosition(playerDirection * evadeSpeed);
    }
}

