using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audioSource;
    public AudioClip gameBackgroundMusic;
    public AudioClip objectMissSFX;
    public AudioClip rightObjectSFXMusic;

    public void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameBackgroundMusic;
        audioSource.Play();
    }

    // Object position miss hole missed audio bajbe 
    public void MissedSlotAudio()
    {
        audioSource.PlayOneShot(objectMissSFX, 1);
    }
    public void RightSlotAudio()
    {
        audioSource.PlayOneShot(rightObjectSFXMusic, 1);
    }
}
