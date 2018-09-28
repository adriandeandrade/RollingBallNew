using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float lerpTime;

    private float currentX, currentY, currentZ;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        currentX = transform.position.x;
        currentY = transform.position.y;
        currentZ = transform.position.z;
    }

    private void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 currentPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        Vector3 newPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(currentPos, newPos, lerpTime);
    }

}
