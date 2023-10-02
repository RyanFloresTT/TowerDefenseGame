using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private bool isFloatingFacingCamera = false;
    [SerializeField] private GameObject unitWithHealth;
    private Slider healthBar;

    private void Start()
    {
        healthBar = GetComponent<Slider>();
        var damageable = unitWithHealth.GetComponent<ITakeDamage>();
        // put action listen here
    }

    private void Handle_OnDamageTaken(float e)
    {
        healthBar.value = e;
    }
}
