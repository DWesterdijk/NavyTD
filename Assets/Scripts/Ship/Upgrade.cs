using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField]
    private UpgradeButton _upgradeUI;

    [SerializeField]
    private GameObject _upgradeShip;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && !_upgradeShip.gameObject.activeInHierarchy)
        {
            _upgradeUI.gameObject.SetActive(true);
            _upgradeUI.SetShip(_upgradeShip, this.gameObject);
        }
    }
}
