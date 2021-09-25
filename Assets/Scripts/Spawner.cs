using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondBetweenSpawn;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_secondBetweenSpawn);

        do
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                Instantiate(_enemyPrefab, _spawnPoints[i]);

                yield return waitForSeconds;
            }
        } while (true); 
    }
}