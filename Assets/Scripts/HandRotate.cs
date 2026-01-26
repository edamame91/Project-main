using Unity.Mathematics;
using UnityEngine;

public class HandRotate : MonoBehaviour
{
    public Vector3 RotateSpeed = new Vector3(1.0f, 1.0f, 1.0f);

    void Update()
    {
        transform.Rotate(RotateSpeed * Time.deltaTime);
    }

}
