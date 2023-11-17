using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExArrowOrb : MonoBehaviour
{
    public Sprite icon;
    PickUpScreen itemScreen;
    GameObject eIndicator;
    // Start is called before the first frame update
    void Start()
    {
        itemScreen = GameObject.FindWithTag("Canvas").GetComponent<PickUpScreen>();
        eIndicator = transform.GetChild(0).GetChild(0).gameObject;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
            eIndicator.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if(player != null)
            eIndicator.SetActive(false);
    }

    IEnumerator Decision(Upgrades playerUp)
    {
        //Wait until a decision is made
        while (itemScreen.collected == 0)
            yield return null;

        //if the yes button is pressed
        if (itemScreen.collected == 1)
        {
            if (!playerUp.expArrow)
            {
                playerUp.setExpArrow(true, icon);
            }
            Destroy(gameObject);
        }
    }

}
