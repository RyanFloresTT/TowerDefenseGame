using System;
using UnityEngine;

[Serializable]
public class UpgradeManager
{
    public static event EventHandler OnUpgradeBought;
    [SerializeField] private UpgradeRate upgradeRate;
    [SerializeField] private UpgradeAmount upgradeAmount;

    public void LevelUpUpgrade(IUpgrade upgrade)
    {
        if (!CanLevelUp(upgrade)) return;
        upgrade.Upgrade();
        OnUpgradeBought?.Invoke(this, EventArgs.Empty);
    }

    private bool CanLevelUp(IUpgrade upgrade) => upgrade != null && upgrade.IsAtMaxLevel();
}
