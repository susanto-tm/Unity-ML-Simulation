using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetMovement : MonoBehaviour
{

    NavMeshAgent navMeshAgent;
    public float newPathTime;
    bool inCoroutine = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(0, 20);
        float z = Random.Range(0, 20);

        return new Vector3(x, 0, z);

    }

    IEnumerator Wait()
    {
        inCoroutine = true;
        yield return new WaitForSeconds(newPathTime);
        GetNewPath();
        inCoroutine = false;

    }

    void GetNewPath()
    {
        navMeshAgent.SetDestination(GetRandomPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if (!inCoroutine)
        {
            StartCoroutine(Wait());
        }
        
    }
}
