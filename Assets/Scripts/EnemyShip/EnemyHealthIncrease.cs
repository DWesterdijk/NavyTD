using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthIncrease : MonoBehaviour
{
    public void increaseStats()
    {
        float multiplier = 1.125 * _currentWave;
          _stats = this.GetComponent<EnemyShipStats>();

        _stats.maxHealth * multiplier;
        //repeat for other stats. 
    }
}
