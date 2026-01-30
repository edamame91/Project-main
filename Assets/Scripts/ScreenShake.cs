using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class ScreenShake : MonoBehaviour
{
    public float Cooldown = 0.5f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (Cooldown > 0)
        {
            Cooldown -= Time.deltaTime;
            Cooldown = Mathf.Clamp(Cooldown, 0, float.MaxValue);

            transform.position = originalPosition + Random.insideUnitSphere * 0.5f;
        }
        else
        {
            transform.position = originalPosition;
        }

        if (Keyboard.current.xKey.isPressed)
        {
            Cooldown = 1.0f;
        }
    }
}
