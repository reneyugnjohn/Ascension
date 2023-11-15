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

    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    public int currentHealth;
    bool isInvincible;
    float invincibleTimer;
    public float hurtDelay = 1.0f;

    [SerializeField] private float moveSpeed = 7f;
    private Vector2 moveDirection;
    float moveX;
    float moveY;
    public bool rolling;

    public GameOverScreen gameOver;

    public GameObject bow;

    public ParticleSystem dust;

    private CameraController camController;
    private changeLight lightScript;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        camController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        lightScript = GameObject.FindGameObjectWithTag("light").GetComponent<changeLight>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        if (currentHealth <= 0)
        {
            gameOver.Setup();
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        UpdateAnimation();

    }

    void FixedUpdate()
    {
        Move();
        
    }

    void ProcessInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Space) && (Mathf.Abs(moveX) > 0f || Mathf.Abs(moveY) > 0f))
        {
            rolling = true;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        if (rolling)
        {
            //createDust();
            rb.AddForce(moveDirection * 50f, ForceMode2D.Force);
        }
        else
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

            bool isMoving = Mathf.Abs(moveDirection.x) > 0f || Mathf.Abs(moveDirection.y) > 0f;

            if (isMoving)
            {
                createDust();
            }
        }
    }

    void UpdateAnimation()
    {

        if (bow.transform.position.x < transform.position.x)
        {
            sprite.flipX = true;
            
        }
        else
        {
            sprite.flipX = false;
        }


        if (Mathf.Abs(moveX) > 0f)
        {
            
            anim.SetFloat("Speed", Mathf.Abs(moveX));
            
        }
        else if (Mathf.Abs(moveY) > 0f)
        {
            
            anim.SetFloat("Speed", Mathf.Abs(moveY));
        }
        else
        {
            
            anim.SetFloat("Speed", 0f);
        }

        if (rolling)
        {
            anim.SetTrigger("Roll");
            StartCoroutine(setRoll());
        }
    }

    IEnumerator setRoll()
    {
        yield return new WaitForSeconds(0.2f);
        rolling = false;
    }

    public void ChangeHealth(int amt)
    {
        if (amt < 0)
        {
            if (isInvincible || rolling)
                return;

            isInvincible = true;
            invincibleTimer = hurtDelay;

            camController.StartCameraShake();
            lightScript.ChangeToRed();
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amt, 0, maxHealth);
        //UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
    public void TriggerGameOver()
    {
        gameOver.Setup();
    }

    void createDust()
    {
        dust.Play();
    }
}
