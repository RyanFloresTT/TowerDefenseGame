using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public abstract void Initialize();
    public abstract void StartAbility();
    public abstract Sprite GetAbilityIcon(); 
}
