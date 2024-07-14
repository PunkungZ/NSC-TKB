using UnityEngine;

public class FanController : MonoBehaviour
{
    public float windStrength = 5f; // ความแรงของลม
    public Vector2 windDirection = Vector2.up; // ทิศทางของลม (ขึ้นข้างบน)
    private bool isPlayerInRange = false; // ตรวจสอบว่าผู้เล่นอยู่ในระยะหรือไม่

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true; // เมื่อผู้เล่นเข้ามาในพื้นที่พัดลม
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false; // เมื่อผู้เล่นออกจากพื้นที่พัดลม
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isPlayerInRange)
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(windDirection.normalized * windStrength);
            }
        }
    }
}
