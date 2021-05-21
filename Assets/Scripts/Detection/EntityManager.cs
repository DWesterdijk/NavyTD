using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static EntityManager current;

    private void Awake()
    {
        if (current == null)
            current = this;
    }

    private List<ShipFire> _towers = new List<ShipFire>();

    private WaveSpawn _waveSpawn;

    public void AddWaveSpawn(WaveSpawn waveSpawn)
    {
        _waveSpawn = waveSpawn;
    }

    public void AddTowersToList(ShipFire tower)
    {
        _towers.Add(tower);
    }

    public void RemoveEnemiesFromShipList(GameObject enemy)
    {
        for (int i = 0; i < _towers.Count; i++)
        {
            if (_towers[i].targets.Contains(enemy))
            {
                _towers[i].targets.Remove(enemy);
            }
        }

        _waveSpawn.spawnedEnemies.Remove(enemy);
    }
}
