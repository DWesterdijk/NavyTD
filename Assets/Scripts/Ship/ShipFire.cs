using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFire : MonoBehaviour
{
    [Header("Damage")]
    public float damage;

    [Header("Targets")]
    public List<GameObject> targets = new List<GameObject>();

    public void Update()
    {
        if (targets.Count > 0)
        {
            this.gameObject.transform.LookAt(targets[0].transform);
            Shoot();
        }
    }

    private float _shootCooldown = 100f;

    private void Shoot()
    {
        if (_shootCooldown <= 0)
        {
            targets[0].GetComponent<GuiHealthBar>().currentHealth -= damage;
            
            if (targets[0].GetComponent<GuiHealthBar>().currentHealth <= 0)
            {
                targets.RemoveAt(0);
            }


            _shootCooldown = 600f;
        }
        else
        {
            _shootCooldown--;
        }
    }
}
