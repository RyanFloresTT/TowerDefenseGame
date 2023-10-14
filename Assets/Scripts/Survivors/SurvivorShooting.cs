using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Survivor))]
public class SurvivorShooting : MonoBehaviour, IUseSurvivorData
{
    [SerializeField] TargetEnemyWithinRange targeting;

    SurvivorData data;

    public Action OnSurvivorShot;
    public static Action OnSurvivorShotGunSFX;

    void Awake() {
        targeting.OnTargetChanged += Handle_TargetChanged;
        GetSurvivorData();
    }

    void Handle_TargetChanged() {
        StopAllCoroutines();
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot() {
        yield return new WaitForSeconds(0.5f);
        while (HasTarget()) {
            if (!data.IsMoving) {
                OnSurvivorShot?.Invoke();
                OnSurvivorShotGunSFX?.Invoke();
            }
            yield return new WaitForSeconds(data.ShotSpeed);
        }
    }

    bool HasTarget() => data.Target != null;

    public void GetSurvivorData() {
        data = GetComponent<Survivor>().Data;
    }
}
