using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float sprintMultiplier = 2f;
    private float dashKeyDownTime;

    [SerializeField] private float health = 50f;
    private List<Enemy> enemiesThatWeAreTouching = new List<Enemy>();


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            health += 1;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemiesThatWeAreTouching.Add(enemy);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemiesThatWeAreTouching.Remove(enemy);
            }
        }
    }

    void Update()
    {
        HandleMovement();
        HandleDash();
        HandleEnemyDamage();
    }

    private void HandleMovement()
    {
        float currentSpeed = movementSpeed;
        
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            currentSpeed *= sprintMultiplier;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            transform.position += transform.forward * Time.deltaTime * currentSpeed;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            transform.position -= transform.forward * Time.deltaTime * currentSpeed;
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

    private void HandleDash()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            dashKeyDownTime = Time.time;
        }

        if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            float dashDuration = Mathf.Min(Time.time - dashKeyDownTime, 2f);
            float currentSpeed = movementSpeed;
            
            if (Keyboard.current.leftShiftKey.isPressed)
            {
                currentSpeed *= sprintMultiplier;
            }
            
            float dashDistance = dashDuration * currentSpeed * 5f;
            transform.position += transform.forward * dashDistance;
        }
    }

    private void HandleEnemyDamage()
    {
        foreach (Enemy enemy in enemiesThatWeAreTouching)
        {
            health -= enemy.GetDamage() * Time.deltaTime;
            
            if (health <= 0)
            {
                Destroy(gameObject);
                return;
            }
        }
    }
}
