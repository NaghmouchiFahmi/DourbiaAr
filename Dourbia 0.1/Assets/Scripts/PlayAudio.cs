using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    void Start()
    {
        // Create an AudioSource component if not already attached
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        // Assign the audio clip
        audioSource.clip = audioClip;
    }

    public void PlayAudioo()
    {
        if (audioSource != null && audioClip != null)
        {
            // Play the audio clip
            audioSource.Play();
        }
       
    }

    public void StopAudioo()
    {
        if (audioSource != null && audioClip != null)
        {
            // Play the audio clip
            audioSource.Stop();
        }

    }

}
