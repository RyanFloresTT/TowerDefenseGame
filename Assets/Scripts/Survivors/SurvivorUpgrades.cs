using System;
using UnityEngine;

public class SurvivorUpgrades : MonoBehaviour, IHaveMenu, IUseSurvivorData, IHaveActionButtons
{
    [SerializeField] GameObject upgradeCanvas;
    [SerializeField] GameObject actionButtonPrefab;
    SurvivorData data;

    public static Action<SurvivorData> OnSurvivorSelected;

    public GameObject ActionButton { get { return actionButtonPrefab; } set { } }

    void Awake() {
        GetSurvivorData();
        HideCanvas();
        ExitActionButtonMenu.OnExitMenuPressed += Handle_ExitMenu;
    }

    private void Handle_ExitMenu() {
        HideCanvas();
    }

    public void ShowCanvas() {
        upgradeCanvas.SetActive(true);
        OnSurvivorSelected?.Invoke(data);
    }

    public void HideCanvas() {
        upgradeCanvas.SetActive(false);
    }

    public void GetSurvivorData() {
        data = GetComponent<Survivor>().Data;
    }
}
