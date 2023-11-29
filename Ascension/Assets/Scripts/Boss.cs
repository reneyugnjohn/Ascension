using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Transform playerT;
    Damageable dmg;

    public GameObject bullet;

    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    int phase = 1;
    bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        playerT = GameObject.FindWithTag("Player").transform;
        dmg = GetComponent<Damageable>();
        //PhaseOne();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (canFire)
        {
            timer = 0;
            canFire = false;
            Lightning();
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
            }
        }
        */
        // PhaseOne();
      //  Debug.Log(phase);
       if(phase == 1)
       {
            StartCoroutine(PhaseOne());
       }
    }

    IEnumerator PhaseOne()
    {
    //    Debug.Log("asdf");
        if(!attacking)
            StartCoroutine(Lightning());

        yield return new WaitForSeconds(10);
    }

    IEnumerator Lightning()
    {
       // Debug.Log("hello");
        attacking = true;
        for(int x=0; x<30; x++)
        {
            Instantiate(bullet, new Vector2(Random.Range(151,169), Random.Range(-48,-31)), transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }
        attacking = false;
    }
}
