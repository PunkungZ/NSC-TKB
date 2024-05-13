using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback_Fireball : MonoBehaviour
{
    [SerializeField] protected float knockbackForce = 500f;
    [SerializeField] protected float knockbackDuration = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Rigidbody2D enemyRigidbody = collision.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                StartCoroutine(KnockbackCoroutine(collision.transform, knockbackDirection, knockbackForce, knockbackDuration));
                Destroy(gameObject);
            }
        }

    }

    public IEnumerator KnockbackCoroutine(Transform enemyTransform, Vector2 knockbackDirection, float knockbackForce, float knockbackDuration)
    {
        float timer = 0f;
        Rigidbody2D enemyRigidbody = enemyTransform.GetComponent<Rigidbody2D>();
        enemyRigidbody.velocity = Vector2.zero; // หยุดความเร็วของ Enemy ก่อนที่จะ Knockback
        while (timer < knockbackDuration)
        {
            timer += Time.deltaTime;
            float knockbackSpeed = Mathf.Lerp(0, knockbackForce, timer / knockbackDuration);
            enemyRigidbody.AddForce(knockbackDirection * knockbackSpeed);

            // เพิ่มการกระเดนขึ้นข้างบน
            float bounceAmount = 0.7f; // ความสูงของการกระเดน
            Vector2 bounceVector = new Vector2(0f, bounceAmount);
            enemyTransform.Translate(bounceVector);

            yield return null;
        }
    }

}
