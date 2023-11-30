using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletPool : MonoBehaviour
{
    public static BossBulletPool instance;

    [SerializeField] GameObject pooledBullet;
    bool notEnoughBulletsInPool = true;

    List<GameObject> bullets;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetBullet()
    {
        if(bullets.Count > 0)
        {
            for(int i = 0; i<bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if(notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }
}
