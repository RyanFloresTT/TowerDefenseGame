using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] SurvivorBulletParticle bulletParticles;
    [SerializeField] List<WeaponUpgrade> weaponAttachments = new();

    public List<WeaponUpgrade> WeaponUpgrades {  get { return weaponAttachments; } }

    public void SetComponents(SurvivorData data, SurvivorShooting shooting) {
        bulletParticles.SetData(data);
        bulletParticles.SetShootingComponent(shooting);
    }
}
