using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            // Si el jugador est� cayendo (velocidad hacia abajo)
            if (rb != null && rb.velocity.y <= 0f)
            {
                // Activar colisi�n moment�neamente
                Collider platformCollider = GetComponent<Collider>();
                platformCollider.isTrigger = false;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Desactivar colisi�n nuevamente para que se pueda subir desde abajo
            Collider platformCollider = GetComponent<Collider>();
            platformCollider.isTrigger = true;
        }
    }
}
