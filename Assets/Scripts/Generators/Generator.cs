using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(UpgradeManager))]
public class Generator : MonoBehaviour, IGetUpgrades
{
    public static event Action<ResourceData> OnResourceGenerated;
    public Action<float> OnRateChanged;

    [SerializeField] private GeneratorTier tier;
    [SerializeField] private float generationAmount;
    [SerializeField] private float generationRateInSeconds;

    private float amountMultiplier = 1f;
    private float rateMultiplier = 1f;
    private bool isGenerating;

    private void Start()
    {
        isGenerating = true;
        StartCoroutine(GenerateResources());
    }

    public void ApplyUpgrades(UpgradeData data)
    {
        switch (data.type)
        {
            case (UpgradeTypes.AmountBase):
                ChangeBaseAmount(data.value);
                break;
            case (UpgradeTypes.RateMultiplierAdd):
                ChangeRateMultiplier(data.value);
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
        OnResourceGenerated?.Invoke(resource);
    }

    public void SetGenerationStatus(bool willGenerate)
    {
        isGenerating = willGenerate;
    }

    private void ChangeAmountMultiplier(float amount) => amountMultiplier += amount;
    private void ChangeRateMultiplier(float amount)
    {
        rateMultiplier += amount;
        OnRateChanged?.Invoke(rateMultiplier);
    }
    private void ChangeBaseAmount(float amount) => generationAmount += amount;
}
