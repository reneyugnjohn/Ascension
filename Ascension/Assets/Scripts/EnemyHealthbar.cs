using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public Slider slider;


    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthbar(float currHealth, float maxHealth)
    {
        slider.value = currHealth/maxHealth;
    }
}
