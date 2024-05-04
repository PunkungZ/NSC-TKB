using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFireballSkillData", menuName = "Skill System/Fireball Skill Data")]
public class Fireball : ScriptableObject
{
    public string skillName;
    public GameObject fireballPrefab;
    public float fireballSpeed;
    public float cooldown;
    public Sprite icon;
}
