using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundClips", menuName = "Sound/SoundClips")]
public class SoundClips : ScriptableObject {
    [field: SerializeField] public AudioClip Music { get; private set; }
    [field: SerializeField] public AudioClip EnemyDeath { get; private set; }
    [field: SerializeField] public List<AudioClip> EnemyHurt { get; private set; }
    [field: SerializeField] public AudioClip Purchase { get; private set; }
    [field: SerializeField] public AudioClip LevelUp { get; private set; }
    [field: SerializeField] public AudioClip Gunshot { get; private set; }

}
