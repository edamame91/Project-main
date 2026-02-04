using UnityEngine;


public class FollowRotation : MonoBehaviour
{
public GameObject followTransform;

    public void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(20 * Time.deltaTime, Vector3.up);



    }
}