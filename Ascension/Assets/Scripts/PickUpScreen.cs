using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScreen : MonoBehaviour
{
    GameObject screen;
    public int collected;
    void Start()
    {
        screen = transform.GetChild(3).gameObject;
    }

    public void Appear()
    {
        collected = 0;
        screen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Yes()
    {
        collected = 1;
        screen.SetActive(false);
        Time.timeScale = 1;
    }

    public void No()
    {
        collected = -1;
        screen.SetActive(false);
        Time.timeScale = 1;
    }
}
