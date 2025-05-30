using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent enemyNavMesh;
    public float EnemyVelocity;
    public bool isChasing;
    public float range;
    public float distance;

    public Transform target;
    public EnemyVision enemyVision; // Referencia al script de visión

    void Update()
    {
        distance = Vector3.Distance(enemyNavMesh.transform.position, target.position);

        if (distance < range)
        {
            isChasing = true;
        }
        else if (distance > range + 3)
        {
            isChasing = false;
        }

        if (isChasing == false)
        {
            enemyNavMesh.speed = 0;
        }
        else if (isChasing == true)
        {
            enemyNavMesh.speed = enemyVision.watchingTarget ? EnemyVelocity * 2 : EnemyVelocity;
            enemyNavMesh.SetDestination(target.position);
        }
    }

/*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, range);
    }
*/
}
