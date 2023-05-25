using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceHandler : MonoBehaviour
{
    public static event EventHandler<IDictionary<GeneratorTier, float>> OnResouceCountChanged;
    [SerializeField] IDictionary<GeneratorTier, float> resourceMap;

    private void Start()
    {
        Generator.OnResourceGenerated += Handle_ResourceGenerated;
        resourceMap = new Dictionary<GeneratorTier, float>();
    }

    private void Handle_ResourceGenerated(object sender, ResourceData data)
    {
        AddResourceToDictionary(data);
        OnResouceCountChanged?.Invoke(this, resourceMap);
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
    }
}
