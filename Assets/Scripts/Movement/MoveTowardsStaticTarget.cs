using System;
using UnityEngine;

public class MoveTowardsStaticTarget : MonoBehaviour
{
    [SerializeField] private float speed = 0.25f;
    [SerializeField] private float speedMultipier = 1.0f;
    [SerializeField] private Transform target;
    private Vector3 currentTarget;

    private void Start()
    {
        if (target == null) return;
        currentTarget = target.position;
    }

    private void FixedUpdate()
    {
        Move();
        RotateObject();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * speedMultipier);
    }

    private void RotateObject()
    {
        transform.LookAt(currentTarget);
    }

    public void SetTarget(Transform target)
    {
        currentTarget = target.position;
    }
}
