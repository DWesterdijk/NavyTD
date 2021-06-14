using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains everything for the reload of the friendly ship(turrets)
/// </summary>

public class ShipReload : MonoBehaviour
{
    //All ammo and time amounts, they can be changed in the inspector
    [SerializeField] 
    int _maxAmmoCount, _currentAmmoCount, _reloadDuration;
    public bool ableToFire;

    private void Start()
    {
        ableToFire = true;
        _currentAmmoCount = _maxAmmoCount;
    }

    //This function is called everytime the ship fires, it is called from the ShipFire script
    public void OnShipFire()
    {
        _currentAmmoCount--;
        if (_currentAmmoCount == 0)
        {
            ableToFire = false;
        }
    }

    private void OnGUI()
    {
        if (ableToFire == false)
        {
            GUI.enabled = true;
            var position = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
            position.y = Screen.height - position.y;

            if (GUI.Button(new Rect(position.x - 50, position.y - 50, 100, 25), "Reload"))
            {
                StartCoroutine(ReloadTimer());
            }
        } else
        {
            GUI.enabled = false;
        }
    }

    //The duration of the reload
    private IEnumerator ReloadTimer()
    {
        yield return new WaitForSeconds(_reloadDuration);
        _currentAmmoCount = _maxAmmoCount;
        ableToFire = true;
    }

}