using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_cntrl : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool is_on_ground;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask WhatIsGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            rotate();
        }
        else if (facingRight == true && moveInput < 0)
        {
            rotate();
        }


    }
    private void jump()
    {
        is_on_ground = Physics2D.OverlapCircle(feetPos.position, checkRadius, WhatIsGround);

        if(is_on_ground == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce; 
        }
    }

    private void rotate()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
