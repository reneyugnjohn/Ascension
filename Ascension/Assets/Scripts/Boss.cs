using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Transform playerT;
    Damageable dmg;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        playerT = GameObject.FindWithTag("Player").transform;
        dmg = GetComponent<Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dmg.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void callLightning()
    {
        StartCoroutine(Lightning());
    }

    IEnumerator Lightning()
    {
       // Debug.Log("hello");
        for(int x=0; x<30; x++)
        {
            Instantiate(bullet, new Vector2(Random.Range(149,173), Random.Range(-56,-34)), transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
