using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float gravityScale;
    CharacterController cc;

    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        this.transform.position = new Vector3(Random.Range(-6, 6), 3.16f, Random.Range(14, 26));
    }

    private void OnTriggerEnter(Collider other)
    {
        print("This is working.");
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, 0f, Input.GetAxis("Vertical") * speed);

        moveDirection.y += (Physics.gravity.y * gravityScale);

        cc.Move(moveDirection * Time.deltaTime);

    }
}
