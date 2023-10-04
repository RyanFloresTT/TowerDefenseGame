using System;
using UnityEngine;

[Serializable]
public class KillRequirement {
    [field: SerializeField] public GameObject Zombie { get; private set; }
    [field: SerializeField] public int SpawnAmount { get; private set; }
}
