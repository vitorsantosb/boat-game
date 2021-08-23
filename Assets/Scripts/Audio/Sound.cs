using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    private AudioSource audioSource;
    
    public string tagClip;

    [SerializeField] private AudioClip track;
    
    [Range(0f,1f)]
    [SerializeField] private float volume = 1;
    
    [Range(.1f,3f)]
    [SerializeField] private float pitch;
    
    [Range(-1,1)]
    [SerializeField] private float stereoPan;
    
    [SerializeField] private bool loop, playOnAwake;

    public AudioSource AudioSource
    {
        get => audioSource;
        set => audioSource = value;
    }
    public AudioClip AudioClip
    {
        get => track;
        set => track = value;
    }
    
    public float Volume
    {
        get => volume;
        set => volume = value;
    }

    public float Pitch
    {
        get => pitch;
        set => pitch = value;
    }

    public float StereoPan
    {
        get => stereoPan;
        set => stereoPan = value;
    }

    public bool Loop
    {
        get => loop;
        set => loop = value;
    }

    public bool PlayOnAwake
    {
        get => playOnAwake;
        set => playOnAwake = value;
    }
}
