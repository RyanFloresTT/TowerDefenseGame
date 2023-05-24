using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event EventHandler<Enemy> OnEnemyDestroyed;
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter(Collider other)
    {   
        var damageable = other.gameObject.GetComponent<ITakeDamage>();
        if (damageable == null) return;
        damageable.TakeDamage(damage);
        OnEnemyDestroyed?.Invoke(this, this);
        Destroy(gameObject);
    }
}
