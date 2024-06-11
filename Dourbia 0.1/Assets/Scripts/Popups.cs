using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Popups : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;  // Reference to the TextMeshPro component
    public string[] textOptions;         // Array of text options to display
    private int currentTextIndex = 0;
    public GameObject Popup;
    void Start()
    {
        // Start the coroutine to change the text every 1 minute
        StartCoroutine(ChangeTextRoutine());

    }

    public IEnumerator ChangeTextRoutine()
    {
        while (currentTextIndex < textOptions.Length)
        {
            // Update the text in the TextMeshPro component
            textMeshPro.text = textOptions[currentTextIndex];

           

            // Wait for 1 minute (60 seconds) before changing the text again
            yield return new WaitForSeconds(50f);
        }
        

        
    }


    public void fadePopup()
    {
        Popup.gameObject.SetActive(false);
    }
}
