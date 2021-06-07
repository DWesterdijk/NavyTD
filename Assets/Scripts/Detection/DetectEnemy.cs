using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    private ShipFire _shipFire;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object Found");
        if (other.tag == StringManager.enemyTag)
        {
            Debug.Log("Enemy Found");
            _shipFire = GetComponentInParent<ShipFire>();
            _shipFire.targets.Add(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == StringManager.enemyTag)
        {
            _shipFire = GetComponentInParent<ShipFire>();
            
            for (int i = 0; i < _shipFire.targets.Count; i++)
            {
                if (_shipFire.targets[i].name == other.name)
                {
                    _shipFire.targets.RemoveAt(i);
                }
            }
        }
    }
}
