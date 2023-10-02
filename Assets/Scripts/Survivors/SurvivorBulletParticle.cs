using System.Collections.Generic;
using UnityEngine;

public class SurvivorBulletParticle : MonoBehaviour
{
    [SerializeField] SurvivorShooting survivorShooting;
    [SerializeField] float bulletDamage = 1f;
    [SerializeField] ParticleSystem bulletParticleSystem;

    List<ParticleCollisionEvent> collisionEvents = new();
    Enemy targettedEnemy;

    void Start() {
        survivorShooting.OnSurvivorShot += Handle_SurvivorShot;
        bulletParticleSystem = GetComponent<ParticleSystem>();
    }

    void Handle_SurvivorShot() {
        bulletParticleSystem.Play();
    }

    void OnParticleCollision(GameObject other) {
        bulletParticleSystem.GetCollisionEvents(other, collisionEvents);

        if (other.HasComponent<Enemy>()) { 
            targettedEnemy = other.GetComponent<Enemy>();
            targettedEnemy.TakeDamage(bulletDamage);
        }
    }
}
