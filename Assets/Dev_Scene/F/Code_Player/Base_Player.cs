using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    protected bool isGrounded;
    protected Rigidbody2D rb;
    protected Transform playerSprite;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = transform.Find("PlayerSprite");
    }

    protected abstract void HandleMovement();

    protected void Update()
    {
        HandleMovement();
    }

    protected void MovementPlayer(string horizontalInput, string jumpInput)
    {
        float move = Input.GetAxis(horizontalInput);
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown(jumpInput) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (move < 0)
        {
            playerSprite.localScale = new Vector3(-1, 1, 1);
        }
        else if (move > 0)
        {
            playerSprite.localScale = new Vector3(1, 1, 1);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}

