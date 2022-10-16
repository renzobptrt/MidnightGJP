using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private Camera cam;
    [SerializeField, Range(1f,20f)] private float rotationSpeed;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] Transform shootPosition;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorldPosition - (Vector2)transform.position;
        transform.up = Vector2.MoveTowards(transform.up, direction, rotationSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Projectile newProjectile = Instantiate(projectilePrefab, shootPosition.position, transform.rotation);
            newProjectile.LaunchProjectile(transform.up);
        }
    }
}
