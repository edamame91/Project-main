using UnityEngine;

public class Rotator : MonoBehaviour
{

    public Vector3 RotateSpeed = new Vector3(1.0f, 1.0f, 1.0f);
    void Update()
    {
        transform.Rotate(RotateSpeed * Time.deltaTime);
    }
}
