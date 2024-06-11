using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public void ChangeScene(string SceneName)
    {
       
            // Load the specified scene
            SceneManager.LoadScene(SceneName);
        
       
    }
}
