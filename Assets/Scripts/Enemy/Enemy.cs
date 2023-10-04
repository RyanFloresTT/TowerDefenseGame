using System;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    public static Action<Enemy> OnEnemyDeath;
    public event Action<float> OnDamageTaken;
    public static Action OnEnemySurvivedDamage;

    [SerializeField] float damage = 1;
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    [SerializeField] int pointValue;

    public int PointValue { get { return pointValue; } private set { } } 

    void Start() {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider other) {
        DoDamageToNonEnemyUnit(other.gameObject);
    }

    void DoDamageToNonEnemyUnit(GameObject unit) {
        if (!IsNonEnemyDamageable(unit)) return;
        unit.GetComponent<ITakeDamage>().TakeDamage(damage);
        KillEnemy();
    }

    public void TakeDamage(float incomingDamage) {
        currentHealth -= incomingDamage;
        var ratio = currentHealth / maxHealth;
        OnDamageTaken?.Invoke(ratio);
        if (currentHealth <= 0) {
            KillEnemy();
        } else {
            OnEnemySurvivedDamage?.Invoke();
        }
    }

    public void ResetHealth() {
        currentHealth = maxHealth;
        TakeDamage(0);
    }

    void KillEnemy() {
        OnEnemyDeath?.Invoke(this);
    }

    bool IsNonEnemyDamageable(GameObject go) =>
        go.GetComponent<Enemy>() == null && go.GetComponent<ITakeDamage>() != null;
}
