using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using TMPro;
using System;

public class PlayerArea : MonoBehaviour
{

    [Tooltip("The agent in the area")]
    public PlayerAgent playerAgent;

    [Tooltip("Target prefab")]
    public Target targetFab;

    [Tooltip("Message that shows cumulative points")]
    public TextMeshPro cumulativeRewardText;

    public void ResetArea()
    {
        ResetTarget();
        ResetPlayer();
    }

    private void ResetPlayer()
    {
        Rigidbody rigidbody = playerAgent.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        playerAgent.transform.position = ChooseRandomPosition(transform.position, 0f, 360f, 0f, 9f) + Vector3.up * .5f;
        playerAgent.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
    }

    public static Vector3 ChooseRandomPosition(Vector3 center, float minAngle, float maxAngle, float minRadius, float maxRadius)
    {
        float radius = minRadius;
        float angle = minAngle;

        if (maxRadius > minRadius)
        {
            radius = UnityEngine.Random.Range(minRadius, maxRadius);
        }

        if (maxAngle > minAngle)
        {
            angle = UnityEngine.Random.Range(minAngle, maxAngle);
        }

        return center + Quaternion.Euler(0f, angle, 0f) * Vector3.forward * radius;
    }

    private void ResetTarget()
    {
        GameObject newTarget = Instantiate<GameObject>(targetFab.gameObject);
        BoxCollider bCollider = newTarget.AddComponent<BoxCollider>();
        bCollider.center = Vector3.zero;
        bCollider.size = new Vector3(1.2f, 1.2f, 1.2f);
        newTarget.transform.position = ChooseRandomPosition(transform.position, 0f, 360f, 0f, 5f) + Vector3.up * .5f;
        newTarget.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);

        newTarget.transform.SetParent(transform);
    }
}
