using UnityEngine;

public class Monster : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(20f); 
            Destroy(collision.gameObject); 
            
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * 5f; 
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject); // ทำลายมอนสเตอร์
    }
}