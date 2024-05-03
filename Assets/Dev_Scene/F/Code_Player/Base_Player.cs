using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    private bool isGrounded;
    private Rigidbody2D rb;

    private GameObject playerSprite1;
    private GameObject playerSprite2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MovementPlayer1()
    {
        playerSprite1 = GameObject.Find("Player1");

        float move = Input.GetAxis("Horizontal1");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump1") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (move < 0)
        {
            playerSprite1.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (move > 0)
        {
            playerSprite1.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void MovementPlayer2()
    {
        playerSprite2 = GameObject.Find("Player2");

        float move = Input.GetAxis("Horizontal2");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump2") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (move < 0)
        {
            playerSprite2.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (move > 0)
        {
            playerSprite2.transform.localScale = new Vector3(1, 1, 1);
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