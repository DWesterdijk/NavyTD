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

    private ParticleSystem _shootparticles;

    public void Update()
    {
        if (targets.Count > 0)
        {
            this.gameObject.transform.LookAt(targets[0].transform);
            Shoot();
        }
    }

    private void Start()
    {
        EntityManager.current.AddTowersToList(this);
    }


    public float totalCooldown;

    private float _shootCooldown;

    private void Shoot()
    {
        if (_shootCooldown <= 0)
        {
            targets[0].GetComponent<GuiHealthBar>().currentHealth -= damage;
            Debug.Log("shot");
            shootparticles.Play();
            if (targets[0].GetComponent<GuiHealthBar>().currentHealth <= 0)
            {
                targets.RemoveAt(0);
            }


            _shootCooldown = totalCooldown;
        }
        else
        {
            _shootCooldown -= Time.deltaTime;
        }
    }
}
