using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // ค่าสูงสุดของ HP
    public int currentHealth; // ค่า HP ปัจจุบัน

    public HealthBar healthBar; // อ้างอิงถึง HealthBar เพื่ออัปเดต UI
    private bool isdead; // ตัวแปรเช็คสถานะการตายของผู้เล่น
    public GameManagerScript gameManager; // อ้างอิงถึง GameManagerScript เพื่อเรียกใช้ฟังก์ชัน gameOver

    // ฟังก์ชัน Start จะถูกเรียกใช้เมื่อเริ่มเกม
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // ฟังก์ชัน Update จะถูกเรียกใช้ทุกเฟรม
    void Update()
    {
        // สำหรับการทดสอบ รับดาเมจเมื่อกด Space
        if (Input.GetKeyDown(KeyCode.U))
        {
            TakeDamage(35);
        }

        // เช็คว่า HP หมดแล้วหรือไม่และยังไม่ได้ตาย
        if (currentHealth <= 0 && !isdead)
        {
            isdead = true;
            Time.timeScale = 0f; // หยุดเกม
            Debug.Log("Game Over");
            gameManager.gameOver();
        }
    }

    // ฟังก์ชันลด HP ของผู้เล่น
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    // ฟังก์ชันตรวจจับการชนกับมอนสเตอร์
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            TakeDamage(35); // กำหนดดาเมจที่ได้รับเมื่อชนกับมอนสเตอร์
        }
    }
}
