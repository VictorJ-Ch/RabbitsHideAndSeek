using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public GameObject target;
    [Range(0, 180)]
    public int visualCone;
    public int visualRange;
    public GameObject visualIndicator;
    [Header("Read Only")]
    public bool watchingTarget;
    public bool targetInRange;

    void Update()
    {
        VisualCone();
    }

    void OnDrawGizmos()
    {
        if (target == null) return;

        // Dibuja la línea de visión
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, target.transform.position);

        // Dibuja el cono de visión
        Vector3 forward = transform.forward * visualRange;
        Vector3 leftLimit = Quaternion.Euler(0, -visualCone / 2, 0) * forward;
        Vector3 rightLimit = Quaternion.Euler(0, visualCone / 2, 0) * forward;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, leftLimit);
        Gizmos.DrawRay(transform.position, rightLimit);
    }

    public void VisualCone()
    {
        Vector3 directionAtoB = (target.transform.position - transform.position).normalized;
        float prodPunto = Vector3.Dot(directionAtoB, transform.forward);
        float transformedAngle = Mathf.Cos(visualCone * Mathf.Deg2Rad / 2);

        float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        targetInRange = distanceToTarget <= visualRange;
        watchingTarget = targetInRange && prodPunto > transformedAngle;

        visualIndicator.SetActive(watchingTarget);
    }
}
