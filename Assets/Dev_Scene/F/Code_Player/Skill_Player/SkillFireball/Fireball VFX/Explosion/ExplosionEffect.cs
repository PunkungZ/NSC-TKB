using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ExplosionEffect : MonoBehaviour
{
    public GameObject explosionPrefab; // Prefab ของ Visual Effect ระเบิด

    public void PlayExplosion(Vector3 position)
    {
        StartCoroutine(PlayExplosionCoroutine(position));
    }

    private IEnumerator PlayExplosionCoroutine(Vector3 position)
    {
        // เล่น Visual Effect ระเบิดที่ตำแหน่งที่กำหนด
        GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);

        // รอจนกว่าจะผ่านไป 3 วินาที
        yield return new WaitForSeconds(3f);

        // ทำลาย Prefab ของ Visual Effect ระเบิด
        Destroy(explosion);
    }


}
