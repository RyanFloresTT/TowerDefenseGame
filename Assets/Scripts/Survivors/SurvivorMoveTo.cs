using UnityEngine;
using PrimeTween;

public class SurvivorMoveTo : MonoBehaviour, IUseSurvivorData, IHaveActionButtons
{
    [SerializeField] GameObject actionButtonPrefab;
    [SerializeField] LayerMask moveToLayers;
    [SerializeField] Ease customeEase;
    Vector3 targetPosition;
    bool allowMovement; 
    const float ROTATION_SPEED = 300f;

    SurvivorData data;

    public GameObject ActionButton { get { return actionButtonPrefab; } set { } }

    void Awake() {
        GetSurvivorData();
        SurvivorUI.OnMoveSurvivorSet += Handle_SurvivorMoveSet;
        GameInput.OnPlayerLeftClicked += Handle_LeftClick;
    }

    async void Handle_LeftClick() {
        if (!data.IsMoving && allowMovement) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, moveToLayers)) {
                targetPosition = hit.point;
                targetPosition.y = transform.position.y;
                float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
                float duration = distanceToTarget / data.Speed; 
                var lookPos = targetPosition - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(lookPos, Vector3.up);
                await Tween.RotationAtSpeed(transform, lookRotation, ROTATION_SPEED);
                data.IsMoving = true;
                await Tween.Position(transform, targetPosition, duration, customeEase);
                data.IsMoving = false;
                allowMovement = false;
            }
        }
    }

    void Handle_SurvivorMoveSet(SurvivorData incData) {
        if (data == incData && !data.IsMoving) {
            allowMovement = true;
        }
    }

    public void GetSurvivorData() => data = GetComponent<Survivor>().Data;
}
