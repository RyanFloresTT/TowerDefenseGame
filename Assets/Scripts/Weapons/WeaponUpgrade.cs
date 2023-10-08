using System;
using UnityEngine;
using UnityEngine.UI;

public enum UpgradeType {
    ShotSpeedMult,
    DamageMult,
    BaseShotSpeed,
    BaseDamage
}


[Serializable]
public class WeaponUpgrade {

    [field: SerializeField] public GameObject Attachment { get; set; }
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public UpgradeType Type { get; set; }
    [field: SerializeField] public float Amount { get; set; }
    [field: SerializeField] public int Cost { get; set; }
    [field: SerializeField] public Sprite Icon { get; set; }

    SurvivorData data;
    ResourceHandler resourceManager;
    bool upgraded;

    public static Action OnUpgradeSuccessful;

    public void SetData(SurvivorData data) {
        this.data = data;
        resourceManager = ResourceHandler.Instance;
        upgraded = false;
    }

    public void TryUnlockWeapon() {
        if (!upgraded && resourceManager.Purchase(Cost) ) { SetAttachment(); }
    }

    void SetAttachment() {
        OnUpgradeSuccessful?.Invoke();
        Attachment.SetActive(true);
        SetUpgradeValue();
        upgraded = true;
    }

    void SetUpgradeValue() {
        switch(Type)
        {
            case UpgradeType.ShotSpeedMult:
                data.ShotSpeedMultiplier += Amount;
                break;
            case UpgradeType.DamageMult:
                data.DamageMultiplier += Amount;
                break;
            case UpgradeType.BaseShotSpeed:
                data.ShotSpeed += Amount;
                break;
            case UpgradeType.BaseDamage:
                data.Damage += Amount;
                break;
            default:
                Debug.LogError("Upgrade Switch Defaulted!");
                break;
        }
    }
}