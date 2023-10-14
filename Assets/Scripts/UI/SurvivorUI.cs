using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SurvivorUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dmgText;
    [SerializeField] TextMeshProUGUI shotSpeedText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image profilePicture;
    [SerializeField] Transform buttonContainer;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject upgradeAttachmentButtonPrefab;

    IHaveActionButtons[] actionButtons;
    SurvivorData data;

    public static Action<SurvivorData> OnMoveSurvivorSet;

    void Awake() {
        SurvivorUpgrades.OnSurvivorSelected += Handle_SurvivorSelected;
        ExitActionButtonMenu.OnExitMenuPressed += Handle_ExitMenu;
        UpgradeWeaponActionButton.OnShowUpgradeButtons += Handle_ShowUpgrades;
        WeaponUpgrade.OnUpgradeSuccessful += Handle_WeaponUpgraded;
        MoveActionButton.OnMovePrimed += Handle_MovePrimed;
    }

    void Handle_MovePrimed() {
        OnMoveSurvivorSet?.Invoke(data);
    }

    void Handle_WeaponUpgraded() {
        SetSurvivorDetails();
    }

    void Handle_ShowUpgrades() {
        ShowUnlockAttachmentButtons();
    }

    void Handle_ExitMenu() {
        ClearContainer();
        data = null;
    }

    void Handle_SurvivorSelected(SurvivorData incData) {
        data = incData;
        actionButtons = data.Survivor.ActionButtons;
        SetSurvivorDetails();
        SetActionButtons();
    }

    void SetSurvivorDetails() {
        dmgText.text = data.Damage.ToString();
        shotSpeedText.text = data.ShotSpeed.ToString();
        profilePicture.sprite = data.profilePicture;
        nameText.text = data.Name.ToString();
    }

    void SetActionButtons() {
        ClearContainer();
        for (int i = 0; i < actionButtons.Length; i++) {
            Instantiate(actionButtons[i].ActionButton, buttonContainer);
        }
        Instantiate(exitButton, buttonContainer);
    }

    void ShowUnlockAttachmentButtons() {
        ClearContainer();
        var weaponUpgrades = data.Weapon.GetComponent<Weapon>().WeaponUpgrades; 
        for (int i = 0; i < weaponUpgrades.Count; i++) {
            var btnGO = Instantiate(upgradeAttachmentButtonPrefab, buttonContainer);
            var weaponUpgrade = btnGO.GetComponent<UnlockWeaponAttachment>();
            weaponUpgrade.SetIcon(weaponUpgrades[i].Icon);
            weaponUpgrades[i].SetData(data);
            weaponUpgrade.Upgrade = weaponUpgrades[i];
        }
    }

    void ClearContainer() { foreach (Transform button in buttonContainer) { Destroy(button.gameObject); } }
}
