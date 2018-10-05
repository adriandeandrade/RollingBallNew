using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float spinSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    private void Start()
    {
        spinSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime * 250);

        if(Vector3.Distance(GameManager.player.transform.position, transform.position) < 15)
        {
            Vector3 directionToPlayer = (GameManager.player.transform.position - transform.position).normalized;
            transform.position = Vector3.Lerp(transform.position, directionToPlayer * 2 * Time.deltaTime, 1);
        }

        print(Vector3.Distance(GameManager.player.transform.position, transform.position));
    }
}
