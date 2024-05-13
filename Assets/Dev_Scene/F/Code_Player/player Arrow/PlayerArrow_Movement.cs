using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow_Movement : Base_Player
{
    void Update()
    {
        MovementPlayerArrow();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rb.velocity, 1f); // ตรวจสอบการชนในทิศทางที่ตัวละครกำลังเคลื่อนที่

        if (hit.collider != null && hit.collider.CompareTag("enemy")) // ถ้าชนกับมอนสเตอร์
        {
            Vector2 reflectedDirection = Vector2.Reflect(rb.velocity, hit.normal); // คำนวณทิศทางที่ถูกสะท้อนกลับ
            rb.velocity = reflectedDirection.normalized * moveSpeed; // ตั้งค่าทิศทางเดินใหม่
        }
    }
}

