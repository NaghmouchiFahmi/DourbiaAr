using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerabunker : NetworkBehaviour
{
    public Camera Playercam;
    // Start is called before the first frame update
    void Start()
    {
        if(!isLocalPlayer)
        {
            Playercam.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
