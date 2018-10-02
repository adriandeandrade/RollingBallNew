using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float lerpTime;
    [SerializeField] private Vector3 distanceFromPlayer;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        player = gameManager.player;
    }

    private void FixedUpdate()
    {
        if(player != null)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        Vector3 targetPosition = player.transform.position + distanceFromPlayer;
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, lerpTime);

        transform.position = newPosition;
        transform.LookAt(player.transform);
    }
}
