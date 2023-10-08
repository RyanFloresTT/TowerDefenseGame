using System;
using UnityEngine;

public class TargetEnemyWithinRange : MonoBehaviour, IUseSurvivorData {
    [SerializeField] SurvivorShooting shootingScript;
    [SerializeField] LayerMask enemyLayer;

    SurvivorData data;
    Collider[] colliders;
    Enemy closestEnemy;
    float closestDistance;
    float distance;

    public Action OnTargetChanged;

    void Awake() {
        GetSurvivorData();
    }

    void Update() {
        colliders = Physics.OverlapSphere(transform.position, data.Range, enemyLayer);
        closestEnemy = null;
        closestDistance = float.MaxValue;

        foreach (var collider in colliders) {
            var enemy = collider.GetComponent<Enemy>();
            if (enemy != null) {
                distance = Vector3.Distance(transform.position, enemy.transform.position);

                if (distance < closestDistance) {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        if (closestEnemy != data.Target) {
            data.Target = closestEnemy;
            OnTargetChanged?.Invoke();
        }
    }

    public void GetSurvivorData() {
        data = GetComponent<Survivor>().Data;
    }
}
