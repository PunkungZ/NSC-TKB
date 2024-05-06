using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Base_Player : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float jumpForce = 10f;
    protected bool isGrounded;
    protected Rigidbody2D rb;

    protected GameObject playerSprite1;
    protected GameObject playerSprite2;

    protected bool player1;
    protected bool player2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void MovementPlayerArrow()
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

    protected virtual void MovementPlayer2AWD()
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

    protected virtual void CheckPlayer()
    {
        if(player1 == true)
        {
            MovementPlayerArrow();
        }

        if(player2 == true)
        {
            MovementPlayer2AWD();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            moveSpeed = 2f; // ลดความเร็วเมื่อชนวัตถุ
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            moveSpeed = 5f; // กลับไปยังความเร็วเริ่มต้นเมื่อออกจากการชนวัตถุ
        }
    }




}