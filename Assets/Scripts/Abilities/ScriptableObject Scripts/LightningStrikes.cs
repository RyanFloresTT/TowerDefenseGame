using System.Collections;
using System;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "LightningStrike", menuName = "Abilities/LightningStrike")]
public class LightningStrikes : Ability
{
    [SerializeField] private float damage;
    [SerializeField] private float strikeAreaRadius;
    [SerializeField] private GameObject lightningStrikeAnimationPrefab;
    [SerializeField] private Sprite iconImage;
    [SerializeField] private float spawnRadius;
    private Camera mainCamera;

    private float destroyDelayInSeconds;

    public override void Initialize()
    {
        damage = 1f;
        strikeAreaRadius = 1f;
        destroyDelayInSeconds = 1f;
        mainCamera = Camera.main;
    }

    public override void StartAbility()
    {
        LightningStrike();
    }

    private void LightningStrike()
    {
        Debug.Log("Strike");
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) )
        {
            var strike = Instantiate(lightningStrikeAnimationPrefab, hit.point, Quaternion.identity);
            strike.GetComponent<LightningStrikeDamage>().Damage = damage;
            Destroy(strike, destroyDelayInSeconds);
        }
    }

    private Vector3 GetWorldPositionFromMouse() => mainCamera.ScreenToWorldPoint(Input.mousePosition);

    public Vector2 GetRandomSpawnInCircle() => UnityEngine.Random.insideUnitCircle * spawnRadius;

    public override Sprite GetAbilityIcon() => iconImage;
}
