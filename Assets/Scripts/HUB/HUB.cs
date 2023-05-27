using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HUB : MonoBehaviour, ITakeDamage, IGetUpgrades
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
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
        }
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