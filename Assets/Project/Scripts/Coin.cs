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
    }
}
