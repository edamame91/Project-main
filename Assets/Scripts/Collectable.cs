using Unity.VisualScripting;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    [SerializeField] public float PulseSpeed = 3.0f;
    private Vector3 startSize;
    
    void Start()
    {
        startSize = transform.localScale;
    }
    
    void Update()
    {

        // rotate around the y axis
        transform.Rotate(0, 70  * Time.deltaTime, 0);

        // pulse the size
        transform.localScale = (1 + Mathf.Sin(Time.time * PulseSpeed) * 0.2f) * startSize;

        // bob up and down
        Vector3 position = transform.position;
        position.y = 0.5f + Mathf.Sin(Time.time * PulseSpeed) * 0.15f;
        transform.position = position;
    }
}
