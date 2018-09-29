using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rBody;
    public int moveSpeed;

    public Spawner spawner;
    [SerializeField] private GameManager gameManager;

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
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rBody.velocity += Vector3.forward * moveSpeed * Time.fixedDeltaTime;
            //rBody.AddTorque(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rBody.velocity += Vector3.back * moveSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rBody.velocity += Vector3.left * moveSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rBody.velocity += Vector3.right * moveSpeed * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Enemy"))
        {
            gameManager.DamagePlayer(1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.DamagePlayer(1);
        }
    }
}
