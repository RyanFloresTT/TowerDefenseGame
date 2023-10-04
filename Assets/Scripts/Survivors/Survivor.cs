using System.Data;
using UnityEngine;

public class Survivor : MonoBehaviour {
    [SerializeField] SurvivorData data;
    [SerializeField] Transform weaponContainer;
    Weapon survivorWeapon;
    SurvivorShooting shootingComponent;

    void Awake() {
        var weaponObject = Instantiate(data.Weapon, weaponContainer);
        weaponObject.TryGetComponent<Weapon>(out survivorWeapon);
        TryGetComponent<SurvivorShooting>(out shootingComponent);

        if ( survivorWeapon != null ) { SetWeaponComponents(); }
    }

    void SetWeaponComponents() {
        survivorWeapon.SetComponents(data, shootingComponent);
    }
}
