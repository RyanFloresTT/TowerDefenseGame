using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] int maxEnemyCount;
    [SerializeField] float spawnDelayInSeconds;
    [SerializeField] GameObjectPool spawnPool;
    [SerializeField] Transform[] spawnLocations;
    [SerializeField] Transform[] chaseLocations;
    Transform chaseTarget;

    int enemyCount = 0;

    void Start() {
        StartCoroutine(SpawnEnemies());
        TargetEnemyWithinRange.OnTargetClearedFromSurvivor += Handle_EnemyDeath;
        chaseTarget = chaseLocations[0];
    }

    IEnumerator SpawnEnemies() {
        while (enemyCount <= maxEnemyCount) {
            yield return new WaitForSecondsRealtime(spawnDelayInSeconds);
            SpawnEnemy();
        }
    }

    void SpawnEnemy() {
        var enemy = spawnPool.Get();
        enemy.transform.position = GetRandomTransformFromArray(spawnLocations).position;
        if (GetRandomTransformFromArray(chaseLocations) != null) {
            enemy.gameObject.GetComponent<MoveTowardsStaticTarget>().SetTarget(GetRandomTransformFromArray(chaseLocations));
        } else {
            enemy.gameObject.GetComponent<MoveTowardsStaticTarget>().SetTarget(chaseTarget);
        }
        enemyCount++;
    }

    void Handle_EnemyDeath(Enemy e) {   
        enemyCount--;
        e.ResetHealth();
        var enemy = e.gameObject;
        spawnPool.Return(enemy);
        StopAllCoroutines();
        if (enemyCount < maxEnemyCount) {
            StartCoroutine(SpawnEnemies());
        }
    }

    Transform GetRandomTransformFromArray(Transform[] transforms) => transforms[UnityEngine.Random.Range(0, transforms.Length)];
}
