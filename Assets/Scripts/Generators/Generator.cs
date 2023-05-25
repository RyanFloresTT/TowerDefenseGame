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

    private float generationAmountMultiplier = 1f;
    private float generationSpeedMultiplier = 1f;
    private bool isGenerating;

    private void Start()
    {
        isGenerating = true;
        StartCoroutine(GenerateResources());
    }

    private IEnumerator GenerateResources()
    {
        while (isGenerating)
        {
            Generate();
            yield return new WaitForSeconds(generationRateInSeconds * (1 / generationSpeedMultiplier));
        }
    }

    private void Generate()
    {
        var resource = new ResourceData(tier, generationAmount * generationAmountMultiplier);
        OnResourceGenerated?.Invoke(this, resource);
    }

    public void SetGenerationStatus(bool willGenerate)
    {
        isGenerating = willGenerate;
    }
}
