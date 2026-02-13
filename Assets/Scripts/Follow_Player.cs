using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public Transform Player;
    public Vector3 localOffset = new Vector3(0f, 2f, -6f);
    public bool preferRigidbody = true;

    public float positionSmooth = 0.15f;
    public float rotationSmooth = 12f;

    private Vector3 positionVelocity;
    private Rigidbody playerRigidbody;

    void Awake()
    {
        if (Player != null)
        {
            playerRigidbody = Player.GetComponent<Rigidbody>();
        }
    }

    void LateUpdate()
    {
        if (!Player) return;

        Vector3 targetPos = Player.TransformPoint(localOffset);
        if (preferRigidbody && playerRigidbody != null)
        {
            targetPos = playerRigidbody.transform.TransformPoint(localOffset);
        }

        Quaternion targetRot = Quaternion.LookRotation(Player.position - targetPos, Vector3.up);

        if (positionSmooth <= 0f)
        {
            transform.position = targetPos;
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref positionVelocity, positionSmooth);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSmooth * Time.deltaTime);
    }
}