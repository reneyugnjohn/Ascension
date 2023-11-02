using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    float delay;
    Upgrades upg;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 
        upg = GetComponentInParent<Upgrades>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }

        }

        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            if (upg.doubleFire)
            {
                StartCoroutine(DoubleFire());
            }
            else
            {
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            }
        }

    }

    IEnumerator DoubleFire()
    {
        Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, bulletTransform.position, Quaternion.identity);
    }
}
