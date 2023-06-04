using TMPro;
using UnityEngine;

public class UpgradeButtons : MonoBehaviour
{
    [SerializeField] private int upgradeIndexOnUpgradeManager;
    [SerializeField] private TextMeshProUGUI upgradeCost;
    [SerializeField] private TextMeshProUGUI currentUpgradeValue;
    [SerializeField] private TextMeshProUGUI nextUpgradeValue;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject resourceImage;
    [SerializeField] private UpgradeManager upgradeableObject;
    private IUpgrade upgrade;

    private void Start()
    {
        upgradeableObject.OnUpgradeComplete += Handle_UpgradeComplete;
        upgrade = upgradeableObject.GetUpgradeFloats()[upgradeIndexOnUpgradeManager];
        UpdateUIText();
    }

    private void Handle_UpgradeComplete(object sender, System.EventArgs e)
    {
        UpdateUIText();
    }

    public void UpdateUIText()
    {
        upgradeCost.text = upgrade.GetPurchasePrice().Amount.ToString();
        UpdateValues();
        CheckMaxLevel();
    }

    private void UpdateValues()
    {
        var currentValuePercentage = (upgrade.GetCurrentValue() * 100).ToString();
        currentUpgradeValue.text = (currentValuePercentage + "%");

        var nextValuePercentage = (upgrade.GetNextValue() * 100).ToString();
        nextUpgradeValue.text = (nextValuePercentage + "%");
    }

    public void CheckMaxLevel()
    {
        if(upgrade.IsAtMaxLevel())
        {
            arrow.SetActive(false);
            upgradeCost.text = ("MAX!");
            resourceImage.SetActive(false);
            nextUpgradeValue.gameObject.SetActive(false);
        }
    }

}
