using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controllers : MonoBehaviour
{
    [SerializeField] private Vector3 MoveDir;
    private CharacterController controller;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private float gavitySpeed = 20f;

    private float InputX;
    private float InputY;

    private void Awake()
    {
        //Grab the controller
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        //Rotate the player based on input
        transform.Rotate(0.0f, Input.GetAxis("Horizontal") * turnSpeed, 0.0f);

        //InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxis("Vertical");

        //Move the player
        MoveDir = new Vector3(InputX, -gavitySpeed, InputY);
        MoveDir = transform.TransformDirection(MoveDir);

        controller.Move(MoveDir * moveSpeed * Time.deltaTime);
    }
}
