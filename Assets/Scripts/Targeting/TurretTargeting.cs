using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    [SerializeField] private TargetEnemyWithinRange targetingSource;
    private GameObject target;

    private void Start()
    {
        targetingSource.OnObjectEnteredRange += Handle_TargetEnteredRange;
    }

    private void Handle_TargetEnteredRange(object sender, GameObject e)
    {
        Debug.Log("Target Acquired");
        target = e;
    }

    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform.position);
        }
    }
}
