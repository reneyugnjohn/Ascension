using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public AudioSource musicSource;

    public void Awake()
    {
        Instance = this;
    }

    public void BackgroundMusic(float volume)
    {
        musicSource.volume = volume;
    }
}
