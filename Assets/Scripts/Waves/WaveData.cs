using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaveData {
    [field: SerializeField] public List<KillRequirement> KillRequirements { get; set; }
    [field: SerializeField] public float DelayBetweenWaves { get; private set; }
}
