using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform player;
    public Transform shotPoint;
    public Transform gun;
    public GameObject bullet;

    public bool canFire;
    private float timer;
    public float timeBetweenFiring = 5f;
    Damageable dmg;

    void Start()
    {
        dmg = GetComponent<Damageable>();
    }

    void Update()
    {
        Vector3 difference = player.position - gun.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        if (canFire)
        {
            canFire = false;
            Fire();
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
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
}
