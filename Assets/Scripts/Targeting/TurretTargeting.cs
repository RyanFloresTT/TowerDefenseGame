using System;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    [SerializeField] private TargetEnemyWithinRange targetingSource;

    public event EventHandler<Enemy> OnCurrentTargetChanged;
    
    private List<Enemy> enemies;
    private Enemy target;

    private void Start()
    {
        targetingSource.OnObjectEnteredRange += Handle_TargetEnteredRange;
        Enemy.OnEnemyDestroyed += Handle_EnemyDestroyed;
        enemies = new();
    }
    
    private void Handle_TargetEnteredRange(object sender, Enemy e)
    {
        Debug.Log("Target Acquired");
        enemies.Add(e);
    }

    private void Handle_EnemyDestroyed(object sender, Enemy e)
    {
        enemies.Remove(e);
    }

    private void FixedUpdate()
    {
        if (TargetChanged())
        {
            target = TargetingHelper.TargetClosestEnemy(enemies, transform);
            OnCurrentTargetChanged?.Invoke(this, target);
        }
    }

    public Enemy GetCurrentTarget()
    {
        return target;
    }

    private bool TargetChanged() => target != TargetingHelper.TargetClosestEnemy(enemies, transform);
    private bool HasTarget() => target != null;
}
