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
        if (GameManager.sharedInstance.gameState == GameState.inGame)
        {
            if (GetAwakeEnemy())
            {
                moveEnemy(movement);
            }
        }
    }

    void moveEnemy(Vector2 direction)
    {
        print("Intento moverme");
        rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);
        //rb.MovePosition(new Vector2(transform.position.x + (direction.x * moveSpeed * Time.deltaTime),transform.position.y));
        
    }

    private Vector2 movement = Vector2.zero;
}
