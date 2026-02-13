using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float thrustForce = 20f;
    [SerializeField] private float rotationTorque = 10f;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
{
    var keyboard = Keyboard.current;
    if (keyboard == null) return;

    float rotate = 0f;
    if (keyboard.aKey.isPressed) rotate = -1f;
    if (keyboard.dKey.isPressed) rotate = 1f;

    float thrust = 0f;
    if (keyboard.wKey.isPressed) thrust = 1f;
    if (keyboard.sKey.isPressed) thrust = -1f;

    // Use only the Y rotation so mesh tilt doesn't affect thrust direction
    Vector3 flatForward = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.forward;

    _rb.AddTorque(Vector3.up * (rotate * rotationTorque));
    _rb.AddForce(flatForward * (thrust * thrustForce));
}
}