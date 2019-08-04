using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource[] audioSources;

    public void Awake()
    {
        if (AudioManager.Instance == null)
            AudioManager.Instance = this;
    }

    private void Start()
    {
        audioSources = GetComponentsInChildren<AudioSource>();
        PlayFx("GameStart");
    }

    public void PlayFx(string audioName)
    {
        foreach (AudioSource a in audioSources)
        {
            if (a.name == audioName)
            {
                a.Play();
            }
        }
    }
}
