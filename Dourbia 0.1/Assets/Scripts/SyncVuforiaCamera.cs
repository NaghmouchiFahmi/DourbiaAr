using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncVuforiaCamera : NetworkBehaviour
{
    [SerializeField] private Camera vuforiaCamera;

    //[SyncVar(hook = nameof(OnCameraPoseChanged))]
    private Vector3 cameraPosition;

    //[SyncVar(hook = nameof(OnCameraPoseChanged))]
    private Quaternion cameraRotation;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            // Disable Vuforia camera for non-local players
            vuforiaCamera.gameObject.SetActive(false);
        }
    }

    public override void OnStartServer()
    {
        base.OnStartServer();

        // Initialize camera pose on the server
        cameraPosition = vuforiaCamera.transform.position;
        cameraRotation = vuforiaCamera.transform.rotation;
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            // Update camera pose for the host player
            cameraPosition = vuforiaCamera.transform.position;
            cameraRotation = vuforiaCamera.transform.rotation;
        }
    }

    private void OnCameraPoseChanged()
    {
        // Update camera pose for non-local players
        if (!isLocalPlayer)
        {
            vuforiaCamera.transform.position = cameraPosition;
            vuforiaCamera.transform.rotation = cameraRotation;
        }
    }
}
