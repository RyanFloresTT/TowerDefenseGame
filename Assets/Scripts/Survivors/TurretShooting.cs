using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(TurretTargeting))]
public class TurretShooting : MonoBehaviour, IGetUpgrades
{
    [SerializeField] private float damage;
    [SerializeField] private float firingDelayInSeconds;

    private float damageMultiplier = 1f;
    private float firingMultiplier = 1f;
    
    private TurretTargeting targeting;
    private Enemy target;

    private void Start()
    {
        targeting = GetComponent<TurretTargeting>();
        targeting.OnCurrentTargetChanged += Handle_TargetChanged;
    }

    private void Handle_TargetChanged(Enemy e)
    {
        target = e;
        StopAllCoroutines();
        StartCoroutine(FireLaser());
    }

    private IEnumerator FireLaser()
    {
        while (HasTarget())
        {
            yield return new WaitForSeconds(firingDelayInSeconds * firingMultiplier);
            target.TakeDamage(damage * damageMultiplier);
        }
    }

    private bool HasTarget() => target != null;

    public void ApplyUpgrades(UpgradeData data)
    {
        switch (data.type)
        {
            case (UpgradeTypes.AmountBase):
                IncreaseBaseAmount(data.value);
                break;
            case (UpgradeTypes.RateMultiplierAdd):
                IncreaseRateMultiplierFromBase(data.value);
                break;
        }
    }

    private void IncreaseBaseAmount(float value)
    {
        damage += value;
    }

    private void IncreaseRateMultiplierFromBase(float value)
    {
        firingMultiplier -= value;
    }
}
