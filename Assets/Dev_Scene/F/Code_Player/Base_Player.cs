using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    private bool isGrounded;
    private Rigidbody2D rb;
    private GameObject playerSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GameObject.Find("Player1");
    }

    void Update()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (move < 0)
        {
            playerSprite.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (move > 0)
        {
            playerSprite.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}