using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManageUpgrades
{
    public void LevelUpUpgrade(IUpgrade upgrade);
    public bool CanUpgrade(IUpgrade upgrade);
}
