using UnityEngine;

public class UpgradeFinder : MonoBehaviour
{
    Ray ray;
    RaycastHit[] hits;

    void Awake() {
        GameInput.OnPlayerLeftClicked += Handle_LeftClick;
    }

    void Handle_LeftClick()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray, float.MaxValue);
        foreach (RaycastHit hit in hits)
        {
            var colGameObject = hit.collider.gameObject;
            if (!colGameObject.HasComponent<IHaveUpgrades>()) { continue; }
            else
            {
                var upgradeUnit = colGameObject.GetComponent<IHaveUpgrades>();
                upgradeUnit.ToggleCanvas();
            }
        }
    }
}