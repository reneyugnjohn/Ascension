using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public Slider slider;
    CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent <CanvasGroup>();
        canvasGroup.alpha = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(slider.value < 1)
        {
            canvasGroup.alpha = 1;
        }
    }

    public void UpdateHealthbar(float currHealth, float maxHealth)
    {
        slider.value = currHealth/maxHealth;
    }
}
