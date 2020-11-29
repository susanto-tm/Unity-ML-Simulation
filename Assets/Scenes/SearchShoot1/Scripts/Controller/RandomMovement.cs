using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{

    public float waitTime;
    bool inMovement = false;
    NavMeshAgent nma;

    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    Vector3 GetRandomPath()
    {
        float x = Random.Range(-6, 6);
        float z = Random.Range(14, 26);

        return new Vector3(x, 0, z);
    }

    IEnumerator Wait()
    {
        inMovement = true;
        yield return new WaitForSeconds(waitTime);
        GetPath();
        inMovement = false;
    }

    void GetPath()
    {
        nma.SetDestination(GetRandomPath());
    }

    // Update is called once per frame
    void Update()
    {
        if (!inMovement)
        {
            StartCoroutine(Wait());
        }
    }
}
