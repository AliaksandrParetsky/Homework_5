using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent (typeof(MouseLook))]
public class InputManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private MouseLook mouseLook;

    private PlayerController controls;
    private PlayerController.PlayerMovementActions movementActions;

    private Vector2 horizontalInput;
    private Vector2 mouseInput;

    private void Awake()
    {
        controls = new PlayerController();
        movementActions = controls.PlayerMovement;

        movementActions.Movement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        movementActions.Jump.performed += ctx => playerMovement.OnJumpPressed();

        movementActions.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        movementActions.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void Start()
    {
        if (GetComponent<PlayerMovement>() && GetComponent<MouseLook>())
        {
            playerMovement = GetComponent<PlayerMovement>();

            mouseLook = GetComponent<MouseLook>();
        }

    }

    private void Update()
    {
        playerMovement.GetInput(horizontalInput);

        mouseLook.GetInputMouse(mouseInput);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
