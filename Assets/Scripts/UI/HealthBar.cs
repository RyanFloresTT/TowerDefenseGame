using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour {
    [SerializeField] bool isFloatingFacingCamera = false;
    [SerializeField] GameObject unitWithHealth;
    Slider healthBar;

    void Start() {
        healthBar = GetComponent<Slider>();
        var damageable = unitWithHealth.GetComponent<ITakeDamage>();
        //{something}.OnDamageTaken += Handle_OnDamageTaken;
    }

    void Handle_OnDamageTaken(float e)
    {
        healthBar.value = e;
    }
}
