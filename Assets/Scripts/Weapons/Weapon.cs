using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] SurvivorBulletParticle bulletParticles;

    public void SetComponents(SurvivorData data, SurvivorShooting shooting) {
        bulletParticles.SetData(data);
        bulletParticles.SetShootingComponent(shooting);
    }
}
