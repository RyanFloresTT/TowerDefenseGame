using System;
using UnityEngine;

public class TargetEnemyWithinRange : MonoBehaviour {
    [SerializeField] SurvivorData data;
    [SerializeField] SurvivorShooting shootingScript;
    [SerializeField] LayerMask enemyLayer;

    public Action OnTargetChanged;

    Collider[] colliders;
    Enemy closestEnemy;
    float closestDistance;
    float distance;

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
}
