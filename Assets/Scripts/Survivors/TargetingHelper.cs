using System.Collections.Generic;
using UnityEngine;

public static class TargetingHelper {
    private static List<Enemy> closeEnemies = new List<Enemy>();
    static float dist;
    const float OUT_OF_BOUND_RANGE = 25f;
    static float maxDistance = float.MaxValue;
    static Enemy closestEnemy;
    public static List<Enemy> UpdateEnemyList(List<Enemy> enemies, Vector3 selfPosition) {
        closeEnemies.Clear();

        if (enemies.Count == 0) {
            return enemies;
        } else {
            foreach (Enemy enemy in enemies) {
                if (!enemy.gameObject.activeInHierarchy) continue;
                float dist = Vector3.Distance(enemy.transform.position, selfPosition);
                dist = Mathf.Abs(dist);
                Debug.Log(dist);
                if (dist <= OUT_OF_BOUND_RANGE)
                {
                    closeEnemies.Add(enemy);
                }
            }
        }
        return closeEnemies;
    }

    public static Enemy GetClosestEnemy(List<Enemy> enemies, Vector3 selfPosition) {
        closestEnemy = null;
        maxDistance = float.MaxValue;
        foreach (Enemy enemy in enemies) {
            if (enemy.gameObject.activeInHierarchy) {
                dist = Mathf.Abs(Vector3.Distance(selfPosition, enemy.transform.position));
                if (dist < maxDistance && dist < OUT_OF_BOUND_RANGE) {
                    maxDistance = dist;
                    closestEnemy = enemy;
                }
            }
        }
        return closestEnemy;
    }


    public static Enemy CheckEnemyWithinRange(Enemy enemy, Vector3 selfPosition) {
        if (!enemy.gameObject.activeInHierarchy) return null;
        float distance = Vector3.Distance(enemy.transform.position, selfPosition);
        Mathf.Abs(distance);
        if (distance <= OUT_OF_BOUND_RANGE) {
            return enemy;
        }
        return null;
    }
}
