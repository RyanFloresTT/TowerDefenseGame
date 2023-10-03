using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    PlayerInputActions playerActions;
    public static Action OnPlayerLeftClicked;

    void Awake() {
        playerActions = new();
    }
    void Start() {
        playerActions.Player.LeftClick.performed += Handle_LeftClick_Performed;
    }
    void Handle_LeftClick_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnPlayerLeftClicked?.Invoke();
    }
    void OnEnable() {
        playerActions.Player.LeftClick.Enable();
    }
    void OnDisable() {
        playerActions.Player.LeftClick.Disable();
    }
}
