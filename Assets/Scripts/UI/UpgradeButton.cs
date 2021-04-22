using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    private GameObject _currentShip, _nextShip;

    public void SetShip(GameObject nextShip, GameObject currentShip)
    {
        _currentShip = currentShip;
        _nextShip = nextShip;
    }

    public void Upgrade()
    {
        Transform currentShipTransform = _currentShip.transform;

        Destroy(_currentShip);
        Instantiate(_nextShip, currentShipTransform.position, currentShipTransform.rotation);

        _currentShip = null;
        _nextShip = null;
        this.gameObject.SetActive(false);
    }
}
