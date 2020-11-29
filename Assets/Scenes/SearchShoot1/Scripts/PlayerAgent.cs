using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using MLAgents.Sensors;
using System;

public class PlayerAgent : Agent
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;

    private PlayerArea playerArea;
    private Target targetObject;
    new private Rigidbody rigidbody;

    public override void Initialize()
    {
        base.Initialize();
        playerArea = GetComponentInParent<PlayerArea>();
        targetObject = playerArea.targetFab;
        rigidbody = GetComponent<Rigidbody>();
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        float forwardAmount = vectorAction[0];

        float turnAmount = 0f;
        if (vectorAction[1] == 1f)
        {
            turnAmount = -1f;
        }

        else if (vectorAction[1] == 2f)
        {
            turnAmount = 1f;
        }

        rigidbody.MovePosition(transform.position + transform.forward * forwardAmount * moveSpeed * Time.fixedDeltaTime);
        transform.Rotate(transform.up * turnAmount * turnSpeed * Time.fixedDeltaTime);

        if (maxStep > 0) AddReward(-1f / maxStep);
    }

    public override float[] Heuristic()
    {
        float forwardAction = 0f;
        float turnAction = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            forwardAction = 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            turnAction = 1f;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            turnAction = 2f;
        }

        return new float[] { forwardAction, turnAction };
    }

    public override void OnEpisodeBegin()
    {
        playerArea.ResetArea();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Distance from player to target (1 float = 1 value)
        sensor.AddObservation(Vector3.Distance(targetObject.transform.position, transform.position));

        // Direction of player to target (1 vector3 = 3 values)
        sensor.AddObservation((targetObject.transform.position - transform.position).normalized);

        // Direction of player (1 vector3 = 3 values)
        sensor.AddObservation(transform.forward);

        // Total values = 1 + 3 + 3 = 7 values
    }

    private void FixedUpdate()
    {
        // Automatically RequestDecision every 5 steps
        // In between we need to RequestAction by using previous decisions
        if (StepCount % 5 == 0)
        {
            RequestDecision();
        }
        else
        {
            RequestAction();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Target"))
        {
            CatchTarget(collision.gameObject);
        }
    }

    private void CatchTarget(GameObject collisionObject)
    {
        playerArea.ResetArea();

        AddReward(1f);
        EndEpisode();
    }
}
