using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "WaveManager", menuName = "Managers/Wave Manager")]
public class WaveManager : ScriptableObject {
    List<Action<WaveData>> onWaveFinished = new();

    public void AddListener(Action<WaveData> listener) => onWaveFinished.Add(listener);

    public void Raise(WaveData data) {
        foreach (Action<WaveData> method in onWaveFinished) {
            method?.Invoke(data);
        }
    }
}