using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public GameObject canvas;

    private bool isPaused;

    void Update()
    {
        LoadMainMenu();
    }

    public void LoadMainMenu()
    {
        isPaused = canvas.activeSelf;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = isPaused ? 1 : 0;
            canvas.SetActive(!isPaused);
        }
    }
}