using UnityEngine;
using UnityEngine.InputSystem;

public class Follow_Player : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset = new Vector3(0f, 2f, -4f);

    public float yawSpeed = 120f;
    public float pitchSpeed = 80f;
    public float minPitch = -30f;
    public float maxPitch = 60f;

    public float positionSmooth = 10f;
    public float rotationSmooth = 12f;

    private float yaw;
    private float pitch;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (!Player) return;

        Vector2 mouseDelta = Mouse.current != null ? Mouse.current.delta.ReadValue() : Vector2.zero;

        yaw += mouseDelta.x * yawSpeed * Time.deltaTime;
        pitch -= mouseDelta.y * pitchSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion targetRot = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 targetPos = Player.position + targetRot * offset;

        transform.position = Vector3.Lerp(transform.position, targetPos, positionSmooth * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSmooth * Time.deltaTime);
    }
}