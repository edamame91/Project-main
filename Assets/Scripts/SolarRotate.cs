using UnityEngine;

public class SolarRotate : MonoBehaviour
{
public float RotateSpeed = 0f;
    void Update()
    {
        transform.Rotate(0, 0, 1 * RotateSpeed);
    }
}
