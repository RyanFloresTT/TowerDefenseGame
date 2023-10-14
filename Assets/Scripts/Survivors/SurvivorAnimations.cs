using System;
using UnityEngine;

/*
WeaponType_int - Sets the type of weapon animation to play
0 = No weapon
1 = Pistol
2 = AssultRifle01
3 = AssultRifle02
4 = Shotgun
5 = SniperRifle
6 = Rifle
7 = SubMachineGun
8 = RPG
9 = MiniGun
10 = Grenades
11 = Bow
12 = Melee
*/

[RequireComponent (typeof(SurvivorShooting))]
public class SurvivorAnimations : MonoBehaviour, IUseSurvivorData
{
    [SerializeField] Animator animator;

    SurvivorData data;
    SurvivorShooting shootComponent;

    const string HAS_TARGET = "HasTarget_b";
    const string RELOAD = "Reload_t";
    const string WEAPON_SHOT = "Shoot_t";
    const string RUNNING = "Running_b";
    const string WEAPON_TYPE = "WeaponType_int";

    void Awake() {
        shootComponent = GetComponent<SurvivorShooting>();
        GetSurvivorData();
        EnemySpawner.OnWaveCleared += Handle_WaveCleared;
        animator.SetInteger(WEAPON_TYPE, data.WeaponType);
        shootComponent.OnSurvivorShot += Handle_WeaponShot;
    }

    void Handle_WeaponShot() {
        animator.SetTrigger(WEAPON_SHOT);
    }

    void Handle_WaveCleared() {
        animator.SetTrigger(RELOAD);
    }

    void Update() {
        if (data.IsMoving) {
            animator.SetBool(RUNNING, true);
        }
        else {
            animator.SetBool(RUNNING, false);
        }

        if (data.Target != null && !data.IsMoving) {     
            animator.SetBool(HAS_TARGET, true);
        }
        else {
            animator.SetBool(HAS_TARGET, false);
        }
    }

    public void GetSurvivorData()
    {
        data = GetComponent<Survivor>().Data;
    }
}
