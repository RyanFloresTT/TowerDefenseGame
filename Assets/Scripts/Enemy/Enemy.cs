using System;using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event EventHandler<Enemy> OnEnemyDestroyed;
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        DoDamageToNonEnemyUnit(other.gameObject);
    }

    private void DoDamageToNonEnemyUnit(GameObject unit)
    {
        if (!IsNonEnemyDamageable(unit)) return;
        unit.GetComponent<ITakeDamage>().TakeDamage(damage);
        OnEnemyDestroyed?.Invoke(this, this);
        Destroy(gameObject);
    }

    private bool IsNonEnemyDamageable(GameObject go) =>
        go.GetComponent<Enemy>() != null && go.GetComponent<ITakeDamage>() != null;
}
