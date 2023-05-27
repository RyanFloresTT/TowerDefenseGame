using System;using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    public static event EventHandler<Enemy> OnEnemyDeath;
    [SerializeField] private float damage = 1;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        DoDamageToNonEnemyUnit(other.gameObject);
    }

    private void DoDamageToNonEnemyUnit(GameObject unit)
    {
        if (!IsNonEnemyDamageable(unit)) return;
        unit.GetComponent<ITakeDamage>().TakeDamage(damage);
        KillEnemy();
    }

    public void TakeDamage(float incomingDamage)
    {
        currentHealth -= incomingDamage;
        if (currentHealth <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        OnEnemyDeath?.Invoke(this, this);
    }

    private bool IsNonEnemyDamageable(GameObject go) =>
        go.GetComponent<Enemy>() == null && go.GetComponent<ITakeDamage>() != null;
}
