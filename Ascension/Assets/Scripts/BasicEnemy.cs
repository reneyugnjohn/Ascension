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
    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    int currentHealth;
    private Rigidbody2D rb;
    private Vector2 movement;
    Vector3 direction;
    bool attack;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
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
        moveCharacter(movement);
        UpdateAnimation();
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void ChangeHealth(int amt)
    {
        currentHealth = Mathf.Clamp(currentHealth + amt, 0, maxHealth);
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
