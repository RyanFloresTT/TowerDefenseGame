using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int maxEnemyCount;
    [SerializeField] private float spawnDelayInSeconds;
    [SerializeField] private GameObjectPool spawnPool;
    [SerializeField] private Transform[] spawnLocations;
    [SerializeField] private Transform[] chaseLocations;
    private Transform chaseTarget;

    private int enemyCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
        Enemy.OnEnemyDeath += Handle_EnemyDeath;
        chaseTarget = chaseLocations[0];
    }

    private IEnumerator SpawnEnemies()
    {
        while (enemyCount <= maxEnemyCount)
        {
            yield return new WaitForSecondsRealtime(spawnDelayInSeconds);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var enemy = spawnPool.Get();
        enemy.transform.position = GetRandomTransformFromArray(spawnLocations).position;
        if (GetRandomTransformFromArray(chaseLocations) != null)
        {
            enemy.gameObject.GetComponent<MoveTowardsStaticTarget>().SetTarget(GetRandomTransformFromArray(chaseLocations));
        } else
        {
            enemy.gameObject.GetComponent<MoveTowardsStaticTarget>().SetTarget(chaseTarget);
        }
        enemyCount++;
    }

    private void Handle_EnemyDeath(Enemy e)
    {   
        var enemy = e.gameObject;
        enemyCount--;
        if (enemyCount < maxEnemyCount)
        {
            StartCoroutine(SpawnEnemies());
        }
        e.ResetHealth();
        spawnPool.Return(enemy);
    }

    private Transform GetRandomTransformFromArray(Transform[] transforms) => transforms[UnityEngine.Random.Range(0, transforms.Length -1)];
}
