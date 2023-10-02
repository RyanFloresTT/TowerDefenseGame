using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TargetEnemyWithinRange : MonoBehaviour {
    [SerializeField] SurvivorData data;
    [SerializeField] SurvivorShooting shootingScript;

    SphereCollider triggerCollider;
    List<Enemy> enemies = new();
    const float RADIUS_MULTIPLIER = 0.8f;
    Enemy tmpEnemy;
    Enemy colEnemy;

    public Action OnTargetChanged;
    public static Action<Enemy> OnTargetClearedFromSurvivor; 

    void Awake() {
        enemies.Clear();
    }

    void Start() {
        triggerCollider = GetComponent<SphereCollider>();
        triggerCollider.isTrigger = true;
        data.Range = triggerCollider.radius * RADIUS_MULTIPLIER;

        Enemy.OnEnemyDeath += Handle_EnemyDeath;
        shootingScript.OnSurvivorShot += Handle_SurvivorShot;
    }

    private void Handle_SurvivorShot()
    {
    }

    void Handle_EnemyDeath(Enemy enemy) {
        if (enemies.Contains(enemy)) {
            enemies.Remove(enemy);
        }
        if (data.Target == enemy) {
            data.Target = null;
        }
        OnTargetClearedFromSurvivor?.Invoke(enemy);
    }

    void Update() {
        tmpEnemy = ClosestEnemy();
        if (tmpEnemy != data.Target) {
            data.Target = tmpEnemy;
            OnTargetChanged?.Invoke();
        }
        /* enemies = TargetingHelper.UpdateEnemyList(enemies, transform.position);
        data.Target = TargetingHelper.GetClosestEnemy(enemies, transform.position);
        Debug.Log($"{name} enemies count : {enemies.Count}");
        if (data.Target != null) {
            data.Target = TargetingHelper.CheckEnemyWithinRange(data.Target, transform.position);
        }
        OnTargetChanged?.Invoke(); */
    }
    void OnTriggerEnter(Collider other) {
        other.gameObject.TryGetComponent<Enemy>(out colEnemy);
        if (colEnemy == null) return;
        enemies.Add(colEnemy);
    }

    Enemy ClosestEnemy() => TargetingHelper.GetClosestEnemy(enemies, transform.position);
}
