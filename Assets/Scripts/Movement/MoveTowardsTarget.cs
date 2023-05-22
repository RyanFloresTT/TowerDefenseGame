using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    [SerializeField] private float speed = 0.25f;
    [SerializeField] private float speedMultipier = 1.0f;
    [SerializeField] private Transform target;

    private void FixedUpdate()
    {
        Move();
        RotateObject();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * speedMultipier);
    }

    private void RotateObject()
    {
        transform.LookAt(target);
    }
}
