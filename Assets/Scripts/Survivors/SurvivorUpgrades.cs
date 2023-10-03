using UnityEngine;

public class SurvivorUpgrades : MonoBehaviour, IHaveMenu
{
    [SerializeField] GameObject upgradeCanvas;

    void Awake() {
        HideCanvas();
    }

    public void ShowCanvas() {
        upgradeCanvas.SetActive(true);
    }

    public void HideCanvas() {
        upgradeCanvas.SetActive(false);
    }
}
