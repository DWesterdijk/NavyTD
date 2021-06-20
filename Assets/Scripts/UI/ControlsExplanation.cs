using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class ControlsExplanation : MonoBehaviour
{
    [SerializeField]
    GameObject ControlScreen;

    private void Start()
    {
        Time.timeScale = 0.0f;
        ControlScreen.SetActive(true);
    }

    public void CloseControlScreen()
    {
        ControlScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

}