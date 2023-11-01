using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform player;
    public Transform shotPoint;
    public Transform gun;
    public GameObject bullet;
    private SpriteRenderer sprite;
    Vector3 direction;

    public bool canFire;
    private float timer;
    public float timeBetweenFiring = 5f;
    public float atkRange;
    Damageable dmg;

    void Start()
    {
        dmg = GetComponent<Damageable>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 difference = player.position - gun.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        direction = player.position - transform.position;
        direction.Normalize();
        UpdateAnimation();

        //If enemy is ready to fire and player is in range
        if (canFire && Vector2.Distance(transform.position, player.position) <= atkRange)
        {
            timer = 0;
            canFire = false;
            Fire();
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
            } 
        }

        if (dmg.currentHealth <= 0)
        {
            Destroy(gameObject);
            GetComponent<LootBag>().InstantiateLoot(transform.position);
        }
    }

    void Fire()
    {
        Instantiate(bullet, shotPoint.position, shotPoint.transform.rotation);

    }

    //Draws a circle to help see what his range is
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, atkRange);
    }

    void UpdateAnimation()
    {
        if (Mathf.Abs(direction.x) > 0f)
        {
            if (direction.x > 0f)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
    }
}