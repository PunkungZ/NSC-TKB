using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float damage = 50f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MonsterHealth monster = collision.GetComponent<MonsterHealth>();
        if (monster != null)
        {
            monster.TakeDamage(damage);
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * 5f; // ตั้งค่าความเร็วของมอนสเตอร์ให้มันเด้งกลับ
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
