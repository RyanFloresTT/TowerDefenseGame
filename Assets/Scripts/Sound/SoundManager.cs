using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundClips sounds;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public static SoundManager Instance { get; set; }

    void Awake()
    {
        InitializeSingleton();

        Enemy.OnEnemyDeath += Handle_EnemyDeath;
        SurvivorShooting.OnSurvivorShotGunSFX += Handle_SurvivorShot;
        ResourceHandler.OnSuccessfulPurchase += Handle_SuccessPurchase;
        PlayerLevel.OnPlayerLeveledUp += Handle_PlayerLevelUp;


        PlayMusic();
    }

    

    void InitializeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Handle_SurvivorShot()
    {
        sfxSource.PlayOneShot(sounds.Gunshot);
    }

    void Handle_EnemySurvived()
    {
        sfxSource.PlayOneShot(sounds.EnemyHurt.RandomElement<AudioClip>());
    }

    void Handle_PlayerLevelUp()
    {
        sfxSource.PlayOneShot(sounds.LevelUp);
    }

    void PlayMusic() { 
        musicSource.clip = sounds.Music;
        if (musicSource.isPlaying) return;
        musicSource.Play();
    }

    void Handle_SuccessPurchase()
    {
        sfxSource.PlayOneShot(sounds.Purchase);
    }

    void Handle_EnemyDeath(Enemy obj)
    {
        sfxSource.PlayOneShot(sounds.EnemyDeath);
    }

   
}
