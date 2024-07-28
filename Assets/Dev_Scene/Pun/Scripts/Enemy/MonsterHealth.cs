using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Monster HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // ทำสิ่งที่ต้องการเมื่อมอนสเตอร์ตาย
        Destroy(gameObject);
    }
}
