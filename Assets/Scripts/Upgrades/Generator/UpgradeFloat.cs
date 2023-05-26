using Mono.Cecil;
using System;
using UnityEngine;

[Serializable]
public class UpgradeFloat : IUpgrade
{
    public static event EventHandler<UpgradeData> OnFloatChanged;
    [SerializeField] private GeneratorUpgrades type;
    [SerializeField] private float costPerLevel;
    [SerializeField] private float costIncreasePerLevel;
    [SerializeField] private GeneratorTier resourceTierToUpgrade;
    [SerializeField] private float increasePerLevel;
    [SerializeField] private int maxLevel;
    [SerializeField] private int currentLevel;

    private float totalFloatIncrease = 0f;

    public void Upgrade()
    {
        if (currentLevel < maxLevel)
        {
            totalFloatIncrease += increasePerLevel;
            var data = new UpgradeData(type, totalFloatIncrease);
            OnFloatChanged?.Invoke(this, data);
            currentLevel++;
        }
    }

    public ResourceData GetPurchasePrice()
    {
        var cost = currentLevel * (costPerLevel + costIncreasePerLevel);
        var data = new ResourceData(resourceTierToUpgrade, cost);
        return data;
    }

    public bool IsAtMaxLevel() => currentLevel == maxLevel;
}
