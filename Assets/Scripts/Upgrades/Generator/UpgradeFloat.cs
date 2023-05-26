using System;
using UnityEngine;

[Serializable]
public class UpgradeFloat : IUpgrade
{
    public static event EventHandler<UpgradeData> OnFloatChanged;
    [SerializeField] private GeneratorUpgrades type;
    [SerializeField] float increasePerLevel;
    [SerializeField] int maxLevel;
    [SerializeField] int currentLevel;
    private float totalIncrease = 0f;

    public void Upgrade()
    {
        if (currentLevel < maxLevel)
        {
            totalIncrease += increasePerLevel;
            var data = new UpgradeData(type, totalIncrease);
            OnFloatChanged?.Invoke(this, data);
            currentLevel++;
        }
    }

    public bool IsAtMaxLevel() => currentLevel == maxLevel;
}
