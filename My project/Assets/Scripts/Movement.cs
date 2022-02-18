using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float _dashSpeed;
    public float _dashTime;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = movementDirection.magnitude * speed;

        movementDirection.Normalize();

        characterController.SimpleMove(movementDirection * magnitude);

         if (Input.GetButtonDown("Jump"))
        {
            // dash
        }
        
    }

}