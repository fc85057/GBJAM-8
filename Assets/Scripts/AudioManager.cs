using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public bool musicOn;
    public bool sfxOn;
    public static AudioManager instance = null;

    public AudioSource[] audioSources;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        audioSources = GetComponents<AudioSource>();
        musicOn = true;
        sfxOn = true;

        //musicOn = FindObjectOfType<AudioSettings>().musicOn;
        //sfxOn = FindObjectOfType<AudioSettings>().sfxOn;

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
            foreach(AudioSource audioSource in audioSources)
            {
                if (audioSource.clip.name == "GBMusic2")
                {
                if (!musicOn)
                {
                    audioSource.Pause();
                }
                    else if (musicOn)
                {
                    audioSource.UnPause();
                }
                }
            }
    }

    public void Play(string sound)
    {
        if (sfxOn)
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

    public void SetMusic(bool setMusic)
    {
        musicOn = setMusic;
    }


}
