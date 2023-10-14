using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] float spawnDelayInSeconds;
    [SerializeField] Transform[] spawnLocations;
    [SerializeField] Transform hubLocation;
    [SerializeField] LevelData level;
    [SerializeField] Transform spawnContainer;

    GameObjectPool spawnPool;
    Transform chaseTarget;
    int maxEnemyCount;
    int enemyCount;
    int killedEnemies;
    int killRequirementIndex;
    GameObject spawningZombie;

    public static Action OnWaveCleared;
    public static Action<int> OnWaveStarted;

    void Start() {
        Initalize();
        StartWave();
    }

    void Initalize() {
        Enemy.OnEnemyDeath += Handle_EnemyDeath;
        chaseTarget = hubLocation;
        level.WaveIndex = 0;
        killRequirementIndex = 0;
        spawningZombie = level.Waves[level.WaveIndex].KillRequirements[killRequirementIndex].Zombie;
        spawnPool = new GameObjectPool(spawningZombie, spawnContainer);
        ResetVariables();
    }

    void ResetVariables() {
        enemyCount = 0;
        killedEnemies = 0;
        maxEnemyCount = level.CurrentWave.KillRequirements[killRequirementIndex].SpawnAmount;
        spawningZombie = level.Waves[level.WaveIndex].KillRequirements[killRequirementIndex].Zombie;
        ClearGameObjectPoolContainer();
        spawnPool.ReInitializeWithNewGameObject(spawningZombie);
    }

    void StartWave() {
        OnWaveStarted?.Invoke(level.WaveIndex + 1);
        maxEnemyCount = level.CurrentWave.KillRequirements[killRequirementIndex].SpawnAmount;
        ResetVariables();
        StartCoroutine(DelayUntilNextWave());
    }

    IEnumerator DelayUntilNextWave() {
        yield return new WaitForSeconds(level.CurrentWave.DelayBetweenWaves);
        StartCoroutine(SpawnEnemies());

    }
    IEnumerator SpawnEnemies() {
        while (enemyCount < maxEnemyCount) {
            yield return new WaitForSecondsRealtime(spawnDelayInSeconds);
            enemyCount++;
            SpawnEnemy();
        }
    }

    void SpawnEnemy() {
        var enemy = spawnPool.Get(false);
        enemy.transform.position = GetRandomTransformFromArray(spawnLocations).position;
        enemy.GetComponent<MoveTowardsStaticTarget>().SetTarget(chaseTarget);
        enemy.SetActive(true);
    }

    void Handle_EnemyDeath(Enemy e) {
        e.ResetHealth();
        var enemy = e.gameObject;
        spawnPool.Return(enemy);
        killedEnemies++;
        if (killedEnemies >= maxEnemyCount) {
            StopAllCoroutines();
            if (killRequirementIndex + 1 >= level.CurrentWave.KillRequirements.Count) {
                killRequirementIndex = 0;
                OnWaveCleared?.Invoke();
                level.WaveIndex++;
                StartWave();
            }
            else {
                killRequirementIndex++;
                ResetVariables();
                StartCoroutine(SpawnEnemies());
            }
        }
    }

    void ClearGameObjectPoolContainer() {
        int childCount = spawnContainer.childCount;
        for (int i = 0; i < childCount; i++) {
            GameObject zombie = spawnContainer.GetChild(i).gameObject;
            Destroy(zombie);
        }
    }


    Transform GetRandomTransformFromArray(Transform[] transforms) => transforms[UnityEngine.Random.Range(0, transforms.Length)];
}
    