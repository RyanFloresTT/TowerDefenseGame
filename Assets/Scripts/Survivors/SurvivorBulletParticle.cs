using System.Collections.Generic;
using UnityEngine;

public class SurvivorBulletParticle : MonoBehaviour
{
    SurvivorShooting survivorShooting;
    SurvivorData data;
    List<ParticleCollisionEvent> collisionEvents = new();
    ParticleSystem bulletParticleSystem;
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
            targettedEnemy.TakeDamage(data.Damage);
        }
    }

    public void SetShootingComponent(SurvivorShooting shootingComponent) {
        survivorShooting = shootingComponent;
    }
    public void SetData(SurvivorData incData) {
        data = incData;
    }
}
