using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BasicEnemy : MonoBehaviour
{
    public Transform player;
    private Animator anim;
    private SpriteRenderer sprite;
    public float moveSpeed = 5f;
    public float maxHealth;
    public float health { get { return currentHealth; } }
    float currentHealth;
    private Rigidbody2D rb;
    private Vector2 movement;
    Vector3 direction;
    bool attack;
    EnemyHealthbar healthbar;

    // Start is called before the first frame update

  /*  void Awake()
    {
        healthbar = GetComponentInChildren<EnemyHealthbar>();
    }*/

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        healthbar = GetComponentInChildren<EnemyHealthbar>();
        healthbar.UpdateHealthbar(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
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

    public void ChangeHealth(int amt)
    {
        currentHealth = Mathf.Clamp(currentHealth + amt, 0, maxHealth);
        healthbar.UpdateHealthbar(currentHealth, maxHealth);
    }

    public void OnHit(Vector2 knockback)
    {
        rb.AddForce(knockback, ForceMode2D.Impulse);
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
