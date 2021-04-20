using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFire : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();

    public void Update()
    {
        if (targets.Count > 0)
        {
            this.gameObject.transform.LookAt(targets[0].transform);
            Shoot();
        }
    }

    private float _shootCooldown = 600f;

    private void Shoot()
    {
        if (_shootCooldown <= 0)
        {
            Destroy(targets[0]); //TODO: replace with HP
            targets.RemoveAt(0);

            _shootCooldown = 600f;
        }
        else
        {
            _shootCooldown--;
        }
    }
}
