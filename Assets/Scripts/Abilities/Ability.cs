using System;
using UnityEngine;

[Serializable]
public abstract class Ability : MonoBehaviour
{
    public abstract void Initialize();
    public abstract void StartAbility();
    public abstract Sprite GetAbilityIcon(); 
}
