using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePile : MonoBehaviour
{
    [SerializeField] int maxHealth;
    private int currentHealth;
    [SerializeField] GameObject enemies;
    [SerializeField] GameObject skeleton;
    [SerializeField] GameObject healthPot;
    [SerializeField] GameObject multiShot;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Spawn();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Projectile arrow = other.gameObject.GetComponent<Projectile>();
        if (arrow != null)
        {
            currentHealth--;
        }
    }

    void Spawn()
    {
        int num = Random.Range(1, 101);
        //85% chance for skeleton to spawn
        if (num <= 85)
            Instantiate(skeleton, transform.position, Quaternion.identity, enemies.transform);
        else
        {
            //10% chance for health potion
            if(num <=95)
            {
                Instantiate(healthPot, transform.position, Quaternion.identity);
            }
            //5% chance for skill
            else
            {
                //for now only spawn multishot but later change to make it a random skill drop
                Instantiate(multiShot, transform.position, Quaternion.identity);
            }

        }
    }
}
