using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningCircle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject slowingField;
    void Start()
    {
        StartCoroutine(Lifetime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        Instantiate(slowingField, transform.position, transform.rotation);
    }
}
