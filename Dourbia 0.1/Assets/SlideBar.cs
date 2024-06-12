using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class SlideBar : MonoBehaviour
{
    public GameObject[] characterPrefab;
    public float characterLifetime = 10f; // Lifetime of each character in seconds
    public Slider progressSlider;
    public GameObject Background;

    private GameObject spawnedCharacter;
    private bool spawningAllowed = true;
    private int characterIndex = 0;

    void Start()
    {
        progressSlider = FindObjectOfType<Slider>();
        Background = GameObject.Find("Bg");
        PlaneFinderBehaviour ground = FindObjectOfType<PlaneFinderBehaviour>();
        if (ground != null)
        {
            ground.OnAutomaticHitTest.AddListener(OnGroundPlaneDetected);
        }
    }

    void OnGroundPlaneDetected(HitTestResult result)
    {
        if (spawningAllowed)
        {
            StartCoroutine(SpawnCharacterWithLoader(result.Position));
        }
    }

    IEnumerator SpawnCharacterWithLoader(Vector3 position)
    {
        Background.SetActive(true);
        progressSlider.gameObject.SetActive(true);

        float timer = 0;

        while (timer < characterLifetime)
        {
            timer += Time.deltaTime;
            progressSlider.value = Mathf.Clamp01(timer / characterLifetime); // Update the slider value based on elapsed time
            yield return null;
        }

        // Ensure the loading bar reaches its maximum value before spawning the character
        progressSlider.value = 100f;

        SpawnCharacter(position); // Spawn the character after the loading bar is fully loaded

        //DestroyPreviousCharacter(); // Destroy the spawned character

        // Hide loader UI after character is spawned
        Background.SetActive(false);
        progressSlider.gameObject.SetActive(false);
    }

    void SpawnCharacter(Vector3 position)
    {
        if (characterPrefab != null)
        {
            spawnedCharacter = Instantiate(characterPrefab[characterIndex], position, Quaternion.identity);
            spawningAllowed = false; // Prevent spawning while character exists
            characterIndex = (characterIndex + 1) % characterPrefab.Length; // Cycle through character prefabs
        }
    }


   
}
