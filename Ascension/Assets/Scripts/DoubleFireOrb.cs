using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleFireOrb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        Upgrades playerUp = other.gameObject.GetComponent<Upgrades>();
        if (player != null)
        {
            playerUp.doubleFire = true;
            Destroy(gameObject);
        }

    }
}