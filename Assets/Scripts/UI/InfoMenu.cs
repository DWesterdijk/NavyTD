using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    public GameObject infoMenu;

    public void OpenMenu()
    {
        infoMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        infoMenu.SetActive(false);
    }
}
