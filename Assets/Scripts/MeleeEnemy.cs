using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyController
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
    }
   
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (GetAwakeEnemy())
        {
            if (rg2d.velocity.x > -0.01f && rg2d.velocity.x < 0.01f)
            {
                currentSpeed = -currentSpeed;
            }
            
            if (GetIsAlive())
            {
                Direccion();
                Run(currentSpeed);
            }
        }
    }

    void Run(float velocity)
    {
        rg2d.velocity = new Vector2(velocity, rg2d.velocity.y);
    }

    void Direccion()
    {
        if (currentSpeed > 0.1f)
        {
            rg2d.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (currentSpeed < -0.1f)
        {
            rg2d.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //otherCollider.GetComponent<PlayerContoller>().GetDamage();
            Die();
        }

        else if (collision.gameObject.tag == "Vehicle")
        {
            collision.transform.GetComponent<Vehicle>().GetDamage(damageValue);
            Die();
        }

        if (collision.gameObject.tag == "Projectile")
        {
            Die();
        }
    }

    void Die()
    {
        collider.isTrigger = true;
        rg2d.bodyType = RigidbodyType2D.Static;
        DieEnemy();
        animatorController.SetTrigger("Die");
        Destroy(gameObject, 0.5f);
    }

    private Vector2 movement = Vector2.zero;
}
