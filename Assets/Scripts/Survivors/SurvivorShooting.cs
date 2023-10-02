using System;
using System.Collections;
using UnityEngine;

public class SurvivorShooting : MonoBehaviour
{
    [SerializeField] SurvivorData data;
    [SerializeField] TargetEnemyWithinRange targeting;

    public Action OnSurvivorShot;
    public static Action OnSurvivorShotGunSFX;

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
            OnSurvivorShotGunSFX?.Invoke();
        }
    }

    bool HasTarget() => data.Target != null;
}
