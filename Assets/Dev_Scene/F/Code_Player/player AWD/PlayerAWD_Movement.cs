using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAWD_Movement : Base_Player
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
            playerSprite2.transform.localScale = new Vector3(-0.5741891f, 0.5741891f, 0.5741891f);
        }
        else if (move > 0)
        {
            playerSprite2.transform.localScale = new Vector3(0.5741891f, 0.5741891f, 0.5741891f);
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

        /////////////////////////////////////////////////////////กระโดด
        if (Input.GetKeyDown(KeyCode.W))
        {
            AnimationDragon.SetBool("IsJumping", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            AnimationDragon.SetBool("IsJumping", false);
        }

        /////////////////////////////////////////////พ่นไฟ
        if (Input.GetKeyDown(KeyCode.L))
        {
            AnimationDragon.SetTrigger("IsSpewFireball");
        }

    }

    
}
