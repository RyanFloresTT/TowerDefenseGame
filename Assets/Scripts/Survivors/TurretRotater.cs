using UnityEngine;

[RequireComponent(typeof(TurretTargeting))]
public class TurretRotater : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    private TurretTargeting targeting;
    private Enemy target;

    private void Start() {
        targeting = GetComponent<TurretTargeting>();
        targeting.OnCurrentTargetChanged += Handle_TargetChanged;
    }

    private void Handle_TargetChanged(Enemy e) {
        target = e;
    }

    private void Update() {
        if (HasTarget()) {
            LooKAtTarget();
        }
    }
    private void LooKAtTarget() {
        var lookPos = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRotation.eulerAngles.y;

        float step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, step);
    }

    private bool HasTarget() => target != null;
}
