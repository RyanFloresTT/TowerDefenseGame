using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public static event EventHandler<ResourceData> OnResourceGenerated;

    [SerializeField] private GeneratorTier tier;
    [SerializeField] private float generationAmount;
    [SerializeField] private float generationRateInSeconds;
    [SerializeField] private GeneratorUpgradeManager upgradeManager;

    private float amountMultiplier = 1f;
    private float rateMultiplier = 1f;
    private bool isGenerating;

    private void Start()
    {
        isGenerating = true;
        ListenToUpgradeEvents();
        StartCoroutine(GenerateResources());
    }

    private void ListenToUpgradeEvents()
    {
        UpgradeFloat.OnFloatChanged += Handle_UpgradeFloat;
    }

    private void Handle_UpgradeFloat(object sender, UpgradeData e)
    {
        switch (e.type)
        {
            case (GeneratorUpgrades.AmountBase):
                IncreaseBaseAmount(e.value);
                break;
            case (GeneratorUpgrades.RateMultiplierAdd):
                IncreaseRateMultiplierFromBase(e.value);
                break;
        }
    }

    private IEnumerator GenerateResources()
    {
        while (isGenerating)
        {
            Generate();
            yield return new WaitForSeconds(generationRateInSeconds * (1 / rateMultiplier));
        }
    }

    private void Generate()
    {
        var resource = new ResourceData(tier, generationAmount * amountMultiplier);
        OnResourceGenerated?.Invoke(this, resource);
    }

    public void SetGenerationStatus(bool willGenerate)
    {
        isGenerating = willGenerate;
    }

    private void IncreaseAmountMultiplierFromBase(float amount)
    {
        amountMultiplier = 1 + amount;
    }

    private void IncreaseRateMultiplierFromBase(float amount)
    {
        rateMultiplier = 1 + amount;
    }

    private void DecreaseBaseRate(float amount)
    {
        generationRateInSeconds -= amount;
    }

    private void IncreaseBaseAmount(float amount)
    {
        generationAmount += amount;
    }

    public void UpgradeRate()
    {
        upgradeManager.LevelUpRate();
    }

    public void UpgradeAmount()
    {
        upgradeManager.LevelUpAmount();
    }

}
