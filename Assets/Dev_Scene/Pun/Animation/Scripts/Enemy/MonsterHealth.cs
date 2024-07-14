using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
  

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
