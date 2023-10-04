using System;
using UnityEngine;

public class MoveTowardsStaticTarget : MonoBehaviour {
    [SerializeField] float speed = 0.25f;
    [SerializeField] float speedMultipier = 1.0f;
    [SerializeField] Transform target;
    Vector3 currentTarget;

    void Start() {
        if (target == null) return;
        currentTarget = target.position;
    }

    void FixedUpdate() {
        Move();
        RotateObject();
    }

    void Move() {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * speedMultipier * Time.deltaTime);
    }

    void RotateObject() {
        transform.LookAt(currentTarget);
    }

    public void SetTarget(Transform target)
    {
        currentTarget = target.position;
    }
}
