using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float MoveSpeed = 0.5f;

    void Start()
    {
        Debug.Assert(target != null, "Target not assigned in Enemy script");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
    }
}
