using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivaOffCam : MonoBehaviour
{
    public GameObject visual; // Asigná aquí el hijo visual desde el Inspector
    private Camera mainCamera;
    private Renderer rend;

    void Start()
    {
        mainCamera = Camera.main;
        rend = visual.GetComponent<Renderer>();
    }

    void Update()
    {
        if (IsVisibleFrom(rend, mainCamera))
        {
            if (!visual.activeSelf)
                visual.SetActive(true);
        }
        else
        {
            if (visual.activeSelf)
                visual.SetActive(false);
        }
    }

    bool IsVisibleFrom(Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}
