using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rBody;
    public int moveSpeed;

    public Spawner spawner;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        spawner = FindObjectOfType<Spawner>();
    }

    private void FixedUpdate()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rBody.velocity += Vector3.forward * moveSpeed * Time.fixedDeltaTime;
            //rBody.AddTorque(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rBody.velocity += Vector3.back * moveSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rBody.velocity += Vector3.left * moveSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rBody.velocity += Vector3.right * moveSpeed * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            spawner.SpawnEnemy(5);
        }

        
    }
}
