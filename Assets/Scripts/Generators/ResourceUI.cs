using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] resourceCounts;

    private void Start()
    {
        ResourceHandler.OnResouceCountChanged += Handle_ResourceCountChanged;
    }

    private void Handle_ResourceCountChanged(object sender, IDictionary<GeneratorTier, float> e)
    {
        UpdateText(e);
    }

    private void UpdateText(IDictionary<GeneratorTier, float> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            var amount = data.ElementAt(i).Value.ToString();
            var tier = data.ElementAt(i).Key.ToString();
            resourceCounts[i].text = ("x" + amount);
        }
    }
}
