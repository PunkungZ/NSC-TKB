using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oop : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    private bool isGrounded;
    private Rigidbody2D rb;

    private GameObject playerSprite1;

    private string w = "Horizontal1";
    private string s = "Player1";
    private string a = "Jump1";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void MovementPlayer1()
    {
        playerSprite1 = GameObject.Find(s);

        float move = Input.GetAxis(w);
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown(a) && isGrounded)
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
