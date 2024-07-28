using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAWD_MovementDragon : Base_Player
{
    [SerializeField] protected Animator AnimationDragon;

    [SerializeField] protected GameObject playerSprite2;



    private void Update()
    {
        MovementPlayer2AWD();
        Animation();
    }

    protected virtual void MovementPlayer2AWD()
    {
        float move = Input.GetAxis("Horizontal2");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump2") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (move < 0)
        {
            playerSprite2.transform.localScale = new Vector3(-0.2639792f, 0.2639792f, 0.2639792f);
        }
        else if (move > 0)
        {
            playerSprite2.transform.localScale = new Vector3(0.2639792f, 0.2639792f, 0.2639792f);
        }
    }

    private void Animation()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AnimationDragon.SetBool("IsWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            AnimationDragon.SetBool("IsWalking", false);
        }

        ////////////////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.D))
        {
            AnimationDragon.SetBool("IsWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            AnimationDragon.SetBool("IsWalking", false);
        }

        /////////////////////////////////////////////พ่นไฟ
        if (Input.GetKeyDown(KeyCode.L))
        {
            AnimationDragon.SetTrigger("IsSpewFireball");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            AnimationDragon.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
            AnimationDragon.SetBool("IsJumping", true);
        }
    }

}
