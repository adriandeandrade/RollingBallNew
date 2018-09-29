using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float lerpTime;
    [SerializeField] private Vector3 distanceFromPlayer;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 targetPosition = player.transform.position + distanceFromPlayer;
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, lerpTime);

        transform.position = newPosition;
        transform.LookAt(player.transform);


        //Vector3 currentPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        //Vector3 newPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        //transform.position = Vector3.Lerp(currentPos, newPos, lerpTime);
    }

}
