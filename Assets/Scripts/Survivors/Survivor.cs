using UnityEngine;

public class Survivor : MonoBehaviour
{
    [SerializeField] SurvivorData data;
    [SerializeField] Transform weaponContainer;
    [SerializeField] float shotSpeed;
    [SerializeField] float damage;
    [SerializeField] float shotSpeedMult;
    [SerializeField] float damageMult;
    [SerializeField] float speed;
    public SurvivorData Data { get { return data; } }

    public IHaveActionButtons[] ActionButtons { get { 
            return GetComponents<IHaveActionButtons>();
                } private set { } }

    Weapon survivorWeapon;
    SurvivorShooting shootingComponent;

    void Awake() {
        SetDefaultData();
        var weaponObject = Instantiate(data.Weapon, weaponContainer);
        weaponObject.TryGetComponent<Weapon>(out survivorWeapon);
        TryGetComponent<SurvivorShooting>(out shootingComponent);

        data.Survivor = this;

        if ( survivorWeapon != null )  SetWeaponComponents();
    }

    void SetWeaponComponents() {
        survivorWeapon.SetComponents(data, shootingComponent);
    }

    void SetDefaultData() {
        data.Damage = damage;
        data.ShotSpeed = shotSpeed;
        data.DamageMultiplier = damageMult;
        data.ShotSpeedMultiplier = shotSpeedMult;
        data.Speed = speed;
        data.IsMoving = false;
        data.Target = null;
    }
}
