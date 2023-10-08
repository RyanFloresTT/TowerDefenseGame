using System.Collections;
using UnityEngine;

public class SurvivorMoveTo : MonoBehaviour, IUseSurvivorData, IHaveActionButtons
{
    [SerializeField] LayerMask layerMaskToIgnore;
    [SerializeField] Vector3 velocity = Vector3.zero;
    [SerializeField] float smoothTime = 0.2f;
    [SerializeField] MenuButton upgradeAction;
    [SerializeField] GameObject actionButtonPrefab;

    SurvivorData data;
    bool hasClicked;
    bool awaitingClick;
    Vector3 destination;

    public GameObject ActionButton { get { return actionButtonPrefab; } set { } }

    void Awake() {
        GetSurvivorData();
    }

    void Start() {
        hasClicked = false;
        awaitingClick = false;
        GameInput.OnPlayerLeftClicked += Handle_LeftClick;
    }
    void Update() {
        Vector3 destinationWithoutY = new Vector3(destination.x, transform.position.y, destination.z);
        Vector3 smoothDampedVelocity = Vector3.SmoothDamp(transform.position, destinationWithoutY, ref velocity, smoothTime);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(smoothDampedVelocity);
        if (Vector3.Distance(transform.position, destinationWithoutY) < 0.1f) {
            hasClicked = false;
            awaitingClick = false;
        }
    }

    void Handle_LeftClick() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, ~layerMaskToIgnore))
        {
            if (awaitingClick) { hasClicked = true; }
            destination = hit.point;
        }
    }

    public void StartMoveSequence() {
        hasClicked = false;
        awaitingClick = true;
        StartCoroutine(WaitForClick());
    }

    IEnumerator WaitForClick() {
        yield return new WaitUntil(HasClicked);
    }

    bool HasClicked() => hasClicked;

    public void GetSurvivorData() => data = GetComponent<Survivor>().Data;
}
