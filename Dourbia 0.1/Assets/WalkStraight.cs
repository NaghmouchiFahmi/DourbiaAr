using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Vuforia;

public class WalkStraight : MonoBehaviour
{
    PlaneFinderBehaviour ground;

   
  

   /* public void slide()
    {
        if ((surfaceDetected) && (spawnedCharacter != null))
        {
            spawnedCharacter.transform.Translate();

        }
        }*/
    void Update()
    {
        ground = FindObjectOfType<PlaneFinderBehaviour>();



        // Check for input to move the character
        
            
        gameObject.transform.Translate(ground.PlaneIndicator.transform.position);
        
    }
}
