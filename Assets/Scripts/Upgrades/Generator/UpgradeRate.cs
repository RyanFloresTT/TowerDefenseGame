using System;
using UnityEngine;

[CreateAssetMenu()]
public class UpgradeRate : ScriptableObject, IUpgrade
{
    public static event EventHandler<float> OnRateMultiplierUpdated;
    [SerializeField] float rateIncreasePerLevel;
    [SerializeField] int maxLevel;
    [SerializeField] int currentLevel;
    private float totalIncrease = 0f;

    public void Upgrade()
    {
        if (currentLevel < maxLevel)
        {
            totalIncrease += rateIncreasePerLevel;
            OnRateMultiplierUpdated?.Invoke(this, totalIncrease);
            currentLevel++;
        }
    }

    public bool IsAtMaxLevel() => currentLevel == maxLevel;
}
