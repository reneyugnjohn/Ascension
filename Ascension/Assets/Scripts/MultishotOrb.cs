using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultishotOrb : MonoBehaviour
{
    public Sprite icon;
    PickUpScreen itemScreen;
    // Start is called before the first frame update
    void Start()
    {
        itemScreen = GameObject.FindWithTag("Canvas").GetComponent<PickUpScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        Upgrades playerUp = other.gameObject.GetComponent<Upgrades>();
        if (player != null && Input.GetKeyDown(KeyCode.E))
        {
            itemScreen.Appear();
            StartCoroutine(Decision(playerUp));
        }
    }

    IEnumerator Decision(Upgrades playerUp)
    {
        //Wait until a decision is made
        while (itemScreen.collected == 0)
            yield return null;

        //if the yes button is pressed
        if (itemScreen.collected == 1)
        {
            if (!playerUp.multiShot)
            {
                playerUp.setMultiShot(true, icon);
            }
            Destroy(gameObject);
        }
    }

}
