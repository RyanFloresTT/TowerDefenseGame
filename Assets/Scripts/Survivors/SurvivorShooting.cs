using System;
using System.Collections;
using UnityEngine;

public class SurvivorShooting : MonoBehaviour, IGetUpgrades
{
    [SerializeField] SurvivorData data;
    [SerializeField] TargetEnemyWithinRange targeting;

    public Action OnSurvivorShot;

    void Awake() {
        targeting.OnTargetChanged += Handle_TargetChanged;
    }

    void Handle_TargetChanged() {
        StopAllCoroutines();
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot() {
        while (HasTarget()) {
            yield return new WaitForSeconds(data.ShotSpeed);
            OnSurvivorShot?.Invoke();
        }
    }

    bool HasTarget() => data.Target != null;

    public void ApplyUpgrades(UpgradeData data)
    {
        throw new NotImplementedException();
    }
}
