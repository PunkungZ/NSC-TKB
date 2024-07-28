using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAWD_MovementTepee : Base_Player
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
        float move = Input.GetAxis("Horizontal1");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump1") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (move < 0)
        {
            playerSprite2.transform.localScale = new Vector3(-0.30174f, 0.30174f, 0.30174f);
        }
        else if (move > 0)
        {
            playerSprite2.transform.localScale = new Vector3(0.30174f, 0.30174f, 0.30174f);
        }
    }

    private void Animation()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AnimationDragon.SetBool("IsWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            AnimationDragon.SetBool("IsWalking", false);
        }

        ////////////////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AnimationDragon.SetBool("IsWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            AnimationDragon.SetBool("IsWalking", false);
        }

        /////////////////////////////////////////////////////////กระโดด
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AnimationDragon.SetBool("IsJumping", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            AnimationDragon.SetBool("IsJumping", false);
        }

        

    }

    
}
