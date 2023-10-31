using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    //public Transform playerTransform;

    private Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Fly();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
        Destroy(gameObject);
    }
    /*
    void Fly(Vector3 targetPosition)
    {
        rb = GetComponent<Rigidbody2D>(Transform playerTransform);
        Vector3 direction = playerTransform.position - transform.position;
        Vector3 rotation = transform.position - playerTransform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }*/
}
