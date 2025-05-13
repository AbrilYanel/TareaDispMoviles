using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 15f;
    public float detectionRadius = 10f;

    void Update()
    {
        // Disparo al tocar la pantalla
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ShootAtClosestEnemy();
        }
    }

    void ShootAtClosestEnemy()
    {
        // Buscar enemigos en el radio
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius);
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, hit.transform.position);
                if (distance < closestDistance)
                {
                    closestEnemy = hit.transform;
                    closestDistance = distance;
                }
            }
        }

        if (closestEnemy != null)
        {
            Vector3 direction = (closestEnemy.position - transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = direction * projectileSpeed;
            Destroy(projectile, 2f);
        }
    }
}
