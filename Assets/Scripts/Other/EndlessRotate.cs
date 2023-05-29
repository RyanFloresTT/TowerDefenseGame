using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotationSpeed);
    }
}
