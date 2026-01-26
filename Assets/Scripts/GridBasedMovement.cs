using UnityEngine;
using UnityEngine.InputSystem;

public class GridBasedMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 TargetPosition;

    [SerializeField]
    private float MoveSpeed;

    void Start()
    {
        TargetPosition = transform.position;
    }

    void Update()
    {

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            TargetPosition += new Vector3(0, 0, 1f);
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            TargetPosition -= new Vector3(0, 0, 1f);
        }

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            TargetPosition -= new Vector3(1f, 0, 0);
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            TargetPosition += new Vector3(1f, 0, 0);
        }

        transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * MoveSpeed);
    }
}
