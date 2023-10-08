using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorAnimations : MonoBehaviour, IUseSurvivorData
{
    [SerializeField] Animator animator;

    SurvivorData data;

    const string FULL_AUTO_ANIM = "Full_Auto";
    const string RELOAD_ANIM = "Reload";

    void Awake() {
        GetSurvivorData();
        EnemySpawner.OnWaveCleared += Handle_WaveCleared;
    }

    void Handle_WaveCleared() {
        animator.SetTrigger(RELOAD_ANIM);
    }

    void Update()    {
        if (data.Target != null) {
            animator.SetBool(FULL_AUTO_ANIM, true);
        } else {
            animator.SetBool(FULL_AUTO_ANIM, false);
        }
    }

    public void GetSurvivorData()
    {
        data = GetComponent<Survivor>().Data;
    }
}
