using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform exitPoint;
    public Transform player;
    public GameObject enemies;
    bool open;

    // Start is called before the first frame update
    void Start()
    {
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.transform.childCount == 0)
        {
            open = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null && open)
        {
            if (gameObject.CompareTag("FinalDoor"))
            {
                player.TriggerGameOver();
            }
            player.transform.position = new Vector3(exitPoint.transform.position.x, exitPoint.transform.position.y - 2, 0);

        }

    }
}
