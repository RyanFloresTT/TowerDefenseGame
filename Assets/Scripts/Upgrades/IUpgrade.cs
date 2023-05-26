using System;

public interface IUpgrade
{
    public void Upgrade();
    public bool IsAtMaxLevel();
    public ResourceData GetPurchasePrice();
}
