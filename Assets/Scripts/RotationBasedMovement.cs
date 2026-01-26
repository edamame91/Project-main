using UnityEngine;
using UnityEngine.InputSystem;

public class RotationBasedMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float RotateSpeed;
    [SerializeField] private float SprintMultiplier = 2f;
    private float DashKeyDownTime;

    void Update()
    {
        float currentSpeed = MovementSpeed;
        
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            currentSpeed *= SprintMultiplier;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            transform.position += transform.forward * Time.deltaTime * currentSpeed;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            transform.position -= transform.forward * Time.deltaTime * currentSpeed;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            transform.Rotate(0, -Time.deltaTime * RotateSpeed, 0);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.Rotate(0, Time.deltaTime * RotateSpeed, 0);
        }

        // Dash
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            DashKeyDownTime = Time.time;
        }

        if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            float dashDuration = Time.time - DashKeyDownTime;
            if (dashDuration > 2f)
            {
                dashDuration = 2f; // Cap the dash duration
            }
            float dashDistance = dashDuration * currentSpeed * 5f; // Dash speed multiplier
            transform.position += transform.forward * dashDistance;
        }
    }
}
