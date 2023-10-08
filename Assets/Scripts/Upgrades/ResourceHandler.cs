using System;
using System.Collections;
using UnityEngine;

public class ResourceHandler : MonoBehaviour {
    public static Action<int> OnCurrencyCountUpdated;
    public static Action OnSuccessfulPurchase;

    [SerializeField] GameObject errorText;
    [SerializeField] float errorTimeInSeconds;
    public int CurrencyCount { get; set; } = 0;
    public static ResourceHandler Instance { get; set; }

    void Awake() {
        Instance = this;
        OnCurrencyCountUpdated?.Invoke(CurrencyCount);
    }

    void Start() {
        Enemy.OnEnemyDeath += Handle_EnemyDeath;
        CurrencyCount = 0;
    }

    void Handle_EnemyDeath(Enemy enemy)
    {
        CurrencyCount += enemy.PointValue;
        OnCurrencyCountUpdated?.Invoke(CurrencyCount);
    }

    public bool Purchase(int amount) {
        if (HasRequiredAmount(amount)) {
            CurrencyCount -= amount;
            OnCurrencyCountUpdated?.Invoke(CurrencyCount);
            OnSuccessfulPurchase?.Invoke();
            return true;
        }
        else {
            ShowErrorText();
            return false;
        }  
    }

    public void ShowErrorText() {
        errorText.SetActive(true);
        StartCoroutine(HideErrorText());
    }

    IEnumerator HideErrorText() {
        yield return new WaitForSecondsRealtime(errorTimeInSeconds);
        errorText.SetActive(false);
    }

    bool HasRequiredAmount(int amount) => amount <= CurrencyCount;
}