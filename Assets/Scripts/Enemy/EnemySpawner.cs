using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] float spawnDelayInSeconds;
    [SerializeField] GameObjectPool spawnPool;
    [SerializeField] Transform[] spawnLocations;
    [SerializeField] Transform hubLocation;
    [SerializeField] LevelData level;

    Transform chaseTarget;
    int maxEnemyCount;
    int enemyCount;
    int killedEnemies;

    public static Action OnWaveCleared;
    public static Action<int> OnWaveStarted;

    void Start() {
        Enemy.OnEnemyDeath += Handle_EnemyDeath;
        chaseTarget = hubLocation;
        enemyCount = 0;
        killedEnemies = 0;
        level.WaveIndex = 0;
        StartWave();
    }

    void StartWave() {
        OnWaveStarted?.Invoke(level.WaveIndex + 1);
        maxEnemyCount = level.CurrentWave.RequiredKills;
        enemyCount = 0;
        killedEnemies = 0;
        StartCoroutine(DelayUntilNextWave());
    }

    IEnumerator DelayUntilNextWave() {
        yield return new WaitForSeconds(level.CurrentWave.Delay);
        StartCoroutine(SpawnEnemies());

    }
    IEnumerator SpawnEnemies()
    {
        while (enemyCount < maxEnemyCount) {
            yield return new WaitForSecondsRealtime(spawnDelayInSeconds);
            enemyCount++;
            SpawnEnemy();
        }
    }

    void SpawnEnemy() {
        var enemy = spawnPool.Get();
        enemy.transform.position = GetRandomTransformFromArray(spawnLocations).position;
        enemy.gameObject.GetComponent<MoveTowardsStaticTarget>().SetTarget(chaseTarget);
    }

    void Handle_EnemyDeath(Enemy e) {
        e.ResetHealth();
        var enemy = e.gameObject;
        spawnPool.Return(enemy);
        killedEnemies++;
        if (killedEnemies >= maxEnemyCount) {
            StopAllCoroutines();
            OnWaveCleared?.Invoke();
            level.WaveIndex++;
            StartWave();
        }
    }

    Transform GetRandomTransformFromArray(Transform[] transforms) => transforms[UnityEngine.Random.Range(0, transforms.Length)];
}
    