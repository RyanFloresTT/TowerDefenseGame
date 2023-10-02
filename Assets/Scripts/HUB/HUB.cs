using System;
using UnityEngine;

public class HUB : MonoBehaviour, ITakeDamage
{
    public event Action<float> OnDamageTaken;
    public static Action OnHubDestroyed;

    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    [SerializeField] float armor;

    void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage - (damage * armor);
        var ratio = currentHealth / maxHealth;
        OnDamageTaken?.Invoke(ratio);
        if (currentHealth <= 0)
        {
            OnHubDestroyed?.Invoke();
            gameObject.SetActive(false);
        }
    }
}