using System.Collections;
using UnityEngine;
using TMPro;

public class Purchase : MonoBehaviour  {
    [SerializeField] float resourceCost;
    [SerializeField] GameObject errorText;
    [SerializeField] float errorTextDurationInSeconds;
    [SerializeField] GameObject nextMenu;
    [SerializeField] GameObject unlockText;
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] GameObject costGroup;
    [SerializeField] GameObject thisMenu;

    bool wasPurchased;

    ResourceHandler resourceHandler;

    void Start() {
        resourceHandler = ResourceHandler.Instance;
        costText.text = "x" + resourceCost.ToString();

        if(wasPurchased) {
            costGroup.SetActive(false);
            unlockText.SetActive(false);
        }
    }

    public void MakePurchase() {
        if (wasPurchased) {
            ShowNextMenu();
        } else {
            CompletePurchase();
        }
    }

    void ShowErrorText() {
        errorText.SetActive(true);
        StartCoroutine(TurnOffErrorText());
    }

    IEnumerator TurnOffErrorText()
    {
        yield return new WaitForSecondsRealtime(errorTextDurationInSeconds);
        errorText.SetActive(false);
    }

    void CompletePurchase() {
        if (resourceHandler.Purchase(1)) {
            unlockText.SetActive(false);
            costGroup.SetActive(false);
            wasPurchased = true;
        } else {
            ShowErrorText();
        }
    }

    void ShowNextMenu() {
        nextMenu.SetActive(true);
        thisMenu.SetActive(false);
    }
}
