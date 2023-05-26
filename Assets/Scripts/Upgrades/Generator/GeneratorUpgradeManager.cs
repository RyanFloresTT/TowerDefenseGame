using System;
using System.Security.Cryptography;
using UnityEngine;

[Serializable]
public class GeneratorUpgradeManager : IManageUpgrades
{
    public static event EventHandler OnUpgradeBought;
    [SerializeField] private UpgradeFloat upgradeSlotOne;
    [SerializeField] private UpgradeFloat upgradeSlotTwo;

    private ResourceHandler resourceHandler;

    private GeneratorUpgradeManager()
    {
        resourceHandler = ResourceHandler.Instance;
    }

    public void LevelUpRate()
    {
        LevelUpUpgrade(upgradeSlotOne);
    }

    public void LevelUpAmount()
    {
        LevelUpUpgrade(upgradeSlotTwo);  
    }

    public void LevelUpUpgrade(IUpgrade upgrade)
    {
        if (!CanUpgrade(upgrade)) return;
        upgrade.Upgrade();
        OnUpgradeBought?.Invoke(this, EventArgs.Empty);
    }

    public bool CanUpgrade(IUpgrade upgrade) => upgrade != null && !upgrade.IsAtMaxLevel() && resourceHandler.Purchase(upgrade.GetPurchasePrice());
}
