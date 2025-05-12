using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Bloquear movimiento en eje Z para simular 2D
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
    }

    void Update()
    {
        Vector3 tilt = Input.acceleration;

        // Movimiento horizontal basado en inclinación del teléfono
        Vector3 move = new Vector3(tilt.x, 0f, 0f);
        rb.velocity = new Vector3(move.x * moveSpeed, rb.velocity.y, 0f);
    }
}
