using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;

    private Rigidbody rBody;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        rBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;

        rBody.velocity += direction * moveSpeed * Time.deltaTime;
    }
}
