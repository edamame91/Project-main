using UnityEngine;
using UnityEngine.InputSystem;

public class RotationBasedMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float RotateSpeed;


    void Update()
    {

        if (Keyboard.current.wKey.isPressed)
        {
            transform.position += transform.forward * Time.deltaTime * MovementSpeed;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            transform.position -= transform.forward * Time.deltaTime * MovementSpeed;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            transform.Rotate(0, -Time.deltaTime * RotateSpeed, 0);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.Rotate(0, Time.deltaTime * RotateSpeed, 0);
        }
    }
}
