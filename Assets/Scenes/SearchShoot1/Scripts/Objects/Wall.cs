using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    public GameObject nextBoundary;

    private Vector3 v3_distance;
    private Vector3 v3_nextend1;
    private Vector3 v3_nextend2;
    private Vector3 v3_nexthalflength;
    private Vector3 v3_thisend1;
    private Vector3 v3_thisend2;
    private Vector3 v3_thishalflength;

    void Awake()
    {
        //hide this fence post
        Destroy(GetComponent<MeshRenderer>());

        //is there another fence post?
        if (nextBoundary != null)
        {

            //get Vector3's that are half the length of the fence pole heights, with the same rotations
            v3_thishalflength = transform.TransformDirection(Vector3.up * transform.localScale.y / 2);
            v3_nexthalflength = nextBoundary.transform.TransformDirection(Vector3.up * nextBoundary.transform.localScale.y / 2);

            //get the Vector3 that's the distance  direction between these two fence posts
            v3_distance = nextBoundary.transform.position - transform.position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
