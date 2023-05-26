using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public static event EventHandler<ResourceData> OnResourceGenerated;

    [SerializeField] private GeneratorTier tier;
    [SerializeField] private float generationAmount;
    [SerializeField] private float generationRateInSeconds;
    [SerializeField] private UpgradeManager upgradeManager;

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
        UpgradeAmount.OnAmountMultiplierUpdated += Handle_AmountMultiplierChanged;
        UpgradeRate.OnRateMultiplierUpdated += Hande_RateMultiplierChanged;
    }

    private void Handle_AmountMultiplierChanged(object sender, float e)
    {
        amountMultiplier += e;
    }
    private void Hande_RateMultiplierChanged(object sender, float e)
    {
        isGenerating = false;
        rateMultiplier += e;
        isGenerating = true;
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
}
