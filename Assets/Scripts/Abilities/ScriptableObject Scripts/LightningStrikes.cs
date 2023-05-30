using System.Collections;
using System;
using UnityEngine;

[Serializable]
public class LightningStrikes : Ability
{
    [SerializeField] private float Damage;
    [SerializeField] private float amountOfStrikes;
    [SerializeField] private float strikeAreaRadius;
    [SerializeField] private GameObject lightningStrikeAnimationPrefab;
    [SerializeField] private Sprite iconImage;
    [SerializeField] private float destroyDelayInSeconds = 10f;
    [SerializeField] private float timeBetweenEachStrikeInSeconds;
    [SerializeField] private float spawnRadius;

    public override void Initialize()
    {
    }

    public override void StartAbility()
    {
        StartCoroutine(StartStorm());
    }

    private IEnumerator StartStorm()
    {
        // Change Weather
        yield return new WaitForSecondsRealtime(timeBetweenEachStrikeInSeconds);
        LightningStrike();
    }

    private void LightningStrike()
    {
        var strike = Instantiate(lightningStrikeAnimationPrefab);
        var randVector2 = GetRandomSpawnInCircle();
        strike.transform.position = new Vector3(randVector2.x, 0, randVector2.y);
    }

    public Vector2 GetRandomSpawnInCircle() => UnityEngine.Random.insideUnitCircle * spawnRadius;

    public override Sprite GetAbilityIcon() => iconImage;
}
