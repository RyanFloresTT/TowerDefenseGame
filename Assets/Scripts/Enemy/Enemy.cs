using System;using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    public static Action<Enemy> OnEnemyDeath;
    public event Action<float> OnDamageTaken;
    public static Action OnEnemySurvivedDamage;

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
        var ratio = currentHealth / maxHealth;
        OnDamageTaken?.Invoke(ratio);
        if (currentHealth <= 0)
        {
            KillEnemy();
        } else
        {
            OnEnemySurvivedDamage?.Invoke();
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        TakeDamage(0);
    }

    private void KillEnemy()
    {
        OnEnemyDeath?.Invoke(this);
    }

    private bool IsNonEnemyDamageable(GameObject go) =>
        go.GetComponent<Enemy>() == null && go.GetComponent<ITakeDamage>() != null;
}
