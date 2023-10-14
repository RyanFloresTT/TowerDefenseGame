using UnityEngine;

public class VisualizeRange : MonoBehaviour, IUseSurvivorData
{
    [SerializeField] Color gizmoColor = Color.blue;
    SurvivorData data;

    public void GetSurvivorData() {
        data = GetComponent<Survivor>().Data;
    }

    void OnDrawGizmos() {
        if (data == null) {
            data = GetComponent<Survivor>().Data;
        }
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, data.Range);
    }
}
