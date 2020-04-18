using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Player_SunDetector))]
public class Player_Controllers : MonoBehaviour
{
    [SerializeField] private Vector3 MoveDir;
    private CharacterController controller;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private float gavitySpeed = 20f;

    private Player_SunDetector detector;

    private float InputX;
    private float InputY;

    private void Awake()
    {
        //Grab the controller
        controller = GetComponent<CharacterController>();
        //Grab the Sun Detector
        detector = GetComponent<Player_SunDetector>();
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

        //Moves the player and slows them when they have low charge
        controller.Move(MoveDir * moveSpeed * detector.Charge * Time.deltaTime);
    }
}
