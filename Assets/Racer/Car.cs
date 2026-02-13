using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Racer : MonoBehaviour
{
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float maxRotateSpeed;


        private Rigidbody rb;

void Start()
    {
       rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        HandleMovement();

        
    }

    private void HandleMovement()
    {
        rb.maxLinearVelocity = maxSpeed;
        rb.maxAngularVelocity = maxRotateSpeed;

        if (Keyboard.current.wKey.isPressed)
        {
            rb.linearVelocity += transform.forward * Time.deltaTime * accelerationSpeed;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            rb.linearVelocity -= transform.forward * Time.deltaTime * accelerationSpeed;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            rb.angularVelocity += Vector3.up * -Time.deltaTime * rotateSpeed;
        }
        

        if (Keyboard.current.dKey.isPressed)
        {
            rb.angularVelocity += Vector3.up * Time.deltaTime * rotateSpeed;
        }
    }


}
