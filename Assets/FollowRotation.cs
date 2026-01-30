using UnityEngine;

public GameObject followTransform;

public class FollowRotation : MonoBehaviour
{

    public void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(20 * Time.deltaTime, Vector3.up);



    }
}