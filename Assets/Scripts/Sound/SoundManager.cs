using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundClips sounds;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Enemy.OnEnemyDeath += Handle_EnemyDeath;
        source.PlayOneShot(sounds.Music);
        source.volume = 1.0f;
    }

    private void Handle_EnemyDeath(Enemy obj)
    {
        source.PlayOneShot(sounds.EnemyDeath);
    }
}
