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
        //Cambiar input de boton
        if (isAbleToShoot && Input.GetKeyDown(KeyCode.Space))
        {
            Projectile newProjectile = Instantiate(projectilePrefab, shootPosition.position, transform.rotation);
            newProjectile.LaunchProjectile(transform.up);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isAbleToShoot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAbleToShoot = false;
        }
    }

    private bool isAbleToShoot = false;
}
