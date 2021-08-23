using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;

    [SerializeField] private AudioMixerGroup mainAudioMixerGroup;

    public AudioMixerGroup MainAudioMixer
    {
        get => mainAudioMixerGroup;
        set => mainAudioMixerGroup = value;
    }
    
    #region AudioManager Singleton

    private static AudioManager instance;
    public static AudioManager Instance => instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
        
    }

    #endregion
    
    private void Start()
    {
        foreach (Sound sound in sounds)
        {
            sound.AudioSource = gameObject.AddComponent<AudioSource>();
            
            sound.AudioSource.clip = sound.AudioClip;
            sound.AudioSource.volume = sound.Volume;
            sound.AudioSource.loop = sound.Loop;
            sound.AudioSource.pitch = sound.Pitch;
            sound.AudioSource.panStereo = sound.StereoPan;
            sound.AudioSource.playOnAwake = sound.PlayOnAwake;
        }
    }

    public void Play(string trackTag)
    {
        Sound s = Array.Find(sounds, sounds => sounds.tagClip == trackTag);
        if (s == null)
        {
            Debug.LogError($"Som {s} não encontrado");
            return;
        }
        s.AudioSource.Play();
    }
    
    public void Stop(string trackTag)
    {
        Sound s = Array.Find(sounds, sounds => sounds.tagClip == trackTag);
        if (s == null)
        {
            Debug.LogError($"Som {s} não encontrado");
            return;
        }
        s.AudioSource.Stop();
    }
}
