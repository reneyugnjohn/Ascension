using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Transform playerT;
    Damageable dmg;

    public GameObject lightning;

    float angle = 0f;
    Vector2 bulletMoveDirection;

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
        for(int x=0; x<30; x++)
        {
            Instantiate(lightning, new Vector2(Random.Range(149,173), Random.Range(-56,-34)), transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void callBulletSpiral()
    {
        InvokeRepeating("Fire", 0f, .2f);
       // Debug.Log("call");
        //StartCoroutine(Spiral());
    }

    IEnumerator Spiral()
    {
        Fire();
        yield return new WaitForSeconds(0.2f);
    }

    public void cancelSpiral()
    {
        CancelInvoke("Fire");
    }

    void Fire()
    {
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BossBulletPool.instance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BossBullet>().SetMoveDirection(bulDir);
        }

        angle += 20f;

        if (angle >= 360f)
            angle = 0f;
    }
}
