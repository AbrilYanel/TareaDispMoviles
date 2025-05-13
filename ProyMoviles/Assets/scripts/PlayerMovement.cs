using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;

    private Rigidbody rb;

    public float xLimit = 1f; // Limite horizontal antes de reaparecer del otro lado

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento con acelerómetro
        float tiltX = Input.acceleration.x;
        rb.velocity = new Vector3(tiltX * moveSpeed, rb.velocity.y, 0);

        // Wrap horizontal
        if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") && rb.velocity.y <= 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        }
    }
}
