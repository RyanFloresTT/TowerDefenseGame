using System.Collections;
using UnityEngine;
using TMPro;
public class Purchase : MonoBehaviour
{
    [SerializeField] private GameObject objectToUnlock;
    [SerializeField] private GeneratorTier resourceTier;
    [SerializeField] private float resourceCost;
    [SerializeField] private GameObject errorText;
    [SerializeField] private float errorTextDurationInSeconds;
    [SerializeField] private GameObject nextMenu;
    [SerializeField] private GameObject unlockText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private GameObject costGroup;

    private bool wasPurchased;

    private ResourceHandler resourceHandler;

    private void Start()
    {
        resourceHandler = ResourceHandler.Instance;
        wasPurchased = objectToUnlock.activeInHierarchy;
        costText.text = "x" + resourceCost.ToString();

        if(wasPurchased)
        {
            costGroup.SetActive(false);
            unlockText.SetActive(false);
        }
    }

    public void MakePurchase()
    {
        if (wasPurchased)
        {
            ShowNextMenu();
        } else
        {
            CompletePurchase();
        }
    }

    private void ShowErrorText()
    {
        errorText.SetActive(true);
        StartCoroutine(TurnOffErrorText());
    }

    private IEnumerator TurnOffErrorText()
    {
        yield return new WaitForSecondsRealtime(errorTextDurationInSeconds);
        errorText.SetActive(false);
    }

    private void CompletePurchase()
    {
        var data = new ResourceData(resourceTier, resourceCost);
        var successfulPurchase = resourceHandler.Purchase(data);
        if (successfulPurchase)
        {
            objectToUnlock.SetActive(true);
            unlockText.SetActive(false);
            costGroup.SetActive(false);
            wasPurchased = true;
        }
        else
        {
            ShowErrorText();
        }
    }

    private void ShowNextMenu()
    {
        nextMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
