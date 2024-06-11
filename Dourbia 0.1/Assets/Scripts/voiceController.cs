using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
using UnityEngine.Android;


public class voiceController : MonoBehaviour
{
    const string LANG_CODE = "fr";
    public Text uiText;
    public static voiceController Instance;
    private void Start()
    {
        Setup(LANG_CODE);

        
        SpeechToText.Instance.onResultCallback = OnFinalSpeechResult;
        CheckPermission();
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

        void CheckPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    public void StartListening()
    {
        SpeechToText.Instance.StartRecording();
    }

    public void StopListening()
    {
        SpeechToText.Instance.StopRecording();
    }
    void OnFinalSpeechResult(string Result)
    {
        uiText.text = Result;
    }

    void OnPartialSpeechResult(string Result)
    {
        uiText.text = Result;
    }
    
    void Setup(string code)
    {
        TextToSpeech.Instance.Setting(code, 1, 1);
        SpeechToText.Instance.Setting(code);
    }
}
