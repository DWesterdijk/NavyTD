using System.Collections;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _windObject;
    private float _radius = 30;
    private float _minSpawnTime = 1;
    private float _maxSpawnTime = 4;
    private float _prefabLifetime = 5;

    private void Start()
    {
        StartCoroutine(WindSpawnRoutine());
    }

    private IEnumerator WindSpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));
            SpawnAndDestroy();
        }
    }

    private void SpawnAndDestroy()
    {
        Vector2 randomPos = Random.insideUnitCircle * _radius;
        Destroy(Instantiate(_windObject, randomPos, Quaternion.identity), _prefabLifetime);
    }
}
