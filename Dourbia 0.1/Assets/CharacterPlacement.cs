using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CharacterPlacement : MonoBehaviour
{
    public GameObject characterVuforiaObject; // Assign your Vuforia character object
    private PlaneFinderBehaviour planeFinderBehaviour;
    private bool isSurfaceDetected;

    void Start()
    {
         planeFinderBehaviour = FindObjectOfType<PlaneFinderBehaviour>();
        // Make sure your character object has a Vuforia Observer behavior attached
    }

    void Update()
    {
       
            isSurfaceDetected = true;

        // Get ground plane hit information
       // var hit = planeFinderBehaviour.PerformHitTest(Camera.main.ScreenPointToRay(Input.mousePosition));
            //var hit = planeFinderBehaviour.HitTest(Camera.main.ScreenPointToRay(Input.mousePosition));

          /*  if (hit.collider != null)
            {
                // Update character position based on hit point
                characterVuforiaObject.transform.position = hit.Point;
            }*/
        
      
    }
}
