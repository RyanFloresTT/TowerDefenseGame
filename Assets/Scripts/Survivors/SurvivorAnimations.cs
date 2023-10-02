using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorAnimations : MonoBehaviour {
    [SerializeField] SurvivorData data;
    [SerializeField] Animator animator;

    const string FULL_AUTO_ANIM = "Full_Auto";


    void Update()    {
        if (data.Target != null) {
            animator.SetBool(FULL_AUTO_ANIM, true);
        } else {
            animator.SetBool(FULL_AUTO_ANIM, false);
        }
    }
}
