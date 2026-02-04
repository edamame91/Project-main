using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float damage = 1f;

    void Start()
    {
        Debug.Assert(target != null, "Target not assigned in Enemy script");
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    public float GetDamage()
    {
        return damage;
    }
}
