using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(TurretTargeting))]
public class TurretShooting : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float firingDelayInSeconds;
    
    private TurretTargeting targeting;
    private Enemy target;

    private void Start()
    {
        targeting = GetComponent<TurretTargeting>();
        targeting.OnCurrentTargetChanged += Handle_TargetChanged;
    }

    private void Handle_TargetChanged(object sender, Enemy e)
    {
        target = e;
        StartCoroutine(FireLaser());
    }

    private IEnumerator FireLaser()
    {
        target.TakeDamage(damage);
        yield return new WaitForSeconds(firingDelayInSeconds);
    }

    private bool HasTarget() => target != null;
}
