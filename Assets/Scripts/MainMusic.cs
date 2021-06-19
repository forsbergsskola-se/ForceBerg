using System;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource.volume = PlayerPrefs.GetFloat("musicVolume");
    }
}
