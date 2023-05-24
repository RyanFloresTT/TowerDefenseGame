using System;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    [SerializeField] private TargetEnemyWithinRange targetingSource;
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


    private void Update()
    {
        if (HasTarget())
        {
            LooKAtTarget();
        }
    }

    private void FixedUpdate()
    {
        target = TargetingHelper.TargetClosestEnemy(enemies, transform);
    }

    private void LooKAtTarget()
    {
        var lookPos = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0,eulerY,0);
    }

    private bool HasTarget() => target != null;
}
