using UnityEngine;

public class Mover : MonoBehaviour
{
public float MoveSpeed = 1.0f;
    void Update()
    {
        transform.position += new Vector3(MoveSpeed, 0, 0);
    }
}
