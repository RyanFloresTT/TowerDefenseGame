using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Managers/Level")]
public class LevelData : ScriptableObject { 
    public int WaveIndex { get; set; }
    [field: SerializeField] public List<WaveData> Waves { get; set; }
    public WaveData CurrentWave { get { return Waves[WaveIndex]; } set { } }
}
