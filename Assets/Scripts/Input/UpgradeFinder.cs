using System.Collections.Generic;
using UnityEngine;

public class UpgradeFinder : MonoBehaviour
{
    Ray ray;
    RaycastHit[] hits;
    IHaveUpgrades lastOpenCanvas;

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
            if (!colGameObject.HasComponent<IHaveUpgrades>()) {
                CloseLastOpenCanvas();
                continue; 
            } else {
                CloseLastOpenCanvas();
                var upgradeUnit = colGameObject.GetComponent<IHaveUpgrades>();
                upgradeUnit.ShowCanvas();
                lastOpenCanvas = upgradeUnit;
            }
        }
    }

    void CloseLastOpenCanvas() {
        if (lastOpenCanvas != null) {
            lastOpenCanvas.HideCanvas();
        }
    }
}