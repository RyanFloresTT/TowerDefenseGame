using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : MonoBehaviour
{
    public static event EventHandler<IDictionary<GeneratorTier, float>> OnResouceCountChanged;
    public static event EventHandler<bool> OnSuccessfulPurchase;

    [SerializeField] IDictionary<GeneratorTier, float> resourceMap;

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

    private void Handle_ResourceGenerated(object sender, ResourceData data)
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
        OnResouceCountChanged?.Invoke(this, resourceMap);
    }

    public bool Purchase(ResourceData data)
    {
        if (HasKeyAndRequiredAmount(data))
        {
            resourceMap[data.Tier] -= data.Amount;
            OnResouceCountChanged?.Invoke(this, resourceMap);
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool HasKeyAndRequiredAmount(ResourceData data) => resourceMap.ContainsKey(data.Tier) && data.Amount <= resourceMap[data.Tier];
}