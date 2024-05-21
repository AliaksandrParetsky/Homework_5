using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3.5f;
    [SerializeField] LayerMask groundMasc;

    private Vector2 horizontalInput;
    private Vector3 verticalVelocity = Vector3.zero;
    private CharacterController characterController;
    private bool isGrounded;
    private bool isJump;

    public CharacterController CharacterController
    {
        get
        {
            if (characterController == null)
            {
                characterController = GetComponent<CharacterController>();
            }

            return characterController;
        }
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMasc);
        if (isGrounded)
        {
            verticalVelocity.y = 0;
        }

        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward *
            horizontalInput.y) * speed;
        horizontalVelocity = Vector3.ClampMagnitude(horizontalVelocity, speed);
        CharacterController.Move(horizontalVelocity * Time.deltaTime);

        if (isJump)
        {
            if (isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            isJump = false;
        }

        verticalVelocity.y = verticalVelocity.y + gravity * Time.deltaTime;
        CharacterController.Move(verticalVelocity * Time.deltaTime);
    }

    public void GetInput(Vector2 horInput)
    {
        horizontalInput = horInput;
    }

    public void OnJumpPressed()
    {
        isJump = true;
    }

}
