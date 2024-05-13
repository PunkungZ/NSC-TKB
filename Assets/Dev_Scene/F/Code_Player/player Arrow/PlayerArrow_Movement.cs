using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow_Movement : Base_Player
{
    [SerializeField] protected GameObject playerSprite1;

    private void Update()
    {
        MovementPlayerArrow();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rb.velocity, 1f); // ตรวจสอบการชนในทิศทางที่ตัวละครกำลังเคลื่อนที่

        if (hit.collider != null && hit.collider.CompareTag("enemy")) // ถ้าชนกับมอนสเตอร์
        {
            Vector2 reflectedDirection = Vector2.Reflect(rb.velocity, hit.normal); // คำนวณทิศทางที่ถูกสะท้อนกลับ
            rb.velocity = reflectedDirection.normalized * moveSpeed; // ตั้งค่าทิศทางเดินใหม่
        }
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
}

