using PrimeTween;
using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour {
    [SerializeField] TextMeshProUGUI currencyText;
    void Awake() { 
        ResourceHandler.OnCurrencyCountUpdated += Handle_CurrencyUpdated;
    }

    void Handle_CurrencyUpdated(int amount) {
        currencyText.text = amount.ToString();
    }
}
