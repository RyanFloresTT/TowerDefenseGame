using UnityEngine;

[CreateAssetMenu(menuName = "Survivor/New Survivor")]
public class SurvivorData : ScriptableObject
{
    [field: SerializeField] public string Name;
    [field: SerializeField] public Sprite profilePicture;
    [field: SerializeField] public GameObject Weapon;
    [field: SerializeField] public Enemy Target { get; set; }
    [field: SerializeField] public int WeaponType { get; set; }

    [SerializeField] private float damage = 1f;
    public float Damage {
        get { return damage * DamageMultiplier; }
        set { damage = value; }
    }

    [SerializeField] private float shotSpeed = 1f;
    public float ShotSpeed {
        get { return shotSpeed / ShotSpeedMultiplier; }
        set { shotSpeed = value; }
    }
    [field: SerializeField] public float Range { get; set; }
    [field: SerializeField] public float DamageMultiplier { get; set; } = 1f;
    [field: SerializeField] public float ShotSpeedMultiplier { get; set; } = 1f;
    [field: SerializeField] public Survivor Survivor { get ; set; }
    [field: SerializeField] public float Speed { get; set; }
    public bool IsMoving { get; set; } = false;
}
