using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject shieldPrefab;
    public Transform shieldSpawnPoint;
    public float shieldDuration = 3f;
    public float shieldCooldown = 5f;

    private GameObject currentShield;
    private bool canSpawnShield = true;
    private bool canPressSpace = true;

    void Update()
    {
        if (canSpawnShield && canPressSpace && Input.GetKeyDown(KeyCode.Space))
        {
            SpawnShield();
            canPressSpace = false;
        }

        if (currentShield != null)
        {
            Vector3 playerPos = shieldSpawnPoint.position;
            playerPos.z = 0f; // ให้โล่อยู่ในระนาบเดียวกับ Player
            currentShield.transform.position = playerPos;
        }
    }

    void SpawnShield()
    {
        if (!canSpawnShield) return; // ถ้าไม่สามารถสร้างโล่ได้ให้ย้อนกลับ

        currentShield = Instantiate(shieldPrefab, shieldSpawnPoint.position, Quaternion.identity);
        Invoke("DestroyShield", shieldDuration);
        canSpawnShield = false;
        Invoke("ResetCooldown", shieldCooldown);
    }

    void DestroyShield()
    {
        if (currentShield != null)
        {
            Destroy(currentShield);
        }
    }

    void ResetCooldown()
    {
        canSpawnShield = true;
        canPressSpace = true;
    }

}
