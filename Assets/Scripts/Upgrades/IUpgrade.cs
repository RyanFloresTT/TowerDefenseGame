using System;

public interface IUpgrade
{
    public void Upgrade(IGetUpgrades upgradeObject);
    public bool IsAtMaxLevel();
    public ResourceData GetPurchasePrice();
    public float GetCurrentValue();

    public float GetNextValue();
}
