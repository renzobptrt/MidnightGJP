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
            Direccion();
            Run(currentSpeed);
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

    private Vector2 movement = Vector2.zero;
}
