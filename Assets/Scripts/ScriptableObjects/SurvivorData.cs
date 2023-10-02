using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Survivor/New Survivor")]
public class SurvivorData : ScriptableObject
{
    public string Name;
    public Image TalkingHeadIcon;
    public GameObject StartingWeapon;
    public Enemy Target { get; set; }

    private float _damage;
    public float Damage {
        get { return _damage * DamageModifier; }
        set { _damage = value; }
    }

    private float _shotSpeed;
    public float ShotSpeed {
        get { return _shotSpeed * ShotSpeedMultiplier; }
        set { _shotSpeed = value; }
    }

    public float Range;
    public float DamageModifier;
    public float ShotSpeedMultiplier;
}
