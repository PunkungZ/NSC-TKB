using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect_Bullet : MonoBehaviour
{
    public ExplosionEffect explosionEffect; // Script ของ Visual Effect ระเบิด

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            // เล่น Visual Effect ระเบิดที่ตำแหน่งของกระสุน
            explosionEffect.PlayExplosion(transform.position);

            // ทำลายกระสุน
            Destroy(gameObject);
        }
    }

}
