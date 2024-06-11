using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnWithPLane : MonoBehaviour
{
    public GameObject characterPrefab; // Character prefab to instantiate
    private GameObject spawnedCharacter; // Reference to the instantiated character

    void Start()
    {
        // Register for Vuforia ground plane events
        PlaneFinderBehaviour ground  = FindObjectOfType<PlaneFinderBehaviour>();
        if (ground != null)
        {
            ground.OnAutomaticHitTest.AddListener(OnGroundPlaneDetected);
           
        }
    }

    void OnGroundPlaneDetected(HitTestResult result)
    {
        // Destroy the previously spawned character
        DestroyPreviousCharacter();

        // Instantiate a new character prefab at the detected position
        Vector3 position = result.Position;
        position.y = 0.1f;
        spawnedCharacter = Instantiate(characterPrefab, position, Quaternion.identity);
    }

    void DestroyPreviousCharacter()
    {
        if (spawnedCharacter != null)
        {
            Destroy(spawnedCharacter);
        }
    }
}
