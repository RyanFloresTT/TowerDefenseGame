using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UpgradeRate : Upgrade
{
    public static event EventHandler<float> UpgradeRateChanged;
    [SerializeField] float rateIncreasePerLevel;
    [SerializeField] int maxLevel;
    [SerializeField] int currentLevel;
    private float totalIncrease = 0f;

    public void DoUpgrade()
    {
        if (currentLevel < maxLevel)
        {
            totalIncrease += rateIncreasePerLevel;
            UpgradeRateChanged?.Invoke(this, totalIncrease);
            currentLevel++;
        }
    }
}
