using System.Net;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        transform.position = Player.transform.position + new Vector3(0, 1, -5);
    }

}