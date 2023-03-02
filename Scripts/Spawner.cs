using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private WaitForSeconds _pause;

    private void Awake()
    {
        _pause = new WaitForSeconds(_secondsBetweenSpawn);
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                Instantiate(_enemy, _spawnPoints[i]);
                yield return _pause;
            }
        }
    }
}
