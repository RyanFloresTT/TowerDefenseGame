using System;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    [SerializeField] private TargetEnemyWithinRange targetingSource;

    public event Action<Enemy> OnCurrentTargetChanged;
    
    private List<Enemy> enemies;
    private Enemy target;

    private void Start()
    {
        targetingSource.OnObjectEnteredRange += Handle_TargetEnteredRange;
        Enemy.OnEnemyDeath += Handle_EnemyDestroyed;
        enemies = new();
    }
    
    private void Handle_TargetEnteredRange(Enemy e)
    {
        Debug.Log("Target Acquired");
        enemies.Add(e);
    }

    private void Handle_EnemyDestroyed(Enemy e)
    {
        enemies.Remove(e);
    }

    private void FixedUpdate()
    {
        if (TargetChanged())
        {
            target = TargetingHelper.TargetClosestEnemy(enemies, transform);
            OnCurrentTargetChanged?.Invoke(target);
        }
    }

    public Enemy GetCurrentTarget()
    {
        return target;
    }

    private bool TargetChanged() => target != TargetingHelper.TargetClosestEnemy(enemies, transform);
    private bool HasTarget() => target != null;
}
