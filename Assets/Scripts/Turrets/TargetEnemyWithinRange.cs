using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


[RequireComponent(typeof(SphereCollider))]
public class TargetEnemyWithinRange : MonoBehaviour
{
    public event EventHandler<Enemy> OnObjectEnteredRange;

    private SphereCollider triggerRadius;

    private void Start()
    {
        triggerRadius = GetComponent<SphereCollider>();
        triggerRadius.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy == null) return;
        OnObjectEnteredRange?.Invoke(this, enemy);
    }
}
