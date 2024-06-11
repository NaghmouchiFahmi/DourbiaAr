using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator character1Animator;
    public Animator character2Animator;
    public AudioSource character1AudioSource;
    public AudioSource character2AudioSource;
    public AudioClip[] character1TalkClips; // Array of audio clips for character 1 talking
    public AudioClip[] character2TalkClips; // Array of audio clips for character 2 talking

    private bool isCharacter1Turn = true; // Flag to track whether it's character 1's turn
    private int character1ClipIndex = 0;
    private int character2ClipIndex = 0;

    private void Start()
    {
        
    }

    public void StartConversation()
    {
        // Play the first character's clip
        HandleCharacter1Turn();
    }


    public void StopAnimations()
    {

        StopAllCoroutines();
        character1AudioSource.Stop();
        character1AudioSource.clip = null;

        character2AudioSource.Stop();
        character2AudioSource.clip = null;
        character1ClipIndex = 0;
        character2ClipIndex = 0;

    }

    void PlayCharacterClip(Animator animator, Animator animator1, AudioSource audioSource, AudioClip clip)
    {
        //animator.SetTrigger("test");
        animator.SetBool("talk", true);
        //animator1.SetTrigger("test2");
        // animator1.ResetTrigger("test");
        animator1.SetBool("talk", false);



        // Play the audio clip
        audioSource.clip = clip;
        audioSource.Play();

        // Schedule the next turn after the audio clip finishes playing (adjust delay if needed)
        StartCoroutine(ScheduleNextTurn(audioSource.clip.length, 0.1f));
    }

    IEnumerator ScheduleNextTurn(float clipDuration, float delay)
    {
        yield return new WaitForSeconds(clipDuration + delay);



        // Call appropriate function based on current turn
        if (isCharacter1Turn)
        {
            HandleCharacter2Turn();
        }
        else
        {
            HandleCharacter1Turn();
        }
        isCharacter1Turn = !isCharacter1Turn; // Switch turns
    }

    void HandleCharacter1Turn()
    {
        if (character1ClipIndex < character1TalkClips.Length)
        {
            PlayCharacterClip(character1Animator, character2Animator, character1AudioSource, character1TalkClips[character1ClipIndex]);
            character1ClipIndex++;
        }

    }

    void HandleCharacter2Turn()
    {
        if (character2ClipIndex < character2TalkClips.Length)
        {
            PlayCharacterClip(character2Animator, character1Animator, character2AudioSource, character2TalkClips[character2ClipIndex]);
            character2ClipIndex++;
        }

    }
}

