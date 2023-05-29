using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu()]
public class LightningStrikes : Ability
{
    [SerializeField] private float Damage;
    [SerializeField] private float amountOfStrikes;
    [SerializeField] private float strikeAreaRadius;
    [SerializeField] private GameObject lightningStrikeAnimationPrefab;
    [SerializeField] private Sprite iconImage;

    public override void Initialize()
    {
    }

    public override void StartAbility()
    {
        var strike = Instantiate(lightningStrikeAnimationPrefab);
        strike.transform.position = GetMouseToWorldPosision();
    }

    public override Sprite GetAbilityIcon() => iconImage;

    private Vector3 GetMouseToWorldPosision() => Camera.main.ScreenToWorldPoint(Input.mousePosition);
}
