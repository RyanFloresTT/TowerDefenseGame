using System;
using UnityEngine;

[Serializable]
public class WaveData
{
    [field: SerializeField] public int RequiredKills { get; private set; }
    [field: SerializeField] public float Delay { get; private set; }
}
