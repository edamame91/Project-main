using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float RotateSpeed = 10f;
    public float maxHealth = 100f;

    float currentHealth;
    public Material normalMaterial;
    public Material damageMaterial;
    Renderer playerRenderer;
    
    void Start()
    {
        currentHealth = maxHealth;
        playerRenderer = GetComponent<Renderer>();
    }
    
    public void SetDamageVisual(bool takingDamage)
    {
        playerRenderer.material = takingDamage ? damageMaterial : normalMaterial;
    }


    void Update()
    {

        float currentSpeed = movementSpeed;

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
            transform.Rotate(0, -Time.deltaTime * RotateSpeed, 0);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.Rotate(0, Time.deltaTime * RotateSpeed, 0);
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Health: {currentHealth}/{maxHealth}");
    }

    void Die()
    {
        Debug.Log("Player has died!");
        gameObject.SetActive(false);
    }
}
