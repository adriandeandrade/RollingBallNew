using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rBody;
    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpAmount;

    public Spawner spawner;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CameraShaker cameraShaker;

    [SerializeField] private GameObject collisionEffect;
    [SerializeField] private GameObject enemyCollisionEffect;
    [SerializeField] private GameObject coinCollectEffect;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        spawner = FindObjectOfType<Spawner>();
        cameraShaker = Camera.main.gameObject.GetComponent<CameraShaker>();
    }

    private void FixedUpdate()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            rBody.velocity += Vector3.forward * moveSpeed * Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            rBody.velocity += Vector3.back * moveSpeed * Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            rBody.velocity += Vector3.left * moveSpeed * Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            rBody.velocity += Vector3.right * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            gameManager.coins++;
            GameObject effect = Instantiate(coinCollectEffect, other.transform.position, Quaternion.identity);
            Destroy(effect, 2.0f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.DamagePlayer(1);
            GameObject effect = Instantiate(collisionEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2.0f);
            GameObject effect2 = Instantiate(enemyCollisionEffect, other.transform.position, Quaternion.identity);
            Destroy(effect2, 2.0f);
            cameraShaker.ShakeCamera();
        }
    }
}
