using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathsAnimations : MonoBehaviour
{
    public Animator character1Animator;
    public AudioSource character1AudioSource;
    public AudioClip character1TalkClips; // Array of audio clips for character 1 talking
    public GameObject signs;


    private void Start()
    {

    }

    public void StartConversation()
    {
        // Play the first character's clip
        PlayCharacterClip(character1Animator, character1AudioSource, character1TalkClips);
    }


    public void StopAnimations()
    {

        StopAllCoroutines();
        character1AudioSource.Stop();
        character1AudioSource.clip = null;

        

    }

    void PlayCharacterClip(Animator animator, AudioSource audioSource, AudioClip clip)
    {
        animator.SetBool("talk", true);



        // Play the audio clip
        audioSource.clip = clip;
        audioSource.Play();

        StartCoroutine(ScheduleNextTurn( 10f));
        StartCoroutine(ScheduleNext(audioSource.clip.length, animator));
    }

    IEnumerator ScheduleNext(float clipDuration, Animator animator)
    {
        yield return new WaitForSeconds(clipDuration );

        animator.SetBool("talk", false);



    }

    IEnumerator ScheduleNextTurn(float delay)
    {
        yield return new WaitForSeconds(delay);

        signs.gameObject.SetActive(true);



    }

   

   
}
