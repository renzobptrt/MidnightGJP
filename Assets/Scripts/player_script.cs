using System.IO.Compression;
using System.Numerics;
using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
public class player_script : MonoBehaviour
{
    private bool is_grounded = false;
    private bool is_ladered = false;
    private bool can_interact = false;
    private bool can_jump = true;

    private Mover mover;
    private Rigidbody2D body;

    private float normal_gravity;
    private float mov_x;
    private float mov_y;

    void Start()
    {
        mover = GetComponent<Mover>();
        body = GetComponent<Rigidbody2D>();
        normal_gravity = body.gravityScale;
    }

    public void OnMove(CallbackContext context)
    {
        mov_x = context.ReadValue<float>();
        mover.Move(mov_x);
    }

    public void interact(CallbackContext context)
    {
        //mov_x = context.ReadValue<float>();
    }

    public void climb(CallbackContext context)
    {
        if(is_ladered)
        {
            mov_y = context.ReadValue<float>();
            mover.Climb(mov_y);
        }else{
            mover.Climb(0);
        }
    }

    public void jump(CallbackContext context)
    {
        
        if (is_grounded && can_jump){
            mover.jump();
            is_grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("ground") && !is_grounded)
        {
            is_grounded = true;
        }
    }

    public void allow_interact()
    {
        can_interact = true;
    }

    public void deny_interact()
    {
        can_interact = false;
    }

    public void deny_climb_ladder()
    {
        is_ladered = false;
        body.gravityScale = normal_gravity;
        can_jump = true;
        mover.caida = 1;
    }

    public void allow_climb_lader()
    {
        is_ladered = true;
        body.gravityScale = 0;
        can_jump = false;
        mover.caida = 0;
    }
}
