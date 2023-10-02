using UnityEngine;

public class SurvivorUpgrades : MonoBehaviour, IHaveUpgrades
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
