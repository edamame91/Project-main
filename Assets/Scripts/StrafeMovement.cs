using UnityEngine;
using UnityEngine.InputSystem;

public class StrafeMovement : MonoBehaviour
{
    [SerializeField]
    public float MovementSpeed = 5f;
    void Update()
    {
        Vector3 movementAmount = new Vector3();

        if (Keyboard.current.wKey.isPressed)
        {
            transform.position += new Vector3(0, 0, 1f) * Time.deltaTime * MovementSpeed;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            transform.position += new Vector3(0, 0, -1f) * Time.deltaTime * MovementSpeed;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            transform.position += new Vector3(-1f, 0, 0) * Time.deltaTime * MovementSpeed;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += new Vector3(1f, 0, 0) * Time.deltaTime * MovementSpeed;
        }

        movementAmount.Normalize();
        movementAmount *= MovementSpeed * Time.deltaTime;
        transform.position += movementAmount;
    }
}
