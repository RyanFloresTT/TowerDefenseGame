using UnityEngine;
using UnityEngine.UI;

public class UnlockWeaponAttachment : MonoBehaviour{
    public WeaponUpgrade Upgrade { get; set; }
    [SerializeField] Image icon;

    public void SetIcon(Sprite sprite) {
        icon.sprite = sprite;
    }

    public void PressButton() {
        Upgrade?.TryUnlockWeapon();
    }
}