using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public Fireball fireballSkillData;
    protected Rigidbody2D rb;

    private float lastUsedTime;

    public bool CanUseSkill()
    {
        return Time.time - lastUsedTime >= fireballSkillData.cooldown;
    }

    public void UseSkill()
    {
        if (CanUseSkill())
        {
            GameObject fireball = Instantiate(fireballSkillData.fireballPrefab, transform.position, transform.rotation);
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = transform.forward * fireballSkillData.fireballSpeed;
                rb.useGravity = false; // ไม่ให้ fireball ตกตามแรงโน้มถ่วง
            }

            lastUsedTime = Time.time;
        }
    }

}
