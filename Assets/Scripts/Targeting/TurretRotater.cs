using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TurretTargeting))]
public class TurretRotater : MonoBehaviour
{
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
    }

    private void Update()
    {
        if (HasTarget())
        {
            LooKAtTarget();
        }
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
