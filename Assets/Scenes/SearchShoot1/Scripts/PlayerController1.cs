using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController1: MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public CharacterController controller;
    public float gravityScale;

    public Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, 0f, Input.GetAxis("Vertical") * speed);

        moveDirection.y += Physics.gravity.y * gravityScale;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
