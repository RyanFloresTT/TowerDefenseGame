using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {
    [SerializeField] SoundClips sounds;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public static SoundManager Instance { get; set; }

    void Awake() {
        InitializeSingleton();
        AddListeners();
        PlayMusic();
    }

    void AddListeners() {
        Enemy.OnEnemyDeath += Handle_EnemyDeath;
        SurvivorShooting.OnSurvivorShotGunSFX += Handle_SurvivorShot;
        ResourceHandler.OnSuccessfulPurchase += Handle_SuccessPurchase;
    }

    void InitializeSingleton() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    void Handle_SurvivorShot() {
        sfxSource.PlayOneShot(sounds.Gunshot);
    }
    void PlayMusic() { 
        musicSource.clip = sounds.Music;
        if (musicSource.isPlaying) return;
        musicSource.Play();
    }
    void Handle_SuccessPurchase() {
        sfxSource.PlayOneShot(sounds.Purchase);
    }
    void Handle_EnemyDeath(Enemy obj) {
        sfxSource.PlayOneShot(sounds.EnemyDeath);
    }
}
