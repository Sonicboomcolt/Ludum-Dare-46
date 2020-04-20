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

    [Header("Audio")]
    [SerializeField] private AudioSource source;


    private void Awake()
    {
        //Grab the controller
        controller = GetComponent<CharacterController>();
        //Grab the Sun Detector
        detector = GetComponent<Player_SunDetector>();

        source.volume = 0;
        source.pitch = 0;
    }

    private void FixedUpdate()
    {
        //Rotate the player based on input
        transform.Rotate(0.0f, Input.GetAxis("Horizontal") * turnSpeed * detector.Charge, 0.0f);

        //InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxis("Vertical");

        //Move the player
        MoveDir = new Vector3(InputX, -gavitySpeed, InputY);
        MoveDir = transform.TransformDirection(MoveDir);

        //Moves the player and slows them when they have low charge
        controller.Move(MoveDir * moveSpeed * detector.Charge * Time.deltaTime);

        float volSpeed = Mathf.Clamp(controller.velocity.magnitude, 0, 1);
        float pitchSpeed = controller.velocity.magnitude;

        source.volume = Mathf.Lerp(source.volume, volSpeed, Time.deltaTime * 5);
        source.pitch = Mathf.Lerp(source.volume, pitchSpeed, Time.deltaTime * 5);
    }
}
