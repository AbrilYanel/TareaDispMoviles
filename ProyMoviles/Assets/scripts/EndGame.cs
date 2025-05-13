using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    public float finishLine = 80;
    public Rigidbody rb;
    public float xLimit = 5f;

    private float maxHeightReached = 0f;
    public float deathThreshold = 10f; // Distancia que debe caer debajo del máximo para perder

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxHeightReached = transform.position.y;
    }

    void Update()
    {
        // Movimiento con acelerómetro
        float tiltX = Input.acceleration.x;
        rb.velocity = new Vector3(tiltX * moveSpeed, rb.velocity.y, 0);

        // Wrapping horizontal
        if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }

        // Actualizar altura máxima alcanzada
        if (transform.position.y > maxHeightReached)
        {
            maxHeightReached = transform.position.y;
        }

        // Comprobar si cayó por debajo del umbral permitido
        if (transform.position.y < maxHeightReached - deathThreshold)
        {
            Die();
        }

        if(transform.position.y >= finishLine)
        {
            Win();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") && rb.velocity.y <= 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        }
    }

    void Die()
    {
        // Reiniciar escena (puedes reemplazar esto con una pantalla de Game Over si querés)
        SceneManager.LoadScene(0);
    }

    void Win()
    {
        Time.timeScale = 0f;
        Debug.Log("¡Ganaste!");
    }
}
