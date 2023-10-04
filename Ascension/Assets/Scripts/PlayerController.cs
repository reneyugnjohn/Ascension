using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private float moveSpeed = 7f;
    private Vector2 moveDirection;
    float moveX;
    float moveY;
    bool roll;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
        UpdateAnimation();
    }

    void ProcessInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Space) && (Mathf.Abs(moveX) > 0f || Mathf.Abs(moveY) > 0f))
        {
            roll = true;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        if (roll)
        {
            rb.AddForce(moveDirection * 500f, ForceMode2D.Force);
        }
        else
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }

    void UpdateAnimation()
    {
        if (Mathf.Abs(moveX) > 0f)
        {
            anim.SetFloat("Speed", Mathf.Abs(moveX));
            if (moveX < 0f)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
        else if (Mathf.Abs(moveY) > 0f)
        {
            anim.SetFloat("Speed", Mathf.Abs(moveY));
        }
        else
        {
            anim.SetFloat("Speed", 0f);
        }

        if (roll)
        {
            anim.SetTrigger("Roll");
            roll = false;
        }
    }
}