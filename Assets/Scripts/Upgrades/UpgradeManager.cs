using UnityEngine;
[RequireComponent(typeof(IGetUpgrades))]
public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private UpgradeFloat[] upgradeSlots;

    private IGetUpgrades upgradeObject;
    private ResourceHandler resourceHandler;

    private void Awake()
    {
        upgradeObject = GetComponent<IGetUpgrades>();
    }

    private void Start()
    {
        resourceHandler = ResourceHandler.Instance;
    }

    public void LevelUpSlot(int slot)
    {
        if (slot >= upgradeSlots.Length) return;
        LevelUpUpgrade(upgradeSlots[slot]);
    }

    public void LevelUpUpgrade(IUpgrade upgrade)
    {
        if (!CanUpgrade(upgrade)) return;
        upgrade.Upgrade(upgradeObject);
    }

    public bool CanUpgrade(IUpgrade upgrade) => upgrade != null && !upgrade.IsAtMaxLevel() && resourceHandler.Purchase(upgrade.GetPurchasePrice());
}
