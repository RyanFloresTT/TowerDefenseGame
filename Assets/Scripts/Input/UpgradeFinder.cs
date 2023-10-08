using UnityEngine;

public class UpgradeFinder : MonoBehaviour
{
    [SerializeField] LayerMask upgradeLayer;
    Ray ray;
    RaycastHit[] hits;
    IHaveMenu lastOpenCanvas;

    void Awake() {
        GameInput.OnPlayerLeftClicked += Handle_LeftClick;
    }

    void Handle_LeftClick() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray, float.MaxValue, upgradeLayer);
        foreach (RaycastHit hit in hits) {
            CloseLastOpenCanvas();
            var colGameObject = hit.collider.gameObject;
            colGameObject.TryGetComponent<IHaveMenu>(out lastOpenCanvas);
            lastOpenCanvas?.ShowCanvas();
            if (lastOpenCanvas != null) {
                break;
            }
        }
    }

    void CloseLastOpenCanvas() {
        lastOpenCanvas?.HideCanvas();
    }
}