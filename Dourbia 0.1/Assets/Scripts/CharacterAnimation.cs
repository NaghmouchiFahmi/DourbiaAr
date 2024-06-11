using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterAnimation : MonoBehaviour
{
    //public string[] keywords = new string[] { "Qui êtes-vous","antonin" ,"hadrien", "Pourquoi avez-vous", "pourquoi s'appellent-ils " };
    public Animator character1Animator;
    public AudioSource character1AudioSource;
    public AudioClip[] character1TalkClips; // Array of audio clips for character 1 talking
    string test;
   
    public string[] Question;
    //public Text uiText1;
    //public Text uiText2;
   // public Text uiText3;
   // private int AnswersCounter = 0;
   // public int AnswersCountForCharacters = 0;
    private void Update()
    {
       test = voiceController.Instance.uiText.text.ToString().Trim();

        //uiText3.text = test;
        //uiText1.text = AnswersCounter.ToString();
        //StartConversation();

        //uiText1.text = Question[3];
    }

    private void Start()
    {

    }


    /*public void startingConversation()
    {

        PlayCharacterClip(character1Animator, character1AudioSource, character1TalkClips[0]);
        

        StartConversation();
        //StartCoroutine(ScheduleNextTurn(character1TalkClips[0].length, 0.1f));

    }*/


    /*IEnumerator ScheduleNextTurn(float clipDuration, float delay)
    {
        yield return new WaitForSeconds(clipDuration + delay);
        StartConversation();
    }*/



    /*public void starting()
    {
        PlayCharacterClip(character1Animator, character1AudioSource, character1TalkClips[0]);

    }*/

    public void StartConversation()
    {

        /*string targetText = "qui êtes-vous";
        int index = test.IndexOf(targetText);*/


        // Check if the target text is present in the input text


        if (test.IndexOf(Question[0]) != -1)
        {
            //AnswersCounter += 1;
            PlayCharacterClip(character1Animator, character1AudioSource, character1TalkClips[0]);
        }



        if (test.IndexOf(Question[1]) != -1)
        {
            //AnswersCounter += 1;
            PlayCharacterClip(character1Animator, character1AudioSource, character1TalkClips[1]);
        }


        if (test.IndexOf(Question[2]) != -1)
        {
            // AnswersCounter += 1;
            PlayCharacterClip(character1Animator, character1AudioSource, character1TalkClips[2]);
        }

        if (test.IndexOf(Question[3]) != -1)
        {

            //AnswersCounter += 1;
            PlayCharacterClip(character1Animator, character1AudioSource, character1TalkClips[3]);
            
        }


        if (test.IndexOf(Question[4]) != -1)
        {
            //AnswersCounter += 1;
            PlayCharacterClip(character1Animator, character1AudioSource, character1TalkClips[4]);
        }

        /*if (AnswersCounter == 4)
        {
            PlayCharacterClip(character1Animator, character1AudioSource, character1TalkClips[4]);
            
        }*/



    }


    public void StopAnimations()
    {

        StopAllCoroutines();
        character1AudioSource.Stop();
        character1AudioSource.clip = null;
        character1Animator.SetBool("talk", false);
        test=null;
        //voiceController.Instance.uiText.text = null;    
    }

    void PlayCharacterClip(Animator animator, AudioSource audioSource, AudioClip clip)
    {
        animator.SetBool("talk", true);



        audioSource.clip = clip;
        audioSource.Play();

        StartCoroutine(ScheduleNext(audioSource.clip.length, 0.1f, animator));


    }

    IEnumerator ScheduleNext(float clipDuration, float delay, Animator animator)
    {
        yield return new WaitForSeconds(clipDuration + delay);

        animator.SetBool("talk", false);



    }


    //void HandleCharacterTurn()
    //{
    //    if (character1ClipIndex < character1TalkClips.Length)
    //    {
    //        PlayCharacterClip(character1Animator, character1AudioSource, character1TalkClips[character1ClipIndex]);
    //        character1ClipIndex++;
    //    }

    //}


}
