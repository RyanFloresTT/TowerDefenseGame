using System;
using UnityEngine;
[CreateAssetMenu(menuName = "ActionButtons/UpgradeWeapon")]
public class UpgradeWeaponActionButton : MenuButton
{
    public static Action OnShowUpgradeButtons;

    public override void OnButtonPressed() {
        OnShowUpgradeButtons?.Invoke();
    }
}