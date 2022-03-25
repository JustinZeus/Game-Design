using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float _dashSpeed;
    public float _dashTime;
    public Vector3 movementDirection = new Vector3();

    private CharacterController characterController;
    private PlayerStats stats;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        float speed = stats.movement_speed;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = movementDirection.magnitude * speed;

        movementDirection.Normalize();

        characterController.SimpleMove(movementDirection * magnitude);
        
    }

}