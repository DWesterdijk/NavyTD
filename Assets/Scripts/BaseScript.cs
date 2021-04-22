using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the base health and if the base has been hit
/// </summary>
public class BaseScript : MonoBehaviour
{
    [SerializeField]
    int _baseHealth = 3;

    //Checks if base has been hit
    private void OnTriggerEnter(Collider collider)
    {
        BaseHit();
    }

    //Reduces base health, and checks if the base is out of lives
    private void BaseHit()
    {
        _baseHealth--;
        Debug.Log("Health: " + _baseHealth);
        if (_baseHealth < 1)
        {
            //game over
            _baseHealth = 0;
            Debug.Log("Game over");
        }
    }
}