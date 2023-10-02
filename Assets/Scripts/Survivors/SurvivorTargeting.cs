using System;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorTargeting : MonoBehaviour
{
    [SerializeField] SurvivorData data;
    [SerializeField] TargetEnemyWithinRange targetingSource;
    
    List<Enemy> enemies;

    public Action OnTargetChanged;
    //public static Action<Enemy> OnTargetClearedFromSurvivor;

    void Start() {
        //targetingSource.OnEnemyEnteredRange += Handle_TargetEnteredRange;
        Enemy.OnEnemyDeath += Handle_EnemyDied;
        enemies = new();
        data.Target = null;
    }
    
    void Handle_TargetEnteredRange(Enemy e) {
        enemies.Add(e);
    }

    void Handle_EnemyDied(Enemy e) {
        if (data.Target == e) {
            data.Target = null;
            OnTargetChanged?.Invoke();
            enemies.Remove(e);
            //OnTargetClearedFromSurvivor?.Invoke(e);
            return;
        }
        else if (enemies.Contains(e)) {
            enemies.Remove(e);
            //OnTargetClearedFromSurvivor?.Invoke(e);
            return;
        }
    }

    void Update() {
        //if (TargetChanged()) {
            //data.Target = targetHelper.TargetClosestEnemy(enemies, transform);
            //OnTargetChanged?.Invoke();
        //}
        //targetHelper.CheckEnemyWithinRange(data.Target, data.Range, transform);
    }
    //bool TargetChanged() => data.Target != targetHelper.TargetClosestEnemy(enemies, transform);
}