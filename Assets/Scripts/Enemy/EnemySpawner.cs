using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int maxEnemyCount;
    [SerializeField] private float spawnDelayInSeconds;

    private int enemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (enemyCount <= maxEnemyCount)
        {
            yield return new WaitForSecondsRealtime(spawnDelayInSeconds);
            SpawnEnemy();
        }
    }
}
