using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


[RequireComponent(typeof(SphereCollider))]
public class TargetEnemyWithinRange : MonoBehaviour
{
    public event EventHandler<GameObject> OnObjectEnteredRange;

    private SphereCollider triggerRadius;

    private void Start()
    {
        triggerRadius = GetComponent<SphereCollider>();
        triggerRadius.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.GetComponent<Enemy>());
        if (IsAnEnemy(other.gameObject))
        {
            Debug.Log("Yes");
            OnObjectEnteredRange?.Invoke(this, other.gameObject);
        }
    }

    private bool IsAnEnemy(GameObject target) => target.GetComponent<Enemy>() != null;
}
