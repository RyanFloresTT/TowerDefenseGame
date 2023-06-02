using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : MonoBehaviour
{
    public static event Action<IDictionary<GeneratorTier, float>> OnResouceCountChanged;
    public static event Action<bool> OnSuccessfulPurchase;

    [SerializeField] private GameObject errorText;
    [SerializeField] private float errorTimeInSeconds;

    private IDictionary<GeneratorTier, float> resourceMap;

    public static ResourceHandler Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Generator.OnResourceGenerated += Handle_ResourceGenerated;
        resourceMap = new Dictionary<GeneratorTier, float>();
    }

    private void Handle_ResourceGenerated(ResourceData data)
    {
        AddResourceToDictionary(data);
    }

    private void AddResourceToDictionary(ResourceData data)
    {
        if(resourceMap.ContainsKey(data.Tier))
        {
            resourceMap[data.Tier] += data.Amount;
        } else
        {
            resourceMap.Add(data.Tier, data.Amount);
        }
        OnResouceCountChanged?.Invoke(resourceMap);
    }

    public bool Purchase(ResourceData data)
    {
        if (HasKeyAndRequiredAmount(data))
        {
            resourceMap[data.Tier] -= data.Amount;
            OnResouceCountChanged?.Invoke(resourceMap);
            return true;
        }
        else
        {
            return false;
        }  
    }

    public void ShowErrorText()
    {
        errorText.SetActive(true);
        StartCoroutine(HideErrorText());
    }

    private IEnumerator HideErrorText()
    {
        yield return new WaitForSecondsRealtime(errorTimeInSeconds);
        errorText.SetActive(false);
    }

    private bool HasKeyAndRequiredAmount(ResourceData data) => resourceMap.ContainsKey(data.Tier) && data.Amount <= resourceMap[data.Tier];
}