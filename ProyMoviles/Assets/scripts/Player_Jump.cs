using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión es con una plataforma
        if (collision.gameObject.CompareTag("Platform"))
        {
            // Asegura que el contacto viene desde abajo
            foreach (ContactPoint contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    Jump();
                    break;
                }
            }
        }
    }

    void Jump()
    {
        // Reinicia la velocidad vertical antes de saltar
        rb.velocity = new Vector3(rb.velocity.x, 0f, 0f);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
