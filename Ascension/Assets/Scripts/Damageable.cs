using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float maxHealth;
    public float health { get { return currentHealth; } }
    public float currentHealth;
    EnemyHealthbar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar = GetComponentInChildren<EnemyHealthbar>();
        healthbar.UpdateHealthbar(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(int amt)
    {
        currentHealth = Mathf.Clamp(currentHealth + amt, 0, maxHealth);
        healthbar.UpdateHealthbar(currentHealth, maxHealth);
    }
}
