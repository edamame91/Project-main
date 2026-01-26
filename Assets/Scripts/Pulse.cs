using UnityEngine;

public class Pulse : MonoBehaviour
{

// data

public float PulseSpeed = 1.0f; 
    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one * (Mathf.Sin(Time.time * PulseSpeed) + 1.0f);
    }
}
