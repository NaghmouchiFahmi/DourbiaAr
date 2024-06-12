using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Vuforia;

public class SpawnWithPLane : MonoBehaviour
{
    public GameObject[] characterPrefab; // Character prefab to instantiate
    private GameObject spawnedCharacter; // Reference to the instantiated character
    [SerializeField]
    private int characterIndex = 0;
    private GameObject bg;
    public float cycleInterval = 20f; // Interval in seconds to cycle characters
    private bool hited = true;
    PlaneFinderBehaviour ground;
    void Start()
    {
        bg = GameObject.Find("Bg");
        // Register for Vuforia ground plane events
         ground  = FindObjectOfType<PlaneFinderBehaviour>();

        if (ground != null)
        {
            if (hited == true)
            {
                ground.OnAutomaticHitTest.AddListener(OnGroundPlaneDetected);
                hited = false;
            }

        }
    }

    void OnGroundPlaneDetected(HitTestResult result)
    {
        bg.SetActive(false);

        Vector3 position = result.Position;
        position.y = 0.1f;

        //spawnedCharacter = Instantiate(characterPrefab[characterIndex], position, Quaternion.identity);
        // characterIndex = (characterIndex + 1) % characterPrefab.Length; // Cycle through character prefabs
        StartCoroutine(CycleCharacters(position));
    }



    IEnumerator CycleCharacters(Vector3 position)
    {
        DestroyPreviousCharacter();




        // Cycle through character prefabs


        // Destroy the previous character and instantiate the new one

      
             spawnedCharacter = Instantiate(characterPrefab[characterIndex], position, Quaternion.identity);

            
        

        yield return new WaitForSeconds(cycleInterval);





    }


    public void shownCharacters()
    {
        
        
        if(characterIndex >= characterPrefab.Length)
        {
            characterIndex += 1;
        }
        else
        {
            characterIndex = 0;
        }
    }
    void DestroyPreviousCharacter()
    {
       
            Destroy(spawnedCharacter);
            ground.PlaneIndicator.SetActive(true);

        
    }
}
