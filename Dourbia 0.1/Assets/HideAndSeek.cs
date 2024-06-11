using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndSeek : NetworkBehaviour
{
    public GameObject Panel;


    public void hide()
    {
        if (isLocalPlayer)
        {
            Panel.SetActive(false);
        }
    }

    public void Apppear()
    {
        if (isLocalPlayer)
        {

            Panel.SetActive(true);
        }
    }

}
