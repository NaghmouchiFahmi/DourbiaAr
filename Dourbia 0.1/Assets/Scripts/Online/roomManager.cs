using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomManager : NetworkRoomManager
{

    //[SerializeField] private GameObject unitspawnerPrefab = null;
    //[SerializeField] private GameObject Flag = null;


    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {

        base.OnServerAddPlayer(conn);
        //GameObject unitSpawnerInstance = Instantiate(unitspawnerPrefab, transform.position, transform.rotation);
        //NetworkServer.Spawn(unitSpawnerInstance, conn);


    }

}
