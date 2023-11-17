using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float maxHealth;
    public float health { get { return currentHealth; } }
    public float currentHealth;
    EnemyHealthbar healthbar;
    bool poisoned;
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

    public void ChangeHealth(float amt)
    {
        currentHealth = Mathf.Clamp(currentHealth + amt, 0, maxHealth);
        healthbar.UpdateHealthbar(currentHealth, maxHealth);
    }

    public void setPoison()
    {
        if (!poisoned)
        {
            poisoned = true;
            StartCoroutine(Poisoned());
        }
    }

    public IEnumerator Poisoned()
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(1.5f);
        ChangeHealth(-0.5f);
        rend.color = Color.green;
        yield return new WaitForSeconds(0.25f);
        rend.color = Color.white;

        yield return new WaitForSeconds(2f);
        ChangeHealth(-0.5f);
        rend.color = Color.green;
        yield return new WaitForSeconds(0.25f);
        rend.color = Color.white;


        poisoned = false;
    }
}
