using UnityEngine;

public class SurvivorUpgrades : MonoBehaviour, IHaveUpgrades
{
    [SerializeField] GameObject upgradeCanvas;

    bool isActive;
    void Awake() {
        isActive = false;
        upgradeCanvas.SetActive(isActive);
    }
    public void ToggleCanvas() {
        Debug.Log(isActive);
        isActive = !isActive;
        upgradeCanvas.SetActive(isActive);
    }
}
