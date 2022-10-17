using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody2D body;
    private CharacterController controller;
    
    [SerializeField]private float MoveSpeed;
    [SerializeField]private float jump_force;
    [SerializeField]private float lader_velocity;

    private float move_x = 0;
    private float move_y = 0;
    public float caida = 1;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        body = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        move_x = direction;
    }

    public void Climb(float direction)
    {
        body.velocity = new Vector2(0f, 0f);
        print(direction);
        move_y = direction;
    }

    public void jump()
    {
        body.AddForce(UnityEngine.Vector2.up * jump_force);
    }

    void Update()
    {
        if (caida == 0){
            body.velocity = new Vector2(move_x * MoveSpeed, move_y*lader_velocity);
        }else{
            body.velocity = new Vector2(move_x * MoveSpeed, body.velocity.y);
        }
    }
}
