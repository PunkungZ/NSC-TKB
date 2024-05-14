using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow_Movement : Base_Player
{
    [SerializeField] protected GameObject playerSprite1;

    private void Update()
    {
        MovementPlayerArrow();
    }

    protected virtual void MovementPlayerArrow()
    {
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
}

