using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class UpgradeAmount : ScriptableObject, IUpgrade
{
    public static event EventHandler<float> OnAmountMultiplierUpdated;
    [SerializeField] float amountIncreasePerLevel;
    [SerializeField] int maxLevel;
    [SerializeField] int currentLevel;
    private float totalIncrease = 0f;

    public void Upgrade()
    {
        if (currentLevel < maxLevel)
        {
            totalIncrease += amountIncreasePerLevel;
            OnAmountMultiplierUpdated?.Invoke(this, totalIncrease);
            currentLevel++;
        }
    }
    public bool IsAtMaxLevel() => currentLevel == maxLevel;
}
