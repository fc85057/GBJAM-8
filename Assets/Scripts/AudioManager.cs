using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource[] audioSources;

    void Awake()
    {
        audioSources = GetComponents<AudioSource>();
    }

    public void Play(string sound)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.clip.name == sound)
            {
                audioSource.Play();
            }
        }
    }
}
