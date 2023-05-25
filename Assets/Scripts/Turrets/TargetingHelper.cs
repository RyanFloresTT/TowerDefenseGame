using System.Collections.Generic;
using UnityEngine;

public class TargetingHelper
{
    public static Enemy TargetClosestEnemy(List<Enemy> enemies, Transform self)
    {
        if (enemies.Count == 0) return null;
        var closestEnemy = enemies[0];
        var minDistance = float.MaxValue;
        
        foreach (var enemy in enemies)
        {
            var dist = Vector3.Distance(enemy.transform.position, self.position);
            if ( dist < minDistance)
            {
                minDistance = dist;
                closestEnemy = enemy;
            }
            
        }
        return closestEnemy;
    }
}