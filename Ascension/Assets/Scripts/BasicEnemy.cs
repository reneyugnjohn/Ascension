using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Rendering.Universal;

public class BasicEnemy : MonoBehaviour
{
    Transform playerT;
    private Animator anim;
    private SpriteRenderer sprite;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    Vector3 direction;
    bool attack;
    Damageable dmg;



    // Start is called before the first frame update

    void Start()
    {
        playerT = GameObject.FindWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        dmg = GetComponent<Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = playerT.position - transform.position;
        direction.Normalize();
        movement = direction;

        if(dmg.currentHealth <= 0)
        {
            Destroy(gameObject);
            GetComponent<LootBag>().InstantiateLoot(transform.position);
        }
    }

    private void FixedUpdate()
    {
        // moveCharacter(movement);
        UpdateAnimation();
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
            attack = true;
        }
    }

    void UpdateAnimation()
    {
        if (Mathf.Abs(direction.x) > 0f)
        {
            anim.SetFloat("Speed", Mathf.Abs(direction.x));
            if (direction.x < 0f)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
        else if (Mathf.Abs(direction.y) > 0f)
        {
            anim.SetFloat("Speed", Mathf.Abs(direction.y));
        }
        else
        {
            anim.SetFloat("Speed", 0f);
        }

        if (attack)
        {
            anim.SetTrigger("Attack");
            attack = false;
        }
    }
}
