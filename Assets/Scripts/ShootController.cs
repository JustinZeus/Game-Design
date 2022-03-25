using System;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private Transform aimedTransform;
    public Vector3 direction;
    
     
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        aimedTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            direction = position - transform.position;

            // You might want to delete this line.
            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            aimedTransform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var projectile = Instantiate(projectilePrefab, transform.position + Vector3.Scale(direction.normalized,  new Vector3(1.0f,1.0f,1.0f)), Quaternion.identity);
            var rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Vector3.Scale(direction.normalized, new Vector3(8.0f,8.0f,8.0f));
        }
    }

}
