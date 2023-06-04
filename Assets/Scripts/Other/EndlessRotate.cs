using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRotate : MonoBehaviour
{
    [SerializeField] private float startingRotationSpeed;
    [SerializeField] private Generator generator;

    private float rotationSpeed;

    private void Start()
    {
        generator.OnRateChanged += UpdateRotationSpeedByPercent;
        rotationSpeed = startingRotationSpeed;
    }
    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotationSpeed);
    }

    private void UpdateRotationSpeedByPercent(float amount)
    {
        rotationSpeed = startingRotationSpeed * amount;
    }
}
