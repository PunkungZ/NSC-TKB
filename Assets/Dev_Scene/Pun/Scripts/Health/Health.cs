﻿
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    

    private bool dead;

    private bool isdead;
    public Animator sceneAnimator;

    
    public GameManagerScript gameManager;

    

    private void Awake()
    {
        currentHealth = startingHealth;
        
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            
            //iframes
        }
        else
        {
            if (!dead)
            {
                
                GetComponent<Player>().enabled = false;
                dead = true;
            }
        }
        
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void Update()
    {
        if (currentHealth <= 0 && !isdead)
        {
            isdead = true;
            
            Time.timeScale = 0f; // หยุดการเล่นของเกม
            Debug.Log("Game Over");
            gameManager.gameOver();
            
        }
    }

    

}