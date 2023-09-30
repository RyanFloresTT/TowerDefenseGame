using UnityEngine;

[RequireComponent(typeof(TurretTargeting))]
public class TurretRotater : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    TurretTargeting targeting;
    Enemy target;

    void Start() {
        targeting = GetComponent<TurretTargeting>();
        targeting.OnCurrentTargetChanged += Handle_TargetChanged;
    }

    void Handle_TargetChanged(Enemy e) {
        target = e;
    }

    void Update() {
        if (HasTarget()) {
            LookAtTarget();
        }
    }
    void LookAtTarget()
    {
        var lookPos = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookPos, Vector3.up);

        float targetYRotation = lookRotation.eulerAngles.y;

        Quaternion targetRotation = Quaternion.Euler(0f, targetYRotation, 0f);

        float step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, step);
    }


    bool HasTarget() => target != null;
}
