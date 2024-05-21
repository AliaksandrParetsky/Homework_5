using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] float sensivityX = 10f;
    [SerializeField] float sensivityY = 0.5f;

    private float mouseX;
    private float mouseY;
    private float xClamp = 10f;
    private float xRotation = 0f;

    private void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation = xRotation - mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;

    }

    public void GetInputMouse(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensivityX;
        mouseY = mouseInput.y * sensivityY;
    }
}
