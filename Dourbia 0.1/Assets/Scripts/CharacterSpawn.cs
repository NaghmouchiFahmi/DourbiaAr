using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    // Array of GameObjects to spawn
    public GameObject[] objectsToSpawn;
    public Transform spawnPositions;
    //private bool spawning = false;
    public int count = 0;
    public GameObject SchoolBoy;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    private void Update()
    {
        SchoolBoyAnimation schoolBoyComponent = FindObjectOfType<SchoolBoyAnimation>();
        //SchoolBoy = FindObjectOfType<SchoolBoyAnimation>().gameObject;
        if (SchoolBoy != null )
        {
             SchoolBoy = schoolBoyComponent.gameObject;
            schoolBoyComponent.enabled = true;
        }
        else
        {
            schoolBoyComponent.enabled = false;

        }
    }
    public void IncreaseCounter()
    {
        
        if (count < objectsToSpawn.Length)
        {
            
            count = count + 1;
        }
         if (count >= objectsToSpawn.Length)
        {
            count = 0;
            Debug.Log("Counter reset to zero.");
        }
    }


    // Coroutine to spawn objects
    public void SpawnObjects()
    {
        //int num2 = Random.Range(0, objectsToSpawn.Length);

        // Instantiate the object at the specified position
        Instantiate(objectsToSpawn[count], spawnPositions.position, spawnPositions.rotation);

               
            
        
    }


    public void StopSpawning()
    {
        CancelInvoke("SpawnObjects");

    }
}
