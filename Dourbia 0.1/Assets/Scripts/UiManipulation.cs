using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManipulation : MonoBehaviour
{
    public GameObject Ui;


    public void AppearUi()
    {
        Ui.SetActive(true);
    }

    public void DissappearUi()
    {
        Ui.SetActive(false);
    }

}
