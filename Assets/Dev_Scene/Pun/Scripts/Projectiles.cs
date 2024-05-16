using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime); // ทำลายโปรเจกไทล์หลังจากที่มันมีอายุการใช้งานถึง
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            // โค้ดทำดาเมจให้มอนสเตอร์
            Destroy(gameObject); // ทำลายโปรเจกไทล์เมื่อชนกับมอนสเตอร์
        }
    }
}
