using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _enemies, _spawnedEnemies;

    [SerializeField]
    UnityEvent _finishedWave;

    [SerializeField]
    private GameObject _spawnPoint;

    [SerializeField]
    private float _timeTillNextSpawn;
    private float _currentTime;

    private bool _spawnActive, _waveActive;

    void Awake()
    {
        _currentTime = _timeTillNextSpawn;
    }

    private void Start()
    {
        if (_finishedWave == null)
            _finishedWave = new UnityEvent();
    }

    void Update()
    {
        if (!_spawnActive)
        {
            if(_spawnedEnemies.Count == 0 && _waveActive)
            {
                _finishedWave.Invoke();
                _waveActive = false;
            }
            return;
        }

        _currentTime -= Time.deltaTime;
        if(_currentTime <= 0)
        {
            SpawnEnemies();
            _currentTime = _timeTillNextSpawn;
        }
    }

    private void SpawnEnemies()
    {
        _spawnedEnemies.Add(Instantiate(_enemies[0], _spawnPoint.transform));
        _enemies.RemoveAt(0);
        if (0 == _enemies.Count)
            _spawnActive = false;
    }

    public void StartSpawn()
    {
        _currentTime = _timeTillNextSpawn;
        _spawnActive = true;
        _waveActive = true;
    }
}
