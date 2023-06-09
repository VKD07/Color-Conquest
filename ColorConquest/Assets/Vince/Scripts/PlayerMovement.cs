using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] KeyCode moveLeft;
    [SerializeField] KeyCode moveRight;
    [SerializeField] KeyCode jump;

    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float jumpForce = 20f;

    [SerializeField] SpriteRenderer sr;
    [SerializeField] PlayerAnimation playerAnim;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        TriggerJump();
    }

    private void Move()
    {
        if (Input.GetKey(moveRight))
        {
            sr.flipX = false;
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            playerAnim.PlayRunning(true);
        }
        else if (Input.GetKey(moveLeft))
        {
            sr.flipX = true;
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            playerAnim.PlayRunning(true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            playerAnim.PlayRunning(false);
        }
    }

    private void TriggerJump()
    {
        if (Input.GetKeyDown(jump))
        {
            playerAnim.PlayJump();
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
