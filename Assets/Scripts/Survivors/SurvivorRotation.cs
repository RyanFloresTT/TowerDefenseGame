using UnityEngine;

public class SurvivorRotation : MonoBehaviour, IUseSurvivorData
{
    SurvivorData data;
    const float ROTATION_SPEED = 10f;

    void Awake() {
        GetSurvivorData();
    }

    void Update() {
        if (HasTarget() && !data.IsMoving) {
            LookAtTarget();
        }
    }
    void LookAtTarget() {
        var lookPos = data.Target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookPos, Vector3.up);

        float targetYRotation = lookRotation.eulerAngles.y;

        Quaternion targetRotation = Quaternion.Euler(0f, targetYRotation, 0f);

        float step = ROTATION_SPEED * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, step);
    }

    bool HasTarget() => data.Target != null;

    public void GetSurvivorData() {
        data = GetComponent<Survivor>().Data;
    }
}
