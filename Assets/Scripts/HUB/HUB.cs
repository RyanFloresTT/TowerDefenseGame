using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HUB : MonoBehaviour, ITakeDamage, IGetUpgrades
{
    public event EventHandler<float> OnDamageTaken;

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float armor;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage - (damage * armor);
        var ratio = currentHealth / maxHealth;
        OnDamageTaken?.Invoke(this, ratio);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ApplyUpgrades(UpgradeData data)
    {
        switch (data.type)
        {
            case (UpgradeTypes.AmountBase):
                IncreaseHealthFixed(data.value);
                break;
            case (UpgradeTypes.AmountMultiplierAdd):
                IncreaseArmor(data.value);
                break;
        }
    }

    private void IncreaseArmor(float value)
    {
        armor += value;
    }

    private void IncreaseHealthFixed(float value)
    {
        IncreaseMaxHealth(value);
    }

    private void IncreaseMaxHealth(float value)
    {
        var ratio = currentHealth / maxHealth;
        maxHealth += value;
        currentHealth = maxHealth * ratio;
    }

}