using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolBoyAnimation : MonoBehaviour
{
    public Animator character1Animator;
    public AudioSource character1AudioSource;
    public AudioClip character1TalkClips;

    public void animationtrigger()
    {
        PlayCharacterClip(character1Animator, character1AudioSource, character1TalkClips);
    }
    void PlayCharacterClip(Animator animator, AudioSource audioSource, AudioClip clip)
    {
        animator.SetBool("talk", true);



        audioSource.clip = clip;
        audioSource.Play();


    }

}
