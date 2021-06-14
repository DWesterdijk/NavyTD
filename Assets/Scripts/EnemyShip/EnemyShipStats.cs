using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipStats : MonoBehaviour
{
    public float maxHealth;
    public float speed;
    public int damage;
    public int money;
    public int score;

    private void Awake()
    {
        IncreaseStats();
    }

    public void IncreaseStats()
    {
        float multiplier = 1.125f * WaveSpawn.current.GetCurrentWaveNumber();
        maxHealth *= multiplier;
    }
}
