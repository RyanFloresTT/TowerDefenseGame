using Unity.VisualScripting;
using UnityEngine;

public class PurchaseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject layoutGroup;
    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new();
        inputActions.Player.OpenPurchaseMenu.performed += Handle_OpenMenu_Performed;

        CloseMenu();
    }

    private void OnEnable()
    {
        inputActions.Player.OpenPurchaseMenu.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.OpenPurchaseMenu.Disable();
    }

    private void Start()
    {
    }

    private void Handle_OpenMenu_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        ToggleMenu();
    }

    private void OpenMenu()
    {
        menu.SetActive(true);
    }

    private void CloseMenu()
    {
        menu.SetActive(false);
    }

    private void ToggleMenu()
    {
        menu.SetActive(!menu.activeInHierarchy);
    }
}
