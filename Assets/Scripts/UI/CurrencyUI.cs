using PrimeTween;
using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour {
    [SerializeField] TextMeshProUGUI currencyText;
    [SerializeField] float duration;
    [SerializeField] float shakeMultiplier = 1f;
    Vector3 shakeStrength;

    void Awake() { 
        ResourceHandler.OnCurrencyCountUpdated += Handle_CurrencyUpdated;
    }

    void Handle_CurrencyUpdated(int amount) {
        currencyText.text = amount.ToString();
        shakeStrength = new Vector3(amount * shakeMultiplier, amount * shakeMultiplier, amount * shakeMultiplier);
        Tween.ShakeLocalPosition(currencyText.transform, shakeStrength, duration);
    }
}
