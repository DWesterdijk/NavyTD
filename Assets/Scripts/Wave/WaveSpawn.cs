using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawn : MonoBehaviour
{
    public static WaveSpawn current;

    [SerializeField]
    private Dictionary<int, List<GameObject>> _waves = new Dictionary<int, List<GameObject>>();

    [SerializeField]
    private List<GameObject> _wave, _wave1, _wave2, _wave3, _wave4;

    [SerializeField]
    UnityEvent _finishedWave;

    [SerializeField]
    private GameObject _spawnPoint;

    [SerializeField]
    private float _timeTillNextSpawn;

    private int _currentWave = 1;

    [SerializeField]
    private Text _waveNumbText;

    private bool _spawnActive, _waveActive;

    public List<GameObject> spawnedEnemies;

    private void Awake()
    {
        if(current == null)
        {
            current = this;
        }
    }

    private void Start()
    {
        if (_finishedWave == null)
            _finishedWave = new UnityEvent();

        _waveNumbText.text = _currentWave.ToString();

        EntityManager.current.AddWaveSpawn(this);

        _waves[1] = _wave;
        _waves[2] = _wave1;
        _waves[3] = _wave2;
        _waves[4] = _wave3;
        _waves[5] = _wave4;
    }

    public int GetCurrentWaveNumber()
    {
        return _currentWave;
    }

    void Update()
    {
        if (!_spawnActive)
        {
            if(spawnedEnemies.Count == 0 && _waveActive)
            {
                _currentWave++;

                if (_currentWave == 6)
                {
                    SceneManager.LoadSceneAsync(3 /*Winscreen*/, LoadSceneMode.Single);
                }

                _finishedWave.Invoke();
                _waveActive = false;
                _waveNumbText.text = _currentWave.ToString();
            }
        }
    }

    private IEnumerator SpawnEnemies()
    {
        List<GameObject> listWave = _waves[_currentWave];

        while(listWave.Count != 0)
        {
            spawnedEnemies.Add(Instantiate(listWave[0], _spawnPoint.transform));
            listWave.RemoveAt(0);
            yield return new WaitForSeconds(_timeTillNextSpawn);
        }
        _spawnActive = false;
    }

    public void StartSpawn()
    {
        if (!_spawnActive)
        {
            _spawnActive = true;
            _waveActive = true;
            StartCoroutine(SpawnEnemies());
        }
    }
}
