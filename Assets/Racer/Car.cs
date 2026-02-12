using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Racer : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotateSpeed;

        private Rigidbody rb;

void Start()
    {
       rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        HandleMovement();

        
    }

    private void HandleMovement()
    {
        float currentSpeed = movementSpeed;

        if (Keyboard.current.wKey.isPressed)
        {
            rb.linearVelocity += transform.forward * Time.deltaTime * currentSpeed;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            rb.linearVelocity -= transform.forward * Time.deltaTime * currentSpeed;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            transform.Rotate(0, -Time.deltaTime * rotateSpeed, 0);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);
        }
    }


}
