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

    private float InputX;
    private float InputY;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        transform.Rotate(0.0f, Input.GetAxis("Horizontal") * turnSpeed, 0.0f);

        //InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxisRaw("Vertical");

        MoveDir = new Vector3(InputX, 0, InputY);
        MoveDir = transform.TransformDirection(MoveDir);

        controller.Move(MoveDir * moveSpeed * Time.deltaTime);
    }
}
