using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondBetweenSpawn;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForPerSeconds = new WaitForSeconds(_secondBetweenSpawn);

        do
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                Instantiate(_enemyPrefab, _spawnPoints[i]);

                yield return waitForPerSeconds;
            }
        } while (true); //для ментора: умышленно оставил бесконечный цикл, тк по условиям задания нет условий окончания спауна
    }
}