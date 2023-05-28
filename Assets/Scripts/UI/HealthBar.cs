using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private bool isFloatingFacingCamera = false;
    [SerializeField] private GameObject unitWithHealth;
    private Slider healthBar;
    private Camera mainCamera;

    private void Start()
    {
        healthBar = GetComponent<Slider>();
        var damageable = unitWithHealth.GetComponent<ITakeDamage>();
        if (damageable != null)
        {
            damageable.OnDamageTaken += Handle_OnDamageTaken;
        }

        mainCamera = Camera.main;
    }

    private void Handle_OnDamageTaken(object sender, float e)
    {
        healthBar.value = e;
    }

    private void Update()
    {
        if(isFloatingFacingCamera)
        {
            transform.rotation = mainCamera.transform.rotation;
        }
    }
}
